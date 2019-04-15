<template>
  <div class="d-flex justify-content-center" v-if="!loaded" id="atom-spinner">
    <semipolar-spinner :animation-duration="3000" :size="200" :color="'#7289da'"/>
  </div>
  <div v-else>
    <news-section :newsList="newsList" :title="title"/>
  </div>
</template>

<script>
import News from "@/components/News";
import { NewsData } from "../../data/models/News";
import config from "@/config";
import { SemipolarSpinner } from "epic-spinners";

const NEWS_API = config.API_NEWS;

export default {
  name: "News",
  data() {
    return {
      newsList: [],
      loaded: false,
      title: config.VUE_APP_TITLE
    };
  },
  components: {
    "news-section": News,
    "semipolar-spinner": SemipolarSpinner
  },
  methods: {
    async GetNews() {
      const data = await this.$http.get(NEWS_API);
      return data.data;
    }
  },
  created() {
    this.GetNews()
        .then(data => (this.newsList = data))
        .catch(() => this.newsList.push(NewsData))
        .finally(() => (this.loaded = true));
  }
};
</script>

<style scoped lang="css">
#atom-spinner {
  margin-top: 40%;
}
</style>
