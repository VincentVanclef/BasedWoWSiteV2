<template lang="html">
  <div class="main-content" v-bind:style="{backgroundImage: 'url(' + avatar + ')' }">
    <keep-alive>
      <router-view :user="User" v-if="Loaded"></router-view>
      <div class="d-flex justify-content-center" v-else id="atom-spinner">
        <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'"/>
      </div>
    </keep-alive>
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
      Loaded: false
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  created() {
    const username = this.$route.params.username;

    this.$http
      .get(`${API_AUTH}/GetUserByUsername/${username}`)
      .then(result => {
        this.User = result.data;
        const pageTitle = `Viewing ${this.User.username}'s Profile`;
        this.$route.meta.title = pageTitle;
        this.$root.$emit("ChangePageTitle", pageTitle);
      })
      .catch(error => this.$toasted.error(error.response.data.message))
      .finally(() => (this.Loaded = true));
  }
};
</script>

<style>
#atom-spinner {
  margin-top: 40%;
}
</style>