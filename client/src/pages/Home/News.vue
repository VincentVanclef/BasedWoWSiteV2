<template>
  <div class="d-flex justify-content-center" v-if="isLoading" id="atom-spinner">
    <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'" />
  </div>
  <div v-else>
    <news-section :newsList="NewsList" />
  </div>
</template>

<script>
import News from "@/components/News/News";
import { NewsData } from "../../data/models/News";
import { SemipolarSpinner } from "epic-spinners";

export default {
  name: "News",
  data() {
    return {
      isLoading: true
    };
  },
  components: {
    "news-section": News,
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {
    NewsList() {
      if (this.$store.getters["news/GetNews"].length == 0) {
        return [NewsData];
      }
      return this.$store.getters["news/GetNews"];
    }
  },
  created() {
    if (this.$store.getters["news/GetNews"].length == 0) {
      this.$store
        .dispatch("news/FetchNews")
        .catch(error => this.$toasted.error(error))
        .finally(() => (this.isLoading = false));
    }
  }
};
</script>

<style scoped lang="css">
#atom-spinner {
  margin-top: 40%;
}
</style>
