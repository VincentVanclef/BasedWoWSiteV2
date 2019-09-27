<template>
  <div class="container text-center">
    <div id="online-section">
      <div v-for="realm in realms" :key="realm.id">
        <h5>{{ realm.name }}</h5>
        <p>There are {{TotalOnline(realm.id)}} players online</p>
        <p class="h5">
          <img :src="require('@/assets/images/alliance_min.png')" title="Alliance" />
          {{ AllianceOnline(realm.id) }} - {{ HordeOnline(realm.id) }}
          <img
            :src="require('@/assets/images/horde_min.png')"
            title="Horde"
          />
        </p>
        <br />
        <div>
          <table class="table table-striped table-bordered table-responsive">
            <thead
              class="collapsible inactive"
              :id="'collapsible-' + realm.id"
              @click="Collapse(realm.id)"
            >
              <th id="th-char">Character</th>
              <th id="th-class">Class</th>
              <th id="th-race">Race</th>
              <th id="th-faction">Faction</th>
              <th id="th-level">Level</th>
              <th id="th-map">Map</th>
            </thead>
            <tbody class="collapse" :id="'collapse-' + realm.id">
              <tr v-for="player in realm.onlinePlayers" :key="player.name">
                <td v-bind:style="{ color: GetClassColor(player.class) }">
                  <strong>
                    <font
                      v-if="player.rank > 0"
                      :color="GetGameRankColor(player.rank)"
                    >[{{GetGameRankName(player.rank)}}]</font>
                    <font :color="GetClassColor(player.class)">
                      <router-link
                        v-if="IsAdmin"
                        :to="`/admin/accounts/search?query=${player.accountId}`"
                      >{{ player.name }}</router-link>
                      <router-link
                        v-if="!IsAdmin"
                        :to="`/armory/characters/Search?query=${player.name}&realm=${realm.id}`"
                      >{{ player.name }}</router-link>
                    </font>
                  </strong>
                </td>
                <td>
                  <img
                    class="online-image"
                    :src="require('@/assets/images/class/' + player.class + '.gif')"
                  />
                </td>
                <td>
                  <img
                    class="online-image"
                    :src="require('@/assets/images/race/' + player.race + '-' + player.gender + '.gif')"
                  />
                </td>
                <td>
                  <img
                    class="online-image"
                    :src="require('@/assets/images/' + GetFaction(player.race))"
                  />
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
import MapHelper from "@/helpers/MapHelper";
import UserHelper from "@/helpers/UserHelper";
import { SemipolarSpinner } from "epic-spinners";
const STATUS_API = process.env.API.STATUS;
export default {
  props: ["realms"],
  data() {
    return {
      UpdateTimer: null
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {
    IsAdmin() {
      return UserHelper.IsAdmin();
    }
  },
  methods: {
    TotalOnline(id) {
      const realm = this.realms.find(r => r.id == id);
      return realm.online ? realm.onlinePlayers.length : 0;
    },
    AllianceOnline(id) {
      const realm = this.realms.find(r => r.id == id);
      const data = realm.onlinePlayers.filter(x =>
        UserHelper.IsAlliance(x.race)
      );
      return realm.online ? data.length : 0;
    },
    HordeOnline(id) {
      const realm = this.realms.find(r => r.id == id);
      const data = realm.onlinePlayers.filter(x => UserHelper.IsHorde(x.race));
      return realm.online ? data.length : 0;
    },
    GetZoneName(zoneId) {
      return MapHelper.GetZone(zoneId);
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
    GetClassColor(classId) {
      return UserHelper.GetClassColor(classId);
    },
    GetGameRankColor(rank) {
      return UserHelper.GetGameRankColor(rank);
    },
    GetGameRankName(rank) {
      return UserHelper.GetGameRankNameShort(rank);
    },
    Collapse(id) {
      const thead = document.getElementById(`collapsible-${id}`);
      const tbody = document.getElementById(`collapse-${id}`);
      thead.classList.toggle("active");
      thead.classList.toggle("inactive");
      tbody.classList.toggle("collapse");
    }
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