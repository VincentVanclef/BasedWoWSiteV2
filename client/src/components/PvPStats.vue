<template>
  <div class="card rounded" style="margin-bottom: 20px">
    <div class="card-body">
      <h5 class="card-title text-center mb-4 mt-1">PvP Statistics</h5>
      <hr class="hr-style" />
      <router-link to="/pvpstats">
        <img class="pvp-image" :src="require('@/assets/images/pvpstats.png')" />
      </router-link>
    </div>
  </div>
</template>

<script>
import config from "@/assets/config/config";

export default {
  name: "TopPvPPanel",
  data() {
    return {};
  },
  computed: {
    Realms() {
      return config.REALMS;
    },
    TopHKPlayers() {
      return this.$store.getters["stats/GetTopHKPlayers"];
    }
  },
  created() {}
};
</script>

<style scoped>
.pvp-image {
  width: 100%;
}
</style>


