<template>
  <div class="d-flex justify-content-center" v-if="isLoading" id="atom-spinner">
    <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'" />
  </div>
  <div v-else>
    <news-section :news="GetNews" />
  </div>
</template>

<script>
import News from "@/components/News/News";
import { SemipolarSpinner } from "epic-spinners";

export default {
  name: "News",
  data() {
    return {
      isLoading: false
    };
  },
  components: {
    "news-section": News,
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {
    GetNews() {
      return this.$store.getters["news/GetNews"];
    }
  },
  created() {
    if (this.$store.getters["news/GetNews"].length == 0) {
      this.isLoading = true;
      this.$store
        .dispatch("news/FetchNews")
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
