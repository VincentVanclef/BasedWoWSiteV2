<template>
  <footer class="footer-design">
    <b-card-footer class="text-center">
      <b-container class="bv-example-row">
        <b-row>
          <b-col>{{ title }}</b-col>
          <b-col>Footer Info</b-col>
          <b-col>Footer Info</b-col>
        </b-row>
      </b-container>
    </b-card-footer>
  </footer>
</template>

<script>
import config from '../config.js';

export default {
  data() {
    return {
      title: config.VUE_APP_TITLE
    };
  },
  methods: {
  },
  computed: {
    
  }
};
</script>

<style>
.footer-design {
  padding: 15px;
  background-color: #333;
  color: white;
}
</style>
