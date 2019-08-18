<template>
  <div class>
    <div v-if="!IsCommentsLoading">
      <div v-for="comment in GetComments" :key="comment.id">
        <b-card bg-variant="dark" text-variant="white">
          <div slot="header">
            <router-link
              :to="'/profile/' + comment.userName"
              style="float:left"
            >{{ comment.userName }}</router-link>
          </div>
          <b-card-text>With supporting text below as a natural lead-in to additional content.</b-card-text>
        </b-card>
        <!--<div class="card border-secondary">
          <div class="card-header">
            <div class="text-left">
              <router-link
                :to="'/profile/' + comment.userName"
                style="float:left"
              >{{ comment.userName }}</router-link>
            </div>
            <div class="text-right">{{ GetDate(comment.date) }}</div>
            <div class="text-right">
              <i class="fa fa-trash"></i>
            </div>
          </div>
          <div class="card-body">{{ comment.comment }}</div>
        </div>-->
      </div>

      <b-container class="mt-2">
        <b-row>
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
        </b-row>
        <b-row>
          <b-col lg="4" class="pl-0 pb-2 mt-2">
            <b-button variant="primary" @click="PostComment(news.id)">Submit Comment</b-button>
          </b-col>
        </b-row>
      </b-container>
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
