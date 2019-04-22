<template>
  <div class="container">
    <div class="form-group">
      <div class="row topsite-title">
        <div class="col">Vote Site</div>
        <div class="col">Value</div>
        <div class="col">Time Left</div>
      </div>
    </div>
    <div v-for="site in VoteSites" :key="site.id">
      <div class="row form-group card-footer">
        <div class="col topsite-image">
          <img :src="'/static/vote-sites/' + site.image">
        </div>
        <div class="col topsite-value">{{ site.value }} VP</div>
        <div class="col topsite-button">
          <button class="button">
            <i class="fa fa-arrow-circle-right" ></i>
            <span>Vote Now</span>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ["User"],
  data() {
    return {};
  },
  computed: {
    VoteSites() {
      return this.$store.getters.GetVoteSites;
    }
  },
  methods: {},
  created() {
    if (this.VoteSites.length == 0) {
      this.$store.dispatch("GetVoteSites");
    }
  },
  mounted() {}
};
</script>

<style scoped>

.topsite-title {
    margin-left: 5px;
}

.topsite-image img {
    height: 60px;
    width: 100px;
}

.topsite-value {
    font-size: 20px;
    margin-left: 10px;
}
</style>
