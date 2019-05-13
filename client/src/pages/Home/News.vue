<template>
  <div class="d-flex justify-content-center" v-if="IsLoading" id="atom-spinner">
    <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'"/>
  </div>
  <div v-else>
    <news-section :newsList="NewsList"/>
  </div>
</template>

<script>
import News from "@/components/News/News";
import { NewsData } from "../../data/models/News";
import { SemipolarSpinner } from "epic-spinners";

export default {
  name: "News",
  data() {
    return {};
  },
  components: {
    "news-section": News,
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {
    IsLoading() {
      return this.$store.getters.GetNewsStatus;
    },
    NewsList() {
      if (this.$store.getters.GetNewsData.length == 0) {
        return [NewsData];
      }
      return this.$store.getters.GetNewsData;
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
</style>
