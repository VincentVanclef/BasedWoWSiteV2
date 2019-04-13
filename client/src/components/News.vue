<template>
  <b-container>
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
                                {{ data.date }}
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
                <button class="page-link" @click="previousPage">Previous</button>
              </li>
              <li class="page-item">
                <button class="page-link" @click="nextPage">Next</button>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </b-row>
  </b-container>
</template>

<script>
import config from "../config.js";

const NEWS_API = config.API_NEWS;
const NEWS_LIST_MAX = 2;
let   MAX_NEWS = 0;

export default {
  data() {
    return {
      newsData: {
        id: Number,
        title: String,
        content: String,
        author: String,
        date: Date
      },

      news: [],
      newsView: [],
      newsIndex: 0,

      title: ""
    };
  },
  methods: {
    async GetNews() {
      const data = await this.$http.get(NEWS_API);
      return data.data;
    },
    previousPage() {
        if (this.newsIndex == 0)
            return;

        let newIndex = this.newsIndex - NEWS_LIST_MAX;
        if (newIndex < 0)
            newIndex = 0;
    
        this.newsIndex = newIndex;
        const temp = [...this.news];
        this.newsView = temp.splice(newIndex, NEWS_LIST_MAX);
    },
    nextPage() {
        // Prevent going over view limit
        if (this.newsIndex + NEWS_LIST_MAX == MAX_NEWS)
            return;

        // Ensure atleast 2 news is always displayed
        let newIndex = this.newsIndex + NEWS_LIST_MAX;
        if (newIndex + NEWS_LIST_MAX >= MAX_NEWS)
            newIndex -= 1;
    
        this.newsIndex = newIndex;
        const temp = [...this.news];
        this.newsView = temp.splice(newIndex, NEWS_LIST_MAX);
    }
  },
  created() {
    this.GetNews().then(data => {
      this.news = data;
      this.newsView = data.slice(0, NEWS_LIST_MAX);
      MAX_NEWS = this.news.length;
    });

    this.title = config.VUE_APP_TITLE;
  }
};
</script>

<style scoped>
img {
  width: 100%;
}
</style>
