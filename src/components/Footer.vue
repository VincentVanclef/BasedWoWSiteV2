<template>
  <footer class="footer-design">
    <b-card-footer class="text-center">
      <b-container class="bv-example-row">
        <b-row>
          <b-col>Footer Info</b-col>
          <b-col>Footer Info</b-col>
          <b-col>Footer Info</b-col>
        </b-row>
      </b-container>
    </b-card-footer>
  </footer>
</template>

<script>
export default {
  data() {
    return {};
  },
  methods: {
    getInfo() {
      return this.$test;
    }
  },
  computed: {}
};
</script>

<style>
.footer-design {
  margin-top: 20px;
  padding: 15px;
  background-color: #7289da;
  position: absolute;
  right: 0;
  bottom: 0;
  left: 0;
}
</style>
