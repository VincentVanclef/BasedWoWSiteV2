<template>
  <div class="main-content" v-bind:style="{backgroundImage: 'url(' + avatar + ')' }">
    <router-view :user="User" :realms="realms" v-if="Loaded && User != null"></router-view>
    <div v-if="!Loaded" class="d-flex justify-content-center" style="margin-top: 40%">
      <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'" />
    </div>

    <div class="container" v-if="Failed">
      <h4>
        There is no user with the name of '
        <b>{{ GetUserName}}</b>'. Try verify your search is correct.
      </h4>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

const API_AUTH = process.env.API.AUTH;

export default {
  name: "view-user-profile",
  props: ["avatar", "realms"],
  data() {
    return {
      User: null,
      Loaded: false,
      Failed: false
    };
  },
  methods: {
    GetUser() {
      this.$store.commit("UpdatePageTitle", this.GetUserName + "'s Profile");

      this.User = null;
      this.Loaded = true;

      this.$http
        .get(`${API_AUTH}/GetUserByUsername/${this.GetUserName}`)
        .then(result => {
          this.User = result.data;
          this.Failed = false;
        })
        .catch(() => (this.Failed = true))
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
