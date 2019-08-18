<template lang="html">
<div class="container">
    <div v-for="news in currentNews" :key="news.id">
        <div class="col">
            <div class="row mb-2">
                <b-card no-body border-variant="dark"
                        header-bg-variant="dark"
                        header-text-variant="white">

                    <div slot="header">
                        <ul class="list-inline list-unstyled mb-0">
                            <li class="list-inline-item">
                                <h5 class="text-capitalize">
                                  {{news.title}}
                                </h5>
                            </li>
                            <li class="list-inline-item float-right font-weight-normal">
                                <i class="fa fa-calendar"></i> {{ GetDate(news.date) }}
                            </li>
                        </ul>
                    </div>

                    <b-card-body>
                        <div class="row">
                            <div class="col-md-3 no-padding-right">
                                <div id="avatar">
                                    <img class="news-avatar" v-bind:src="news.image">
                                </div>
                            </div>
                            <div class="col-md-9 no-padding-left">
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
                                    <router-link :to="'/profile/' + news.authorName"><i class="fa fa-user"></i> {{ news.authorName }}</router-link>
                                </li>
                                <li class="list-inline-item float-right comments" :title="IsCommentsHidden(news.id) ? 'Show Comments' : 'Hide Comments'" @click="ToggleCommentSection(news.id)">
                                    <i class="fa fa-comment"></i> Comments ({{ news.comments.length }})
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
    <div class="row">
        <ul class="pagination">
            <li class="page-item col-8">
                <button class="btn btn-signin btn-dark btn-block" v-bind:disabled="ValidatePrevious()" @click="PreviousPage()">Previous</button>
            </li>
            <li class="page-item col-8">
                <button class="btn btn-signin btn-dark btn-block" v-bind:disabled="ValidateNext()" @click="NextPage()">Next</button>
            </li>
        </ul>
    </div>
</div>
</template>

<script>
import moment from "moment";
import { SemipolarSpinner } from "epic-spinners";
import NewsComments from "./NewsComments";

const MAX_NEWS = 2;

export default {
  props: {
    newsList: {
      type: Array
    }
  },
  data() {
    return {
      currentNews: [],
      MaxNews: this.newsList.length,
      NewsIndex: 0,

      activeComments: []
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner,
    "news-comments": NewsComments
  },
  methods: {
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    },
    UpdateCurrentNews() {
      const temp = [...this.newsList];
      this.currentNews = temp.splice(this.NewsIndex, MAX_NEWS);
      this.activeComments = [];
    },
    ValidatePrevious() {
      return this.NewsIndex == 0;
    },
    ValidateNext() {
      return this.NewsIndex + MAX_NEWS == this.MaxNews || this.MaxNews == 1;
    },
    NextPage() {
      // Prevent going over view limit
      if (this.ValidateNext()) return;

      // Ensure atleast 2 news is always displayed
      let newIndex = this.NewsIndex + MAX_NEWS;
      if (newIndex + MAX_NEWS >= this.MaxNews) newIndex -= 1;

      this.NewsIndex = newIndex;
      this.UpdateCurrentNews();
    },
    PreviousPage() {
      // Prevent going negative
      if (this.ValidatePrevious()) return;

      let newIndex = this.NewsIndex - MAX_NEWS;
      if (newIndex < 0) newIndex = 0;
      this.NewsIndex = newIndex;
      this.UpdateCurrentNews();
    },
    isFieldValid(field) {
      const result = this.$validator.fields.find({ name: field });
      return result.flags.valid;
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    },
    RouterLink(user) {
      this.$router.push(`/profile/${user}`);
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
      this.activeComments.push(id);
    },
    HideComments(id) {
      const index = this.activeComments.findIndex(x => x == id);
      if (index !== -1) {
        this.activeComments.splice(index, 1);
      }
    },
    IsCommentsHidden(id) {
      return this.activeComments.find(x => x == id) == null;
    }
  },
  created() {
    this.UpdateCurrentNews();
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

.no-padding-left {
  padding-left: 0px;
}

.no-padding-right {
  padding-right: 0px;
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

.btn.btn-signin {
  font-weight: bold;
  -moz-border-radius: 3px;
  -webkit-border-radius: 3px;
  border-radius: 3px;
  border: none;
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
  max-height: 300px;
  overflow: auto;
}
</style>
