<template>
  <div class="container">
    <div v-for="news in CurrentNews" :key="news.id">
      <div class="col">
        <div class="row mb-2">
          <b-card
            no-body
            border-variant="dark"
            header-bg-variant="dark"
            header-text-variant="white"
          >
            <div slot="header">
              <ul class="list-inline list-unstyled mb-0">
                <li class="list-inline-item">
                  <h5 class="text-capitalize">{{news.title}}</h5>
                </li>
                <li class="list-inline-item float-right font-weight-normal">
                  <i class="fa fa-calendar"></i>
                  {{ GetDate(news.date) }}
                </li>
              </ul>
            </div>

            <b-card-body>
              <div class="row">
                <div class="col-md-3 pr-0">
                  <div id="avatar">
                    <img class="news-avatar" v-bind:src="news.image" />
                  </div>
                </div>
                <div class="col-md-9 pl-0">
                  <div class="news-info">
                    <div class="news-content">
                      <article v-html="news.content"></article>
                    </div>
                  </div>
                </div>
              </div>
            </b-card-body>

            <b-card-footer footer-variant="dark" footer-bg-variant="dark">
              <div class="news-footer">
                <ul class="list-inline list-unstyled">
                  <li class="list-inline-item text-capitalize">
                    <router-link :to="'/profile/' + news.authorName">
                      <i class="fa fa-user"></i>
                      {{ news.authorName }}
                    </router-link>
                  </li>
                  <li
                    class="list-inline-item float-right comments"
                    :title="IsCommentsHidden(news.id) ? 'Show Comments' : 'Hide Comments'"
                    @click="ToggleCommentSection(news.id)"
                  >
                    <i class="fa fa-comment"></i>
                    Comments ({{ news.comments.length }})
                  </li>
                </ul>
              </div>
              <div class="news-comments mt-3" v-if="!IsCommentsHidden(news.id)">
                <news-comments :news="news"></news-comments>
              </div>
            </b-card-footer>
          </b-card>
        </div>
      </div>
    </div>
    <b-container>
      <b-row>
        <b-pagination
          v-model="CurrentPage"
          :total-rows="news.length"
          :per-page="PerPage"
          first-text="First"
          prev-text="Prev"
          next-text="Next"
          last-text="Last"
        ></b-pagination>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import moment from "moment";
import { SemipolarSpinner } from "epic-spinners";
import NewsComments from "./NewsComments";

const MAX_NEWS = 2;

export default {
  props: ["news"],
  data() {
    return {
      CurrentPage: 1,
      PerPage: 2,

      ActiveComments: []
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner,
    "news-comments": NewsComments
  },
  computed: {
    GetCurrentPage() {
      return (this.CurrentPage - 1) * 2;
    },
    CurrentNews() {
      const temp = [...this.news];
      return temp.splice(this.GetCurrentPage, MAX_NEWS);
    }
  },
  methods: {
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    },
    // COMMENTS
    ToggleCommentSection(id) {
      if (this.IsCommentsHidden(id)) {
        this.ShowComments(id);
      } else {
        this.HideComments(id);
      }
    },
    ShowComments(id) {
      this.ActiveComments.push(id);
    },
    HideComments(id) {
      const index = this.ActiveComments.findIndex(x => x == id);
      if (index !== -1) {
        this.ActiveComments.splice(index, 1);
      }
    },
    IsCommentsHidden(id) {
      return this.ActiveComments.find(x => x == id) == null;
    }
  },
  watch: {
    CurrentNews: function(val) {
      this.ActiveComments = [];
    }
  }
};
</script>

<style scoped lang="css">
.news-avatar {
  border: 1px solid #cbcbcb;
  padding: 7px;
  background: #fff;
  -webkit-border-radius: 4px;
  -moz-border-radius: 4px;
  border-radius: 4px;
  -webkit-box-shadow: -2px 2px 6px -1px rgba(0, 0, 0, 0.3);
  -moz-box-shadow: -2px 2px 6px -1px rgba(0, 0, 0, 0.3);
  -o-box-shadow: -2px 2px 6px -1px rgba(0, 0, 0, 0.3);
  box-shadow: -2px 2px 6px -1px rgba(0, 0, 0, 0.3);
}

.card {
  height: 100%;
  width: 100%;
  background-color: transparent;
}
.card-body {
  width: 100%;
}

.news-content {
  overflow: auto;
  white-space: pre-wrap;
  width: 100%;
}

.news-content::-webkit-scrollbar,
.news-comments::-webkit-scrollbar {
  width: 0 !important;
  background-color: #f5f5f5;
}

.comments {
  color: #786043;
}

.comments:hover {
  color: #c47e2c !important;
  cursor: pointer;
}

.news-comments {
  margin-top: 5px;
  max-height: 450px;
  overflow: auto;
}
</style>
