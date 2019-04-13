<template>
  <b-container>
    <div class="d-flex justify-content-center" v-if="!loaded" id="atom-spinner">
      <atom-spinner :animation-duration="3000" :size="200" :color="'#7289da'"/>
    </div>
    <div v-else>
      <b-row>
        <b-col>
          <h2>News</h2>
          <p>
            Find all the news about
            <strong>{{ title }}</strong>
          </p>
        </b-col>
      </b-row>
      <b-row>
        <div v-for="data in newsView" :key="data.id">
          <div class="col-md-12">
            <div class="row mb-2">
              <div class="col-md-12">
                <div class="card">
                  <div class="card-body">
                    <div class="row">
                      <div class="col-md-3">
                        <img v-bind:src="data.image">
                      </div>
                      <div class="col-md-9">
                        <div class="card-body">
                          <div class="news-content">
                            <h2>{{ data.title }}</h2>
                            <p>{{ data.content }}</p>
                          </div>
                          <div class="news-footer">
                            <div class="news-author">
                              <ul class="list-inline list-unstyled">
                                <li class="list-inline-item text-secondary">
                                  <i class="fa fa-user"></i>
                                  {{ data.author }}
                                </li>
                                <li class="list-inline-item text-secondary">
                                  <i class="fa fa-eye"></i>
                                  110 Views
                                </li>
                                <li class="list-inline-item text-secondary">
                                  <i class="fa fa-calendar"></i>
                                  {{ GetDate(data.date) }}
                                </li>
                              </ul>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-12">
          <div class="row mb-2">
            <div class="col-md-12">
              <ul class="pagination">
                <li class="page-item">
                  <button
                    class="page-link"
                    v-bind:disabled="checkPrevious()"
                    @click="previousPage"
                  >Previous</button>
                </li>
                <li class="page-item">
                  <button class="page-link" v-bind:disabled="checkNext()" @click="nextPage">Next</button>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </b-row>
    </div>
  </b-container>
</template>

<script>
import config from "../config.js";
import { AtomSpinner } from "epic-spinners";

const NEWS_API = config.API_NEWS;
const NEWS_LIST_MAX = 2;
let MAX_NEWS = 0;

export default {
  data() {
    return {
      newsData: {
        id: 1,
        title: "Error loading news",
        content: "We apologize, but something went wrong with the remote server and we were unable to load the news. Please try again later.",
        author: "Vincent Vanclef",
        date: new Date(),
        image: "https://avatarfiles.alphacoders.com/150/150696.jpg"
      },

      loaded: false,

      news: [],
      newsView: [],
      newsIndex: 0,

      title: config.VUE_APP_TITLE
    };
  },
  components: {
    AtomSpinner
  },
  methods: {
    async GetNews() {
      const data = await this.$http.get(NEWS_API);
      return data.data;
    },
    checkNext() {
      let result = this.newsIndex + NEWS_LIST_MAX == MAX_NEWS;
      if (this.news.length == 0) {
        result = true;
      }
      return result;
    },
    checkPrevious() {
      let result = this.newsIndex == 0;
      return result;
    },
    GetDate(date) {
      if (typeof date === "string") {
        const options = {
          year: "numeric",
          month: "numeric",
          day: "numeric",
          hour: "numeric",
          minute: "numeric",
          second: "numeric"
        };

        const newdate = new Date(date);
        return new Intl.DateTimeFormat("it-IT", options).format(newdate);
      }
      return date.toLocaleString();
    },
    previousPage() {
      if (this.checkPrevious()) return;

      let newIndex = this.newsIndex - NEWS_LIST_MAX;
      if (newIndex < 0) newIndex = 0;

      this.newsIndex = newIndex;
      const temp = [...this.news];
      this.newsView = temp.splice(newIndex, NEWS_LIST_MAX);
    },
    nextPage() {
      // Prevent going over view limit
      if (this.checkNext()) return;

      // Ensure atleast 2 news is always displayed
      let newIndex = this.newsIndex + NEWS_LIST_MAX;
      if (newIndex + NEWS_LIST_MAX >= MAX_NEWS) newIndex -= 1;

      this.newsIndex = newIndex;
      const temp = [...this.news];
      this.newsView = temp.splice(newIndex, NEWS_LIST_MAX);
    }
  },
  computed: {},
  created() {
    this.GetNews()
      .then(data => {
        this.news = data;
        this.newsView = data.slice(0, NEWS_LIST_MAX);
        MAX_NEWS = this.news.length;
      })
      .catch(() => this.newsView.push(this.newsData))
      .finally(() => (this.loaded = true));
  }
};
</script>

<style scoped lang="css">
img {
  width: 100%;
}

#atom-spinner {
  margin-top: 40%;
}
</style>
