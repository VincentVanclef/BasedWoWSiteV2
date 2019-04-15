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
        <div v-for="news in currentNews" :key="news.id">
          <div class="col-md-12">
            <div class="row mb-2">
              <div class="col-md-12">
                <div class="card">
                  <div class="card-body">
                    <div class="row">
                      <div class="col-md-3">
                        <img v-bind:src="news.image">
                      </div>
                      <div class="col-md-9">
                        <div class="card-body">
                          <div class="news-content">
                            <h2>{{ news.title }}</h2>
                            <p>{{ news.content }}</p>
                          </div>
                          <div class="news-footer">
                            <div class="news-author">
                              <ul class="list-inline list-unstyled">
                                <li class="list-inline-item text-secondary">
                                  <i class="fa fa-user"></i>
                                  {{ news.author }}
                                </li>
                                <li class="list-inline-item text-secondary">
                                  <i class="fa fa-eye"></i>
                                  110 Views
                                </li>
                                <li class="list-inline-item text-secondary">
                                  <i class="fa fa-calendar"></i>
                                  {{ GetDate(news.date) }}
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
                  <button class="page-link"
                          v-bind:disabled="ValidatePrevious()"
                          @click="PreviousPage()">Previous</button>
                </li>
                <li class="page-item">
                  <button class="page-link"
                          v-bind:disabled="ValidateNext()" 
                          @click="NextPage()">Next</button>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </b-row>
  </b-container>
</template>

<script>
const MAX_NEWS = 2;

export default {
  props: {
    newsList: {
      type: Array
    },
    title: {
      type: String
    }
  },
  data() {
    return {
      currentNews: [],
      MaxNews: this.newsList.length,
      NewsIndex: 0
    };
  },
  methods: {
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
    UpdateCurrentNews() {
      const temp = [...this.newsList];
      this.currentNews = temp.splice(this.NewsIndex, MAX_NEWS);
    },
    ValidatePrevious() {
      return this.NewsIndex == 0;
    },
    ValidateNext() {
      return this.NewsIndex + MAX_NEWS == this.MaxNews;
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
  },
  created() {
    this.UpdateCurrentNews();
  }
};
</script>

<style scoped lang="css">
img {
  width: 100%;
}
</style>