<template lang="html">
  <b-container class="text-center">
    <div class="d-flex justify-content-center" v-if="IsLoading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'"/>
    </div>
    <div v-else>
      <div class="form-group">
        <b-row class="topsite-title">
          <b-col>Vote Site</b-col>
          <b-col>Value</b-col>
          <b-col>Time Left</b-col>
        </b-row>
      </div>
      <div v-for="site in VoteSites" :key="site.id">
        <b-row class="form-group card-footer">
          <b-col class="topsite-image">
            <img :src="require('@/assets/images/vote-sites/' + site.image)">
          </b-col>
          <b-col class="topsite-value">{{ site.value }} VP</b-col>
          <b-col class="topsite-button">
            <div v-if="GetTimeLeft(site.id) > 0">
              <button class="button">
                <i class="fa fa-hourglass-half"></i>
                <span>{{ GetTimer(site.id) }}</span>
              </button>
            </div>
            <div v-else>
              <button class="button" @click="Vote(site)" v-if="!site.loading">
                <i class="fa fa-arrow-circle-right"></i>
                <span>Vote Now</span>
              </button>
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
      UpdateTimer: null
    };
  },
  components: {
    "epic-spinner": HollowDotsSpinner,
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {
    VoteSites() {
      return this.$store.getters.GetVoteSites;
    },
    VoteTimers() {
      return this.$store.getters.GetVoteTimers;
    },
    IsLoading() {
      return this.$store.getters.GetVoteLoadStatus();
    }
  },
  methods: {
    async Vote(site) {
      site.loading = true;
      const result = await this.$store.dispatch("Vote", site);
      if (result == "success") {
        this.$toasted.success(
          `Succesfully voted for ${site.name}! You have been rewarded ${site.value} VP!`
        );
      } else {
        this.$toasted.error(result);
      }
      site.loading = false;
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
      this.$store.dispatch("GetVoteSites").then(result => {
        if (result != "success") {
          this.$toasted.error(result);
        }
      });
    }
    if (this.VoteTimers.length == 0) {
      this.$store.dispatch("GetVoteTimers").then(result => {
        if (result != "success") {
          this.$toasted.error(result);
        }
      });
    }

    this.UpdateTimer = setInterval(() => {
      this.$forceUpdate();
    }, 1000);
  },
  mounted() {},
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

.topsite-value {
  font-size: 20px;
  margin-left: 10px;
}

#atom-spinner {
  margin-top: 150px;
}

#epic-spinner {
  margin-top: 20px;
}
</style>
