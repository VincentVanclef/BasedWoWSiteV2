<template lang="html">
  <div class="main-content" v-bind:style="{backgroundImage: 'url(' + avatar + ')' }">
    <keep-alive>
        <router-view :user="User" v-if="Loaded && User != null"></router-view>
    </keep-alive>
    <div v-if="!Loaded" class="d-flex justify-content-center" style="margin-top: 40%">
    <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'"/>
    </div>

    <div class="container" v-if="Failed">
        <h4 >There is no user with the name of '<b>{{ GetUserName}}</b>'. Try verify your search is correct.</h4>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

const API_AUTH = process.env.API.AUTH;

export default {
  name: "view-user-profile",
  props: ["avatar"],
  data() {
    return {
      User: null,
      Loaded: false,
      Failed: false
    };
  },
  methods: {
    GetUser() {
      this.$store.commit("UPDATE_PAGE_TITLE", this.GetUserName + "'s Profile");

      this.Loaded = true;

      this.$http
        .get(`${API_AUTH}/GetUserByUsername/${this.GetUserName}`)
        .then(result => {
          this.User = result.data;
          this.Failed = false;
        })
        .catch(error => {
          this.Failed = true;
          this.$toasted.error(error.response.data.message);
        })
        .finally(() => (this.Loaded = true));
    }
  },
  computed: {
    GetUserName() {
      return this.$route.params.username;
    }
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  created() {
    this.GetUser();
  },
  watch: {
    $route(to, from) {
      this.GetUser();
    }
  }
};
</script>
