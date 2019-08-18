<template lang="html">
  <b-container>
    <news-nav></news-nav>
    <keep-alive>
      <div class="d-flex justify-content-center" v-if="isLoading" id="atom-spinner">
        <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'"/>
      </div>
      <router-view v-if="!isLoading" v-bind:User="User" :Admins="Admins" :News="GetNews"></router-view>
    </keep-alive>
  </b-container>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";
import NewsNav from "@/components/Admin/News/Nav";

export default {
  name: "admin-panel-news",
  props: ["User", "Admins"],
  data() {
    return {
      isLoading: false
    };
  },
  components: {
    "news-nav": NewsNav,
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
        .catch(error => this.$toasted.error(error))
        .finally(() => (this.isLoading = false));
    }
  }
};
</script>

<style scoped>
#atom-spinner {
  margin-top: 40%;
}
</style>
