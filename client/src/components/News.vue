<template>
  <b-container>
    <b-row>
      <div v-for="news in currentNews" :key="news.id">
        <div class="col-md-12">
          <div class="row mb-2">
            <div class="col-md-12">
              <div class="card">
                <div class="card-body">
                  <div class="row">
                    <div class="col-md-3 no-padding-right">
                      <div id="avatar">
                        <img id="avatar-image" v-bind:src="news.image">
                      </div>
                    </div>
                    <div class="col-md-9 no-padding-left">
                      <div class="card-body">
                        <div class="news-info">
                          <div class="news-title">
                            <h3>{{ news.title }}</h3>
                            <hr>
                          </div>
                          <div class="news-content">
                            <article>{{ news.content }}</article>
                          </div>
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
      </div>
      <div class="col-md-12">
        <div class="row mb-2">
          <div class="col-md-12">
            <ul class="pagination">
              <li class="page-item">
                <button
                  class="btn btn-signin btn-primary btn-block"
                  v-bind:disabled="ValidatePrevious()"
                  @click="PreviousPage()"
                >Previous</button>
              </li>
              <li class="page-item col-2">
                <button
                  class="btn btn-signin btn-primary btn-block"
                  v-bind:disabled="ValidateNext()"
                  @click="NextPage()"
                >Next</button>
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
#avatar-image {
  width: 90%;
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
  height: 450px;
  width: 760px;
  background-color: transparent;
}

.card-footer {
  height: 50px;
}

.news-content {
  overflow: auto;
  height: 250px;
  white-space: pre-wrap;
}

.news-content::-webkit-scrollbar {
  width: 12px;
  background-color: #f5f5f5;
}

.news-content::-webkit-scrollbar-track {
  background-color: transparent;
}

.news-content::-webkit-scrollbar-thumb
{
	border-radius: 10px;
	-webkit-box-shadow: inset 0 0 6px rgba(0,0,0,1.3);
  box-shadow: inset 0 0 6px rgba(0,0,0,1.3);
	background-color: #7289da;
}

.col-md-12 {
  padding-left: 10px;
}

.btn.btn-signin {
  /* background-color: linear-gradient(rgb(104, 145, 162), rgb(12, 97, 33));*/
  font-weight: bold;
  font-size: 15px;
  height: 36px;
  -moz-border-radius: 3px;
  -webkit-border-radius: 3px;
  border-radius: 3px;
  border: none;
  margin-top: 6px;
}
</style>