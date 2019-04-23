<template>
  <div class="container">
    <div class="d-flex justify-content-center" v-if="!VoteStatus" id="atom-spinner">
      <semipolar-spinner :animation-duration="3000" :size="250" :color="'#7289da'"/>
    </div>
    <div v-else>
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
            <div v-if="GetTimeLeft(site.id) > 0">
              <button class="button">
                <i class="fa fa-hourglass-half"></i>
                <span>{{ GetTime(site.id) }}</span>
              </button>
            </div>
            <div v-else>
              <button class="button">
                <i class="fa fa-arrow-circle-right"></i>
                <span>Vote Now</span>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

export default {
  props: ["User"],
  data() {
    return {};
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {
    VoteSites() {
      return this.$store.getters.GetVoteSites;
    },
    VoteTimers() {
      return this.$store.getters.GetVoteTimers;
    },
    VoteStatus() {
      return this.$store.getters.GetVoteStatus;
    }
  },
  methods: {
    GetSiteTimer(id) {
      const site = this.VoteTimers.find(timer => timer.site == id);
      return site ? site.unsetTimer : 0;
    },
    GetTimeLeft(id) {
      const timer = this.GetSiteTimer(id);
      if (timer == 0) {
        return 0;
      }
      const now = Math.floor(Date.now() / 1000);
      const diff = Math.abs(timer - now);
      return diff;
    },
    GetTime(id) {
      const timeLeft = this.GetTimeLeft(id);
      const hours = Math.floor(timeLeft / 3600) % 24;
      const minutes = Math.floor(timeLeft / 60) % 60;
      const seconds = timeLeft % 60;
      return [hours, minutes, seconds]
        .map(v => (v < 10 ? "0" + v : v))
        .filter((v, i) => v !== "00" || i > 0)
        .join(":");
    }
  },
  created() {
    if (this.VoteSites.length == 0) {
      this.$store.dispatch("GetVoteSites");
    }
    if (this.VoteTimers.length == 0) {
      this.$store.dispatch("GetVoteTimers");
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

#atom-spinner {
  margin-top: 40%;
}
</style>
