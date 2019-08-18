<template>
  <div class>
    <div v-if="!IsLoading">
      <div v-for="comment in Comments" :key="comment.id">
        <b-card
          header-bg-variant="secondary"
          header-text-variant="dark"
          body-bg-variant="secondary"
          body-text-variant="dark"
          footer-bg-variant="secondary"
          footer-text-variant="dark"
          border-variant="secondary"
          class="mb-2"
        >
          <div slot="header">
            <router-link
              class="float-left text-dark"
              :to="'/profile/' + comment.authorName"
            >{{ comment.authorName }}</router-link>
            <div class="text-right">{{ GetDate(comment.date) }}</div>
          </div>
          <b-card-text>{{ comment.comment}}</b-card-text>

          <div slot="footer" v-if="IsCommentOwner(comment.author)">
            <small>
              <ul class="list-inline list-unstyled mb-0 float-right">
                <li class="list-inline-item click-able">
                  <i class="fa fa-edit"></i> Edit Comment
                </li>
                <li class="list-inline-item click-able" @click="DeleteComment(comment)">
                  <i class="fa fa-trash"></i> Delete Comment
                </li>
              </ul>
            </small>
          </div>
        </b-card>
      </div>

      <b-container class>
        <b-row>
          <b-textarea
            :id="'newComment-' + NewsId"
            :name="'new comment-' + NewsId"
            v-model="newComment"
            v-validate="'required|min:10|max:200'"
            :class="{'form-control': true, 'error': errors.has('new comment-' + NewsId) }"
            placeholder="New comment..."
            autofocus
          />
          <b-tooltip
            placement="auto"
            :target="'newComment-' + NewsId"
          >{{ getErrorMsg('new comment-'+ NewsId) }}</b-tooltip>
        </b-row>
        <b-row>
          <b-col lg="4" class="pl-0 pb-2 mt-2">
            <b-button variant="primary" @click="PostComment(NewsId)">Submit Comment</b-button>
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
      IsLoading: false,
      newComment: ""
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  created() {},
  computed: {
    Comments() {
      return this.news.comments;
    },
    NewsId() {
      return this.news.id;
    },
    User() {
      return this.$store.getters.GetUser;
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

      this.IsLoading = true;

      try {
        const result = this.$store.dispatch("news/AddComment", {
          newsId: this.NewsId,
          comment: this.newComment
        });
        this.newComment = "";
        this.$toasted.success("New comment submitted successfully");
      } catch (e) {
        this.$toasted.error(e);
      } finally {
        this.IsLoading = false;
        document.getElementById(`newComment-${this.NewsId}`).focus();
      }
    },
    async DeleteComment(comment) {
      if (!UserHelper.IsLoggedIn()) {
        this.$toasted.error("Please login to delete comments");
        return;
      }

      try {
        await this.$dialog.confirm(
          "Are you sure you wish to delete this comment?"
        );
      } catch (e) {
        return;
      }

      try {
        const result = await this.$store.dispatch("news/DeleteComment", {
          newsId: comment.newsId,
          commentId: comment.id
        });
        this.$toasted.success("Comment successfully deleted");
      } catch (e) {
        this.$toasted.error(e);
      } finally {
        this.IsLoading = false;
      }
    },
    IsCommentOwner(userId) {
      return UserHelper.Equals(userId) || UserHelper.IsAdmin();
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

textarea {
  height: 50px;
  min-height: 50px;
  max-height: 100px;
}
</style>
