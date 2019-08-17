<template>
  <div>
    <div v-if="!IsCommentsLoading">
      <div v-for="comment in GetComments" :key="comment.id">
        <div class="card">
          <div class="card-header">
            <div class="text-left">
              <router-link
                :to="'/profile/' + comment.userName"
                style="float:left"
              >{{ comment.userName }}</router-link>
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
              :id="'newComment-' + news.id"
              :name="'new comment-' + news.id"
              v-model="newComment"
              v-validate="'required|min:10|max:200'"
              :class="{'form-control': true, 'error': errors.has('new comment-' + news.id) }"
              placeholder="New comment..."
              autofocus
            />
            <b-tooltip
              placement="auto"
              :target="'newComment-' + news.id"
            >{{ getErrorMsg('new comment-'+ news.id) }}</b-tooltip>
          </div>
          <div class="row">
            <button
              type="submit"
              @click="PostComment(news.id)"
              class="btn btn-signin btn-primary btn-block"
            >Submit Comment</button>
          </div>
        </div>
      </div>
    </div>
    <div v-else class="d-flex justify-content-center" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="100" :color="'#7289da'" />
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
      newComment: ""
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  created() {
    if (this.GetComments.length == 0) {
      this.$store.dispatch("GetNewsComments", this.news.id).then(result => {
        if (result != "success") {
          this.$toasted.error(result);
        }
      });
    }
  },
  computed: {
    IsCommentsLoading() {
      return this.$store.getters.GetNewsCommentsStatus(this.news.id);
    },
    GetComments() {
      return this.$store.getters.GetNewsComments(this.news.id);
    }
  },
  methods: {
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    },
    async isFieldValid(field) {
      const result = await this.$validator.validate(field);
      return result;
    },
    getErrorMsg(field) {
      const msg = this.errors.first(field);
      return msg ? msg.replace(/-[0-9]+/g, "") : "";
    },
    async PostComment(id) {
      if (!UserHelper.IsLoggedIn()) {
        this.$toasted.error("Please login to comment");
        return;
      }

      const isFieldValid = await this.isFieldValid("new comment-" + id);
      if (!isFieldValid) {
        return;
      }

      const { newComment } = this;
      const userId = this.$store.getters.GetUser.id;

      const result = await this.$store.dispatch("PostNewComment", {
        newsId: this.news.id,
        userId: userId,
        comment: newComment
      });

      if (result == "success") {
        this.$toasted.success("New comment submitted successfully");
      } else {
        this.$toasted.error(result);
      }

      this.newComment = "";
      document.getElementById(`newComment-${this.news.id}`).focus();
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
