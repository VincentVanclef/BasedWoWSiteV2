<template>
  <b-container>
    <div class="d-flex justify-content-center" v-if="IsLoading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'"/>
    </div>
    <div v-else>
      <select class="form-control" v-model="SelectedNews" required @change="ChangeNews">
        <option>Select News</option>
        <option v-for="news in GetNews" :key="news.id" :value="news">{{ news.title }}</option>
      </select>

      <hr>

      <div v-if="typeof(SelectedNews) == 'object'">
        <div class="form-group">
          <label>News Title</label>
          <b-input type="text" class="form-control news-title" v-model="NewsTitle"></b-input>
        </div>
        <div class="form-group">
          <label>News Content</label>
          <b-textarea class="form-control news-content" v-model="NewsContent"></b-textarea>
        </div>
      </div>
    </div>
  </b-container>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

export default {
  data() {
    return {
      SelectedNews: "Select News",
      NewsTitle: "",
      NewsContent: ""
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {
    IsLoading() {
      return this.$store.getters.GetNewsStatus;
    },
    GetNews() {
      return this.$store.getters.GetNewsData;
    }
  },
  methods: {
    ChangeNews() {
      this.NewsTitle = this.SelectedNews.title;
      this.NewsContent = this.SelectedNews.content;
    }
  },
  created() {
    if (this.$store.getters.GetNewsData.length == 0) {
      this.$store.dispatch("GetNews").then(result => {
        if (result != "success") {
          this.$toasted.error(result);
        }
      });
    }
  }
};
</script>

<style scoped lang="css">
#atom-spinner {
  margin-top: 40%;
}

.news-content {
  min-height: 200px;
  max-height: 600px;
}
</style>
