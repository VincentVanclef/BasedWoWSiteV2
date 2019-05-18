<template lang="html">
  <b-container>
    <news-nav></news-nav>
    <keep-alive>
      <div class="d-flex justify-content-center" v-if="IsLoading" id="atom-spinner">
        <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'"/>
      </div>
      <router-view v-if="!IsLoading" v-bind:User="User" :Admins="Admins" :News="GetNews"></router-view>
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
      Loading: true
    };
  },
  components: {
    "news-nav": NewsNav,
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
  methods: {},
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

<style scoped>
#atom-spinner {
  margin-top: 40%;
}
</style>
