<template lang="html">
  <div class="card rounded" style="margin-bottom: 20px">
    <div class="card-body">
      <h5 class="card-title text-center mb-4 mt-1">Server Status</h5>
      <hr class="border-dark">
      <div class="d-flex justify-content-center" v-if="IsLoading" id="atom-spinner">
        <semipolar-spinner :animation-duration="2000" :size="100" :color="'#7289da'"/>
      </div>
      <div v-else>
        <div v-for="realm in Realms" :key="realm.id">
          <div class="online-status">
            <!-- <div v-if="realm.loaded"> -->
              <div>
                <span class="badge badge-pill badge-success">Online</span>
                {{ realm.name }}
              </div>
            <!-- </div>
            <div v-else>
              <div>
                <span class="badge badge-pill badge-danger">Offline</span>
                {{ realm.name }}
              </div>
            </div> -->
          </div>
          <b-row>
            <div class="col-6 text-left">Alliance</div>
            <div class="col-6 text-right">Horde</div>
          </b-row>
          <div class="progress">
            <div
              :id="`progress-bar-alliance-${realm.id}`"
              class="progress-bar progress-bar"
              role="progressbar"
              :style="{ width: AllianceOnlinePct(realm.id) + '%' }"
              aria-valuenow="70"
              aria-valuemin="0"
              aria-valuemax="100"
            ></div>
            <b-tooltip
              placement="bottom"
              :target="`progress-bar-alliance-${realm.id}`"
            >{{ AllianceOnline(realm.id) }} players online</b-tooltip>
            <div
              :id="`progress-bar-horde-${realm.id}`"
              class="progress-bar progress-bar bg-danger"
              role="progressbar"
              :style="{ width: HordeOnlinePct(realm.id) + '%'}"
              aria-valuenow="90"
              aria-valuemin="0"
              aria-valuemax="100"
            ></div>
            <b-tooltip
              placement="bottom"
              :target="`progress-bar-horde-${realm.id}`"
            >{{ HordeOnline(realm.id) }} players online</b-tooltip>
          </div>
        </div>
      </div>
    </div>
    <div class="card-footer">
      <div class="card-title text-center">Realmlist</div>
      <div class="text-center">{{ Realmlist }}</div>
    </div>
  </div>
</template>

<script>
import { Realm } from "../data/models/Realm";
import { SemipolarSpinner } from "epic-spinners";
import config from "@/assets/config/config";
import UserHelper from "@/helpers/UserHelper";

const STATUS_API = process.env.API.STATUS;

export default {
  data() {
    return {
      UpdateTimer: null
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {
    Realmlist() {
      return config.REALMLIST;
    },
    Realms() {
      return this.$store.getters["realms/GetRealms"];
    },
    IsLoading() {
      return this.$store.getters["realms/GetStatus"];
    }
  },
  methods: {
    TotalOnline(id) {
      const realm = this.Realms.find(r => r.id == id);
      return realm.onlinePlayers.length;
    },
    AllianceOnline(id) {
      const realm = this.Realms.find(r => r.id == id);
      const data = realm.onlinePlayers.filter(x =>
        UserHelper.IsAlliance(x.race)
      );
      return data.length;
    },
    AllianceOnlinePct(id) {
      const totalOnline = this.TotalOnline(id);
      if (totalOnline == 0) {
        return 50;
      }

      const realm = this.Realms.find(r => r.id == id);
      const pct = parseInt(
        Math.ceil((this.AllianceOnline(id) / totalOnline) * 100)
      );
      return pct;
    },
    HordeOnline(id) {
      const realm = this.Realms.find(r => r.id == id);
      const data = realm.onlinePlayers.filter(x => UserHelper.IsHorde(x.race));
      return data.length;
    },
    HordeOnlinePct(id) {
      const totalOnline = this.TotalOnline(id);
      if (totalOnline == 0) {
        return 50;
      }

      const realm = this.Realms.find(r => r.id == id);
      return parseInt(Math.ceil((this.HordeOnline(id) / totalOnline) * 100));
    },
    async UpdateOnlinePlayers() {
      for (const realm of this.Realms) {
        await this.$store.dispatch(
          "realms/FetchOnlinePlayersForRealm",
          realm.id
        );
      }
    }
  },
  created() {
    this.UpdateTimer = setInterval(() => {
      this.UpdateOnlinePlayers();
    }, config.UPDATE_ONLINE_PLAYERS_INTERVAL);
  },
  beforeDestroy() {
    // Prevent memory leaks
    clearInterval(this.UpdateTimer);
  }
};
</script>

<style scoped>
#atom-spinner {
  margin-top: 20%;
}

.online-status {
  margin-top: 10px;
}

.progress .progress-bar {
  border-radius: 3px;
}
</style>

