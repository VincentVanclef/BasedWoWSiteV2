<template>
  <div class="card rounded" style="margin-bottom: 20px">
    <div class="card-body">
      <h5 class="card-title text-center mb-4 mt-1">Weekly Top Voters</h5>
      <hr class="border-dark" />
      <div v-if="isLoading" class="d-flex justify-content-center mb-2 mt-4">
        <b-spinner variant="dark" label="Spinning"></b-spinner>
      </div>
      <div v-else>
        <div v-for="(voter, index) in TopVoters" :key="voter.userName">
          <div class="toppvp_character">
            <div style="float:right">{{ voter.total }} votes</div>
            <b>{{ index + 1 }}</b>
            <router-link
              class="text-capitalize"
              :to="'/profile/' + voter.userName"
              v-contextmenu.member="{ User: voter }"
            >{{ voter.userName }}</router-link>
          </div>
        </div>
      </div>
    </div>
    <div class="card-footer" v-if="TopVoter != null">
      <div class="text-center">Lifetime Top Voter:</div>
      <router-link
        class="text-capitalize"
        :to="'/profile/' + TopVoter.userName"
        v-contextmenu.member="{ User: TopVoter }"
        style="float:left"
      >{{ TopVoter.userName }}</router-link>
      <div style="float:right">{{ TopVoter.totalVotes }} votes</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "TopVotersPanel",
  data() {
    return {
      isLoading: false
    };
  },
  computed: {
    TopVoter() {
      return this.$store.getters["vote/GetTopVoter"];
    },
    TopVoters() {
      return this.$store.getters["vote/GetTopVoters"];
    }
  },
  methods: {
    async GetTopVoters() {
      this.isLoading = true;
      try {
        await this.$store.dispatch("vote/FetchTopVoters");
      } finally {
        this.isLoading = false;
      }
    }
  },
  created() {
    this.GetTopVoters();
  }
};
</script>