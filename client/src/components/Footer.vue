<template>
  <footer class="footer-design">
    <b-card-footer class="text-center">
      <b-container class="bv-example-row">
        <b-row>
          <b-col>
            <b-row>
              <router-link to="/connect">How to Connect</router-link>
            </b-row>
            <b-row>
              <router-link to="/tos">Terms of Service</router-link>
            </b-row>
          </b-col>
          <b-col></b-col>
          <b-col>
            <b-row>{{ title }} &copy; 2019</b-row>
            <b-row>All rights reserved.</b-row>
          </b-col>
        </b-row>
      </b-container>
    </b-card-footer>
  </footer>
</template>

<script>
import config from "@/assets/config/config";

export default {
  data() {
    return {
      title: config.VUE_APP_TITLE
    };
  },
  methods: {},
  computed: {}
};
</script>

<style>
.footer-design {
  padding: 15px;
  background-color: #333;
  color: white;
}
</style>
