<template>
  <div>
    <div v-if="!IsCommentsLoading">
      <div v-for="comment in GetComments" :key="comment.id">
        <div class="card">
          <div class="card-header">
            <div class="text-left">
              <a
                :href="'/user/profile/?username=' + comment.username"
                style="float:left"
              >{{ comment.username }}</a>
            </div>
            <div class="text-right">{{ GetDate(comment.date) }}</div>
          </div>
          <div class="card-body">{{ comment.comment }}</div>
        </div>
      </div>
      <div class="new-comment">
        <div class="container">
          <div class="row">
            <b-textarea
              id="newComment"
              name="new comment"
              v-model="newComment"
              v-validate="'required|min:30|max:200'"
              :class="{'form-control': true, 'error': errors.has('new comment') }"
              placeholder="New comment..."
            />
            <b-tooltip placement="bottom" target="newComment">{{ getErrorMsg('new comment') }}</b-tooltip>
          </div>
          <div class="row">
            <button
              type="submit"
              @click="PostComment()"
              class="btn btn-signin btn-primary btn-block"
            >Submit Comment</button>
          </div>
        </div>
      </div>
    </div>
    <div v-else class="d-flex justify-content-center" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="100" :color="'#7289da'"/>
    </div>
  </div>
</template>

<script>
import UserHelper from "../../helpers/UserHelper";
import moment from "moment";
import { SemipolarSpinner } from "epic-spinners";

export default {
  props: ["news"],
  data() {
    return {
      comments: [],
      isLoading: false,

      newComment: ""
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  created() {
    if (this.GetComments.length == 0) {
      this.LoadComments();
    }
  },
  computed: {
    IsCommentsLoading() {
      return this.isLoading;
    },
    GetComments() {
      return this.comments;
    }
  },
  methods: {
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    },
    isFieldValid(field) {
      const result = this.$validator.fields.find({ name: field });
      return result.flags.valid;
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    },
    StartLoadingComments() {
      this.isLoading = true;
    },
    FinishedLoadingComments() {
      this.isLoading = false;
    },
    RemoveComments() {
      this.comments = [];
    },

    async LoadComments() {
      this.StartLoadingComments();

      let result;
      try {
        result = await this.$http.get(
          `${process.env.API.NEWS}/comments/${this.news.id}`
        );
      } catch (error) {
        this.$toasted.error(error);
        this.FinishedLoadingComments();
        return;
      }

      // Load commentator names
      for (const data of result.data) {
        const username = await this.GetUsernameById(data.UserId);
        data.username = username;
      }

      this.comments = result.data;
      this.FinishedLoadingComments();
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
    async PostComment() {
      if (!UserHelper.IsLoggedIn()) {
        this.$toasted.error("Please login to comment");
        return;
      }

      if (!this.isFieldValid("new comment")) {
        return;
      }

      this.StartLoadingComments();

      const { newComment } = this;
      const userId = this.$store.getters.GetUser.id;

      let result;
      try {
        result = await this.$http.post(`${process.env.API.NEWS}/comments/new`, {
          newsid: this.news.id,
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
        newsid: this.news.id,
        index: "totalComments",
        value: result.data.length
      });

      this.RemoveComments();
      this.comments = result.data;
      this.newComment = "";
      this.FinishedLoadingComments();

      this.$toasted.success("New comment submitted successfully");
    }
  }
};
</script>

<style scoped>
#atom-spinner {
  margin-top: 1%;
}

.new-comment {
  padding: 10px;
}

.new-comment textarea {
  width: 100%;
  min-height: 50px;
  max-height: 100px;
}

.new-comment .btn.btn-signin {
  margin-top: 5px;
  width: 30%;
}
</style>
