<template lang="html">
  <div class="card rounded" style="margin-bottom: 20px">
    <div class="card-body">
      <h5 class="card-title text-center mb-4 mt-1">Server Status</h5>
      <hr class="hr-style">
      <div class="d-flex justify-content-center" v-if="!loaded" id="atom-spinner">
        <semipolar-spinner :animation-duration="2000" :size="100" :color="'#7289da'"/>
      </div>
      <div v-else>
        <div v-for="realm in realms" :key="realm.id">
          <div class="online-status">
            <div v-if="realm.loaded">
              <div>
                <span class="badge badge-pill badge-success">Online</span>
                {{ realm.name }}
              </div>
            </div>
            <div v-else>
              <div>
                <span class="badge badge-pill badge-danger">Offline</span>
                {{ realm.name }}
              </div>
            </div>
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
      <div class="text-center">{{ realmlist }}</div>
    </div>
  </div>
</template>

<script>
import { Realm } from "../data/models/Realm";
import { SemipolarSpinner } from "epic-spinners";
import config from "@/assets/config/config";

const STATUS_API = process.env.API.STATUS;

export default {
  data() {
    return {
      realms: [],
      loaded: false,
      realmlist: config.REALMLIST,
      UpdateTimer: null
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  methods: {
    async PopulateRealms() {
      this.realms = [];

      for (const realm of config.REALMS) {
        const newRealm = new Realm(realm.id, realm.name);

        // Attempt to load online players
        try {
          const onlinePlayerData = await this.LoadOnlinePlayers(realm.id);
          const { aonline, honline } = onlinePlayerData;
          newRealm.allianceOnline = aonline;
          newRealm.hordeOnline = honline;
          newRealm.loaded = true;
        } catch (err) {
          this.$toasted.error(err);
        }

        this.realms.push(newRealm);
      }
    },
    /*async LoadRealms() {
      const data = await this.$http.get(`${STATUS_API}/all`);
      return data.data;
    },*/
    async LoadOnlinePlayers(realmid) {
      const data = await this.$http.post(`${STATUS_API}/GetOnlinePlayers`, {
        RealmType: realmid
      });
      return data.data;
    },
    async UpdateOnlinePlayers() {
      for (const realm of this.realms) {
        if (!realm.loaded) {
          continue;
        }

        const database = config.REALMS.find(r => r.id == realm.id);
        const onlinePlayerData = await this.LoadOnlinePlayers(database.id);
        const { aonline, honline } = onlinePlayerData;
        realm.allianceOnline = aonline;
        realm.hordeOnline = honline;
      }
    },
    TotalOnline(id) {
      const realm = this.realms.find(r => r.id == id);
      return realm.allianceOnline + realm.hordeOnline;
    },
    AllianceOnline(id) {
      const realm = this.realms.find(r => r.id == id);
      return realm.allianceOnline;
    },
    AllianceOnlinePct(id) {
      const totalOnline = this.TotalOnline(id);
      if (totalOnline == 0) {
        return 50;
      }

      const realm = this.realms.find(r => r.id == id);
      let pct = parseInt(Math.ceil((realm.allianceOnline / totalOnline) * 100));
      return pct;
    },
    HordeOnline(id) {
      const realm = this.realms.find(r => r.id == id);
      return realm.hordeOnline;
    },
    HordeOnlinePct(id) {
      const totalOnline = this.TotalOnline(id);
      if (totalOnline == 0) {
        return 50;
      }

      const realm = this.realms.find(r => r.id == id);
      return parseInt(Math.ceil((realm.hordeOnline / totalOnline) * 100));
    }
  },
  computed: {},
  created() {
    this.PopulateRealms()
      .then()
      .catch(err => console.log(err))
      .finally(() => (this.loaded = true));

    this.UpdateTimer = setInterval(() => {
      this.UpdateOnlinePlayers();
    }, 120000);
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

