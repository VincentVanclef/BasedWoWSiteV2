<template lang="html">
  <div class="container">
      <div v-for="news in currentNews" :key="news.id">
        <div class="col">
          <div class="row mb-2">
            <div class="card">
              <div class="card-body">
                <div class="row">
                  <div class="col-md-3 no-padding-right">
                    <div id="avatar">
                      <img class="news-avatar" v-bind:src="news.image">
                    </div>
                  </div>
                  <div class="col-md-9 no-padding-left">
                    <div class="news-info">
                      <div class="news-title">
                        <h3>{{ news.title }}</h3>
                        <hr>
                      </div>
                      <div class="news-content">
                        <article v-html="news.content"></article>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="card-footer">
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
        <div class="row">
            <ul class="pagination">
              <li class="page-item col-8">
                <button
                  class="btn btn-signin btn-primary btn-block"
                  v-bind:disabled="ValidatePrevious()"
                  @click="PreviousPage()"
                >Previous</button>
              </li>
              <li class="page-item col-8">
                <button
                  class="btn btn-signin btn-primary btn-block"
                  v-bind:disabled="ValidateNext()"
                  @click="NextPage()"
                >Next</button>
              </li>
            </ul>
      </div>
  </div>
</template>

<script>
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
  width: 100%;
  white-space: pre-wrap;
}

.news-content::-webkit-scrollbar {
  width: 2.5%;
  background-color: #f5f5f5;
}

.news-content::-webkit-scrollbar-track {
  background-color: transparent;
}

.news-content::-webkit-scrollbar-thumb {
  border-radius: 0.4vw;
  -webkit-box-shadow: inset 0 0 6px rgba(0, 0, 0, 1.3);
  box-shadow: inset 0 0 6px rgba(0, 0, 0, 1.3);
  background-color: #7289da;
}

.btn.btn-signin {
  font-weight: bold;
  -moz-border-radius: 3px;
  -webkit-border-radius: 3px;
  border-radius: 3px;
  border: none;
}
</style>
