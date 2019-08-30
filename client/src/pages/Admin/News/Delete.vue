<template>
  <div>
    <div class="d-flex justify-content-center" v-if="IsLoading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'" />
    </div>
    <div v-else>
      <select class="form-control" v-model="SelectedNews" required>
        <option disabled>Select News</option>
        <option v-for="(news, index) in News" :key="index" :value="news">{{ news.title }}</option>
      </select>

      <hr />

      <div v-if="typeof(SelectedNews) == 'object'">
        <div class="form-group">
          <h4 class="text-center">Delete News</h4>

          <div class="form-group">
            <label>News Title</label>
            <b-input type="text" class="form-control" :value="SelectedNews.title" disabled></b-input>
          </div>

          <div class="form-group">
            <label>News Content</label>
            <b-card no-body class="disabled">
              <b-card-body v-html="SelectedNews.content"></b-card-body>
            </b-card>
          </div>

          <div class="form-group">
            <label>News Author</label>
            <b-input type="text" class="form-control" :value="SelectedNews.authorName" disabled></b-input>
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

export default {
  props: ["user", "News"],
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

      const check = await this.$bvModal.msgBoxConfirm(
        `Continue deleting ${this.SelectedNews.title}?`,
        {
          centered: true,
          okTitle: "Yes"
        }
      );

      if (!check) return;

      this.IsLoading = true;

      try {
        const result = await this.$store.dispatch(
          "news/DeleteNews",
          this.SelectedNews.id
        );
      } catch (error) {
        this.$toasted.error(error);
        return;
      } finally {
        this.IsLoading = false;
      }

      this.SelectedNews = "Select News";
      this.$toasted.success(
        `${this.SelectedNews.title} has been deleted successfully`
      );
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

.disabled {
  background-color: #e9ecef;
  opacity: 1;
  font-weight: 400;
}
</style>
