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
                      <li class="list-inline-item text-secondary comments" :title="IsCommentsHidden(news.id) ? 'Show Comments' : 'Hide Comments'" @click="ToggleCommentSection(news.id)">
                        <p><i class="fa fa-comment"></i>
                        Comments ({{ news.totalComments }})</p>
                      </li>
                    </ul>
                  </div>
                </div>
              </div>
              <div class="news-comments" v-if="!IsCommentsHidden(news.id)">
                <div v-for="comment in GetComments(news.id)">
                  <div class="card">
                    <div class="card-header">
                      <div class="text-left">
                          <a
                            :href="'/user/profile/?username=' + comment.username"
                            style="float:left"
                          >{{ comment.username }}</a>
                        </div>
                        <div class="text-right">
                          {{ GetDate(comment.date) }}
                        </div>
                    </div>
                    <div class="card-body">
                      {{ comment.comment }}
                    </div>
                  </div>
                </div>
                <div class="new-comment">
                  <div class="container">
                    <div class="row new-comment-text">
                      <b-textarea 
                        id="newComment"
                        name="new comment"
                        v-model="newComment"
                        v-validate="'required|min:30|max:200'"
                        :class="{'form-control': true, 'error': errors.has('new comment') }"
                        placeholder="New comment..."/>
                      <b-tooltip
                        placement="bottom"
                        target="newComment"
                      >{{ getErrorMsg('new comment') }}</b-tooltip>
                    </div>
                    <div class="row">
                      <button type="submit" @click="PostComment(news)" class="btn btn-signin btn-primary btn-block">Submit Comment</button>
                    </div>
                  </div>
                </div>
              </div>
              <div class="d-flex justify-content-center" v-if="IsCommentsLoading(news.id)" id="atom-spinner">
                <semipolar-spinner :animation-duration="2000" :size="100" :color="'#7289da'"/>
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
import moment from "moment";
import UserHelper from "../helpers/UserHelper.js";
import { SemipolarSpinner } from "epic-spinners";

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

      comments: [],
      loadComments: [],
      activeComments: 0,

      newComment: ""
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  methods: {
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
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
    },
    isFieldValid(field) {
      const result = this.$validator.fields.find({ name: field });
      return result.flags.valid;
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    },
    // COMMENTS
    async ToggleCommentSection(id) {
      if (this.IsCommentsLoading(id)) {
        return;
      }

      if (this.IsCommentsHidden(id)) {
        if (this.GetComments(id) == null) {
          await this.LoadComments(id);
        }

        this.ShowComments(id);
      } else {
        this.HideComments(id);
      }
    },
    IsCommentsLoading(id) {
      return this.loadComments.find(x => x == id) != null;
    },
    StartLoadingComments(id) {
      if (!this.IsCommentsLoading(id)) {
        this.loadComments.push(id);
      }
    },
    FinishedLoadingComments(id) {
      if (this.IsCommentsLoading(id)) {
        const index = this.loadComments.indexOf(id);
        if (index !== -1) {
          this.loadComments.splice(index, 1);
        }
      }
    },
    ShowComments(id) {
      this.newComment = "";
      this.activeComments = id;
    },
    HideComments(id) {
      this.activeComments = 0;
    },
    RemoveComments(id) {
      const index = this.comments.findIndex(x => x.newsId == id);
      if (index !== -1) {
        this.comments.splice(index, 1);
      }
    },
    IsCommentsHidden(id) {
      return this.activeComments != id;
    },
    GetComments(id) {
      let comments = this.comments.find(x => x.newsId == id);
      return comments == null ? null : comments.comments;
    },
    async LoadComments(id) {
      this.StartLoadingComments(id);

      let result;
      try {
        result = await this.$http.get(`${process.env.API.NEWS}/comments/${id}`);
      } catch (error) {
        this.$toasted.error(error);
        this.FinishedLoadingComments(id);
        return;
      }

      // Load commentator names
      for (const data of result.data) {
        const username = await this.GetUsernameById(data.UserId);
        data.username = username;
      }

      this.comments.push({ newsId: id, comments: result.data });
      this.FinishedLoadingComments(id);
    },
    async GetUsernameById(userid) {
      let result;
      try {
        result = await this.$http.post(`${process.env.API.AUTH}/getusername`, {
          UserId: userid
        });
      } catch (error) {
        this.$toasted.error(error);
        return;
      }

      return result.data.username;
    },
    async PostComment(news) {
      if (!UserHelper.IsLoggedIn()) {
        this.$toasted.error("Please login to comment");
        return;
      }

      if (!this.isFieldValid("new comment")) {
        return;
      }

      this.HideComments(news.id);
      this.StartLoadingComments(news.id);

      const { newComment } = this;
      const userId = this.$store.getters.GetUser.id;

      let result;
      try {
        result = await this.$http.post(`${process.env.API.NEWS}/comments/new`, {
          newsid: news.id,
          userid: userId,
          comment: newComment
        });
      } catch (error) {
        this.$toasted.error(error);
        return;
      }

      // Load commentator names
      for (const data of result.data) {
        const username = await this.GetUsernameById(data.UserId);
        data.username = username;
      }

      this.$store.commit("NEWS_UPDATE", {
        newsid: news.id,
        index: "totalComments",
        value: result.data.length
      });

      this.RemoveComments(news.id);
      this.comments.push({ newsId: news.id, comments: result.data });
      this.FinishedLoadingComments(news.id);
      this.ShowComments(news.id);
      this.newComment = "";

      this.$toasted.success("New comment submitted successfully");
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
  width: 0.5vw;
  background-color: #f5f5f5;
}

.news-content::-webkit-scrollbar-track,
.news-comments::-webkit-scrollbar-track {
  background-color: transparent;
}

.news-content::-webkit-scrollbar-thumb,
.news-comments::-webkit-scrollbar-thumb {
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

.comments:hover p {
  color: #786043;
  cursor: pointer;
}

#atom-spinner {
  margin-top: 1%;
}

.new-comment-text textarea {
  width: 100%;
  max-height: 100px;
}

.news-comments {
  margin-top: 5px;
  max-height: 300px;
  overflow: auto;
}

.new-comment {
  padding: 10px;
}

.new-comment .btn.btn-signin {
  margin-top: 5px;
  width: 30%;
}
</style>
