<template>
  <div class="container text-center">
    <div class="d-flex justify-content-center" v-if="loading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="250" :color="'#7289da'"/>
    </div>
    <div v-else id="online-section">
      <div v-for="realm in realms" :key="realm.id">
        <h5>{{ realm.name }}</h5>
        <p>There are {{ realm.allianceOnline + realm.hordeOnline }} players online</p>
        <p class="h5">
          <img :src="require('@/assets/images/alliance_min.png')" title="Alliance">
          {{ realm.allianceOnline }} - {{ realm.hordeOnline }}
          <img
            :src="require('@/assets/images/horde_min.png')"
            title="Horde"
          >
        </p>
        <br>
        <div class="table-responsive" @click="Collapse(realm.id)">
          <table class="table table-striped table-bordered">
            <thead class="collapsible inactive" :id="'collapsible-' + realm.id">
              <th id="th-char">Character</th>
              <th id="th-class">Class</th>
              <th id="th-race">Race</th>
              <th id="th-faction">Faction</th>
              <th id="th-level">Level</th>
              <th id="th-map">Map</th>
            </thead>
            <tbody class="collapse" :id="'collapse-' + realm.id">
              <tr v-for="player in realm.players" :key="player.name">
                <td v-bind:style="{ color: GetClassColor(player.class) }">
                  <strong>{{ player.name }}</strong>
                </td>
                <td>
                  <img class="online-image" :src="require('@/assets/images/class/' + player.class + '.gif')">
                </td>
                <td>
                  <img
                    class="online-image"
                    :src="require('@/assets/images/race/' + player.race + '-' + player.gender + '.gif')"
                  >
                </td>
                <td>
                  <img class="online-image" :src="require('@/assets/images/' + GetFaction(player.race))">
                </td>
                <td>
                  <strong>{{ player.level }}</strong>
                </td>
                <td>
                  <strong>{{ GetZoneName(player.zone) }}</strong>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import GetZone from "@/helpers/Maps";
import UserHelper from "@/helpers/UserHelper"
import { SemipolarSpinner } from "epic-spinners";
import { Realm } from "../../data/models/Realm";
import config from "@/assets/config/config";

const STATUS_API = process.env.API.STATUS;

export default {
  data() {
    return {
      realms: [],
      loading: false,
      UpdateTimer: null
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  methods: {
    async PopulateRealms() {
      this.loading = true;

      this.realms = [];

      for (const realm of config.REALMS) {
        const newRealm = new Realm(realm.id, realm.name);

        try {
          const onlinePlayerData = await this.LoadOnlinePlayers(realm.chardb);
          const { aonline, honline, result } = onlinePlayerData;
          newRealm.allianceOnline = aonline;
          newRealm.hordeOnline = honline;
          newRealm.players = result;
        } catch (err) {
          this.$toasted.error(err);
        }

        this.realms.push(newRealm);
      }
    },
    async LoadOnlinePlayers(database) {
      const data = await this.$http.post(`${STATUS_API}/online/players`, {
        database: database
      });
      return data.data;
    },
    GetZoneName(zoneId) {
      return GetZone(zoneId);
    },
    GetClassColor(classId) {
      return UserHelper.GetClassColor(classId);
    },
    GetFaction(race) {
      switch (parseInt(race, 10)) {
        case 2:
        case 5:
        case 6:
        case 8:
        case 9:
        case 10:
          return "horde_min.png";
        case 1:
        case 3:
        case 4:
        case 7:
        case 11:
          return "alliance_min.png";
      }
    },
    async UpdateOnlinePlayers() {
      for (const realm of this.realms) {
        const database = config.REALMS.find(r => r.id == realm.id);
        const onlinePlayerData = await this.LoadOnlinePlayers(database.chardb);
        const { aonline, honline, result } = onlinePlayerData;
        realm.allianceOnline = aonline;
        realm.hordeOnline = honline;
        realm.players = result;
      }
    },
    Collapse(id) {
      const thead = document.getElementById(`collapsible-${id}`);
      const tbody = document.getElementById(`collapse-${id}`);
      thead.classList.toggle("active");
      thead.classList.toggle("inactive");
      tbody.classList.toggle("collapse");
    }
  },
  created() {
    this.PopulateRealms()
      .then()
      .catch(err => console.log(err))
      .finally(() => (this.loading = false));

    this.UpdateTimer = setInterval(() => {
      this.UpdateOnlinePlayers();
    }, 60000);
  },
  updated() {},
  beforeDestroy() {
    // Prevent memory leaks
    clearInterval(this.UpdateTimer);
  }
};
</script>

<style scoped>
#atom-spinner {
  margin-top: 40%;
}

.active::after {
  content: "\2212";
}

.collapsible {
  background-color: #7289da;
  color: gold;
  cursor: pointer;
}

.inactive::after {
  content: "\002B";
}

#th-char {
  width: 25%;
}

#th-class {
  width: 10%;
}

#th-race {
  width: 10%;
}

#th-faction {
  width: 10%;
}

#th-level {
  width: 10%;
}

#th-map {
  width: 35%;
}
</style>

