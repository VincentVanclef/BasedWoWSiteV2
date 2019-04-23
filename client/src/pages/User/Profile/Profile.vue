<template>
  <div class="container">
    <div class="row header">
      <img class="header-image" src="https://coverfiles.alphacoders.com/867/8678.jpg">
      <div class="header-title">
        <h2>{{ User.firstname + " " + User.lastname }}</h2>
      </div>
    </div>
    <hr>
    <article class="profile">
      <div class="row">
        <div class="form-group">
          <h4>More stuff coming soon here.</h4>
        </div>
      </div>
    </article>
  </div>
</template>

<script>
export default {
  props: ["User"],
  data() {
    return {};
  },
  methods: {},
  created() {}
};
</script>

<style scoped>
.header {
  position: relative;
}

.header-title {
  position: absolute;
  margin-top: 250px;
  margin-left: 5px;
  color: lightblue;
}

.header-title h2 {
  font-size: 65px;
  font-family: "Roboto Slab";
}

.header-image {
  width: 100%;
  border-radius: 8px;
  box-shadow: 4px 6px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}

</style>
