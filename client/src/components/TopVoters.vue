<template>
  <div class="card rounded" style="margin-bottom: 20px">
    <div class="card-body">
      <h5 class="card-title text-center mb-4 mt-1">Weekly Top Voters</h5>
      <hr>
      <div class="d-flex justify-content-center" v-if="Loading" id="atom-spinner">
        <semipolar-spinner :animation-duration="2000" :size="100" :color="'#7289da'"/>
      </div>
      <div v-else>
        <div v-for="(voter, index) in TopVoters" :key="voter.userName" id="toppvp">
          <div class="toppvp_character">
            <div style="float:right">{{ voter.total }} votes</div>
            <b>{{ index + 1 }}</b>
            <router-link :to="'/profile/' + voter.userName">{{ voter.userName }}</router-link>
          </div>
        </div>
      </div>
    </div>
    <div class="card-footer" v-if="TopVoter != null">
      <div class="text-center">Lifetime Top Voter:</div>
      <router-link :to="'/profile/' + TopVoter.userName" style="float:left">{{ TopVoter.userName }}</router-link>
      <div style="float:right">{{ TopVoter.total }} votes</div>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

const API_VOTE = process.env.API.VOTE;

export default {
  name: "TopVotersPanel",
  data() {
    return {
      Loading: false,
      TopVoters: [],
      TopVoter: null
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  methods: {
    async GetTopVoters() {
      this.Loading = true;
      let result;
      try {
        result = await this.$http.get(`${API_VOTE}/GetTopVoters`);
      } catch (err) {
        this.$toasted.error(err);
      } finally {
        this.Loading = false;
      }

      if (result != null) {
        const { topvoter, topvoters } = result.data;
        this.TopVoter = topvoter;
        this.TopVoters = topvoters;
      }
    },
    GetPosition(id) {
      return this.TopVoters.findIndex(x => x.id == id) + 1;
    }
  },
  computed: {
    /*GetTopVoters() {
      return this.TopVoters.sort((a, b) => (a.votes < b.votes ? 1 : -1));
    }*/
  },
  created() {
    this.GetTopVoters();
  }
};
</script>

<style>
#atom-spinner {
  margin-top: 5%;
}

a {
  color: #786043;
  text-decoration: none;
}

a:hover {
  color: #c47e2c;
  text-decoration: none;
}
</style>

