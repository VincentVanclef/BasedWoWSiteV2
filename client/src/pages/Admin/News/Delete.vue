<template>
  <div>
    <select class="form-control" v-model="SelectedNews" required @change="test">
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

        <button class="button update-account" @click="DeleteNews" name="delete">
          <i class="fa fa-trash"></i>
          <span>Delete News</span>
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ["User", "News"],
  name: "admin-news-delete",
  data() {
    return {
      SelectedNews: "Select News"
    };
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
    },
    test() {
      console.log(this.SelectedNews);
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
