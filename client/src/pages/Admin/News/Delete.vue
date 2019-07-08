<template>
  <div>
    <div class="d-flex justify-content-center" v-if="IsLoading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'"/>
    </div>
    <div v-else>
      <select class="form-control" v-model="SelectedNews" required>
        <option disabled>Select News</option>
        <option v-for="(news, index) in News" :key="index" :value="news">{{ news.title }}</option>
      </select>

      <hr>

      <div v-if="typeof(SelectedNews) == 'object'">
        <div class="form-group">
          <h4 class="text-center">Delete News</h4>

          <div class="form-group">
            <label>News Title</label>
            <b-input type="text" class="form-control" :value="SelectedNews.title" disabled></b-input>
          </div>

          <div class="form-group">
            <label>News Content</label>
            <b-textarea class="form-control news-content" :value="SelectedNews.content" disabled></b-textarea>
          </div>

          <div class="form-group">
            <label>News Author</label>
            <b-input type="text" class="form-control" :value="SelectedNews.author" disabled></b-input>
          </div>

          <button class="button update-account mb-3" @click="DeleteNews" name="delete">
            <i class="fa fa-trash"></i>
            <span>Delete News</span>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

const API_NEWS = process.env.API.NEWS;

export default {
  props: ["User", "News"],
  name: "admin-news-delete",
  data() {
    return {
      SelectedNews: "Select News",
      IsLoading: false
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  methods: {
    async isFormValid() {
      const result = await this.$validator.validateAll();
      return result;
    },
    async DeleteNews() {
      const formValid = await this.isFormValid();
      if (!formValid) {
        return;
      }

      try {
        await this.$dialog.confirm(
          `Continue deleting ${this.SelectedNews.title}?`
        );
      } catch (e) {
        return;
      }

      this.IsLoading = true;

      let result;

      try {
        result = await this.$http.post(`${API_NEWS}/delete`, {
          id: this.SelectedNews.id
        });
      } catch (error) {
        this.$toasted.error(error);
        return;
      } finally {
        this.IsLoading = false;
      }

      if (result.data == "success") {
        this.$toasted.success(
          `${this.SelectedNews.title} has been deleted successfully`
        );
        this.$store.commit("NEWS_DELETE", this.SelectedNews);
      } else {
        this.$toasted.error(result.data);
      }

      this.SelectedNews = "Select News";
    }
  }
};
</script>

<style scoped>
#atom-spinner {
  margin-top: 40%;
}

.news-content {
  min-height: 200px;
  max-height: 600px;
}
</style>
