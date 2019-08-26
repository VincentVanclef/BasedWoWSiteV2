<template lang="html">
  <b-container class="text-center">
    <div class="form-group">
      <b-row class="topsite-title">
        <b-col><h4>Top Site</h4></b-col>
        <b-col><h4>Value</h4></b-col>
        <b-col><h4>Time Left</h4></b-col>
      </b-row>
    </div>
    <div class="d-flex justify-content-center" v-if="isLoading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'" />
    </div>
    <div v-for="site in VoteSites" :key="site.id">
      <b-row class="form-group card-footer">
        <b-col sm="12" md="4" lg="4" class="">
          <img :src="require('@/assets/images/vote-sites/' + site.image)">
        </b-col>
        <b-col sm="12" md="4" lg="4"><h5>{{ site.value }} VP</h5></b-col>
        <b-col sm="12" md="4" lg="4">
          <div v-if="GetTimeLeft(site.id) > 0">
            <b-button variant="warning" class="rounded-pill font-weight-bold">
              <i class="fa fa-hourglass-half"></i>
              {{ GetTimer(site.id) }}
            </b-button>
          </div>
          <div v-else>
            <b-button variant="warning" class="rounded-pill font-weight-bold" @click="Vote(site)" v-if="!site.isLoading">
              <i class="fa fa-arrow-circle-right"></i>
              Vote Now
            </b-button>
            <div v-else>
              <epic-spinner
                :animation-duration="1500"
                :size="50"
                :color="'#7289da'"
                id="epic-spinner"
              />
            </div>
          </div>
        </b-col>
      </b-row>
    </div>
  </b-container>
</template>

<script>
import { HollowDotsSpinner, SemipolarSpinner } from "epic-spinners";
import moment from "moment";

export default {
  name: "VotePanel",
  data() {
    return {
      UpdateTimer: null,
      isLoading: false
    };
  },
  components: {
    "epic-spinner": HollowDotsSpinner,
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {
    VoteSites() {
      return this.$store.getters["vote/GetVoteSites"];
    },
    VoteTimers() {
      return this.$store.getters["vote/GetVoteTimers"];
    }
  },
  methods: {
    async Vote(site) {
      this.$store.commit("vote/VoteRequestStart", site.id);
      try {
        const result = await this.$store.dispatch("vote/Vote", site);
      } catch (e) {
        this.$toasted.error(e);
        return;
      } finally {
        this.$store.commit("vote/VoteRequestFinish", site.id);
      }

      await this.$store.dispatch("vote/FetchTopVoters");

      this.$toasted.success(
        `Succesfully voted for ${site.name}! You have been rewarded ${site.value} VP!`
      );
    },
    GetTimer(id) {
      let timer = this.GetSiteTimer(id);
      if (timer == 0) {
        return 0;
      }

      const then = moment(timer * 1000);
      const now = moment();
      return moment.utc(moment(then).diff(moment(now))).format("HH:mm:ss");
    },
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
      const diff = timer - now;
      return diff > 0 ? diff : 0;
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
      this.isLoading = true;

      this.$store
        .dispatch("vote/FetchVoteSites")
        .catch(e => this.$toasted.error(this.$root.GetErrorMessage(e)))
        .finally(() => (this.isLoading = false));
    }

    if (this.VoteTimers.length == 0) {
      this.isLoading = true;

      this.$store
        .dispatch("vote/FetchVoteTimers")
        .catch(e => this.$toasted.error(this.$root.GetErrorMessage(e)))
        .finally(() => (this.isLoading = false));
    }

    this.UpdateTimer = setInterval(() => {
      this.$forceUpdate();
    }, 1000);
  },
  beforeDestroy() {
    // Prevent memory leaks
    clearInterval(this.UpdateTimer);
  }
};
</script>

<style scoped>
.topsite-title {
  margin-left: 5px;
}

#atom-spinner {
  margin-top: 150px;
}

#epic-spinner {
  margin-top: 20px;
}
</style>
