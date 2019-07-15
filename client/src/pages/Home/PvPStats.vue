<template>
  <div class="container">
    <div class="form-group" v-if="Realms.length > 0">
      <select
        name="realm-selection"
        class="form-control"
        v-model="SelectedRealm"
        @change="SelectedRealmChange()"
      >
        <option disabled>Choose Realm</option>
        <option v-for="realm in Realms" :key="realm.id" v-bind:value="realm">{{ realm.name }}</option>
      </select>
    </div>

    <section id="statistics" v-if="typeof SelectedRealm == 'object'">
      <h3>Top Arena Teams</h3>
      <hr />

      <section
        id="statistics_top_arena_teams"
        class="row no-gutters"
        v-if="TopArenaTeams.length > 0"
      >
        <div class="col statistics_arena_box">
          <div class="statistics_arena_head">2v2</div>
          <div
            v-for="(team, index) in Selected2v2ArenaTeams"
            :key="index"
            class="statistics_arena_item"
          >
            <div id="rank">{{ index + 1 }}</div>
            <div id="stats">
              <span id="team-name">{{ team.name }}</span>
              <br />
              <span id="team-rating">{{ team.rating }} Rating</span>
              <br />
              <div class="d-flex flex-wrap align-items-center">
                <div
                  v-for="(member, index) in GetTeamMembers(team.arenateamid)"
                  :key="index"
                  id="team-members"
                >
                  <img
                    class="online-image"
                    v-b-tooltip.hover.bottom
                    :title=" member.name + '\nGames Played: ' + member.games + '\nGames Won: ' + member.wins + '\nPersonal Rating: ' + member.rating"
                    id="team-member"
                    :src="require('@/assets/images/class/' + member.class + '.gif')"
                  />
                  <div class="clear"></div>
                </div>
              </div>
            </div>
            <div class="clear"></div>
          </div>
          <div class="statistics_arena_item" v-if="Selected2v2ArenaTeams.length == 0">
            <br />There are no 2v2 Teams.
            <br />
            <br />
          </div>
        </div>

        <div class="col statistics_arena_box">
          <div class="statistics_arena_head">3v3</div>
          <div
            v-for="(team, index) in Selected3v3ArenaTeams"
            :key="index"
            class="statistics_arena_item"
          >
            <div id="rank">{{ index + 1 }}</div>
            <div id="stats">
              <span id="team-name">{{ team.name }}</span>
              <br />
              <span id="team-rating">{{ team.rating }} Rating</span>
              <br />
              <div class="d-flex flex-wrap align-items-center">
                <div
                  v-for="(member, index) in GetTeamMembers(team.arenateamid)"
                  :key="index"
                  id="team-members"
                >
                  <img
                    class="online-image"
                    v-b-tooltip.hover.bottom
                    :title=" member.name + '\nGames Played: ' + member.games + '\nGames Won: ' + member.wins + '\nPersonal Rating: ' + member.rating"
                    id="team-member"
                    :src="require('@/assets/images/class/' + member.class + '.gif')"
                    align="absbottom"
                  />
                  <div class="clear"></div>
                </div>
              </div>
            </div>
            <div class="clear"></div>
          </div>
          <div class="statistics_arena_item" v-if="Selected3v3ArenaTeams.length == 0">
            <br />There are no 3v3 Teams.
            <br />
            <br />
          </div>
        </div>

        <div class="col statistics_arena_box mr-0">
          <div class="statistics_arena_head">5v5</div>
          <div
            v-for="(team, index) in Selected5v5ArenaTeams"
            :key="index"
            class="statistics_arena_item"
          >
            <div id="rank">{{ index + 1 }}</div>
            <div id="stats">
              <span id="team-name">{{ team.name }}</span>
              <br />
              <span id="team-rating">{{ team.rating }} Rating</span>
              <br />
              <div class="d-flex flex-wrap align-items-center">
                <div
                  v-for="(member, index) in GetTeamMembers(team.arenateamid)"
                  :key="index"
                  id="team-members"
                >
                  <img
                    class="online-image"
                    v-b-tooltip.hover.bottom
                    :title=" member.name + '\nGames Played: ' + member.games + '\nGames Won: ' + member.wins + '\nPersonal Rating: ' + member.rating"
                    id="team-member"
                    :src="require('@/assets/images/class/' + member.class + '.gif')"
                    align="absbottom"
                  />
                  <div class="clear"></div>
                </div>
              </div>
            </div>
            <div class="clear"></div>
          </div>
          <div class="statistics_arena_item" v-if="Selected5v5ArenaTeams.length == 0">
            <br />There are no 5v5 Teams.
            <br />
            <br />
          </div>
        </div>

        <div class="clear"></div>
      </section>

      <section id="statistics_top_hk" class="mt-3" v-if="TopHKPlayers.length > 0">
        <h3>Top Honorable Kill Players</h3>
        <b-table
          striped
          bordered
          responsive
          :items="SelectedTotalHKPlayers"
          :fields="TableFields"
          :sort-compare-options="{ numeric: true, sensitivity: 'base' }"
        >
          <span
            slot="name"
            slot-scope="data"
            v-bind:style="{ color: GetClassColor(data.item.class) }"
          >{{ data.value }}</span>
          <span slot="race" slot-scope="data">
            <img
              class="online-image"
              :src="require('@/assets/images/race/' + data.item.race + '-' + data.item.gender + '.gif')"
            />
          </span>
          <span slot="class" slot-scope="data">
            <img
              class="online-image"
              :src="require('@/assets/images/class/' + data.value + '.gif')"
            />
          </span>
          <span slot="kills" slot-scope="data" v-bind:style="{ color: 'red' }">{{ data.value }}</span>
        </b-table>
      </section>
    </section>
  </div>
</template>

<script>
import config from "@/assets/config/config";
import UserHelper from "@/helpers/UserHelper";

export default {
  name: "PvPStatistics",
  data() {
    return {
      AvailableTeams: [2, 3, 5],
      SelectedRealm: "Choose Realm",

      MaxTotalKills: 50,

      // TABLE DATA
      TableFields: [
        { key: "rank", sortable: true },
        { key: "name", sortable: true },
        { key: "level", sortable: true },
        { key: "race", sortable: true },
        { key: "class", sortable: true },
        { key: "kills", sortable: true }
      ]
    };
  },
  computed: {
    Realms() {
      return config.REALMS;
    },
    TopArenaTeams() {
      return this.$store.getters.GetTopArenaTeams;
    },
    SelectedArenaTeams() {
      const teams = this.TopArenaTeams.find(
        x => x.realmid == this.SelectedRealm.id
      );
      return teams ? teams.data : [];
    },
    Selected2v2ArenaTeams() {
      return this.SelectedArenaTeams.filter(x => x.type == 2);
    },
    Selected3v3ArenaTeams() {
      return this.SelectedArenaTeams.filter(x => x.type == 3);
    },
    Selected5v5ArenaTeams() {
      return this.SelectedArenaTeams.filter(x => x.type == 5);
    },
    TopTeamMembers() {
      return this.$store.getters.GetTopTeamMembers;
    },
    SelectedArenaTeamMembers() {
      const members = this.$store.getters.GetTopTeamMembers.find(
        x => x.realmid == this.SelectedRealm.id
      );
      return members ? members.data : [];
    },
    TopHKPlayers() {
      return this.$store.getters.GetTopHKPlayers;
    },
    SelectedTotalHKPlayers() {
      const players = this.TopHKPlayers.find(
        x => x.realmid == this.SelectedRealm.id
      );
      return players ? players.data : [];
    }
  },
  methods: {
    SelectedRealmChange() {
      this.$router.replace({ query: { realm: this.SelectedRealm.id } });
    },
    GetTeamMembers(team) {
      const data = this.SelectedArenaTeamMembers.filter(
        x => x.arenateamid == team
      );
      return data;
    },
    GetClassColor(classId) {
      return UserHelper.GetClassColor(classId);
    }
  },
  created() {
    if (this.TopArenaTeams.length == 0) {
      for (const realm of this.Realms) {
        this.$store.dispatch("GetTopArenaTeams", realm).then(result => {
          if (result != "success") {
            this.$toasted.error(result);
            return;
          }

          if (this.TopTeamMembers.length == 0) {
            const data = this.TopArenaTeams.find(x => x.realmid == realm.id);
            const teams = data.data.map(x => x.arenateamid);
            if (teams.length == 0) {
              return;
            }

            this.$store
              .dispatch("GetTopTeamMembers", { realm, teams })
              .then(result => {
                if (result != "success") {
                  this.$toasted.error(result);
                  return;
                }
              });
          }
        });
      }
    }

    if (this.$store.getters.GetTopHKPlayers.length == 0) {
      for (const realm of this.Realms) {
        this.$store
          .dispatch("GetTopHKPlayers", { realm, limit: this.MaxTotalKills })
          .then(result => {
            if (result != "success") {
              this.$toasted.error(result);
            }
          });
      }
    }

    const realmId = this.$route.query.realm;
    if (realmId > 0) {
      this.SelectedRealm = this.Realms.find(x => x.id == realmId);
    }
  }
};
</script>

<style scoped>
#statistics_title h3 {
  font-size: 22px;
  display: block;
  padding: 0 0 10px 10px;
  box-shadow: 0 2px 0 rgba(255, 255, 255, 0.12);
  color: #b38e3f;
}
#statistics_top_arena_teams {
  margin-top: 15px;
}
.statistics_arena_box {
  float: left;
  border-radius: 5px;
  width: 220px;
  margin-right: 15px;
  box-shadow: inset 0 0 0 1px rgba(255, 255, 255, 0.02),
    0 0 4px rgba(0, 0, 0, 0.6);
}
.statistics_arena_head {
  font-family: Arial, Helvetica, sans-serif;
  font-size: 26px;
  font-weight: 700;
  padding: 10px 20px;
  background: rgba(153, 153, 153, 0.1);
  border-top-left-radius: 5px;
  border-top-right-radius: 5px;
  box-shadow: 0 2px 1px rgba(0, 0, 0, 0.3),
    inset 0 -1px 0 rgba(255, 255, 255, 0.01);
  color: #9a814b;
  text-align: center;
}
.statistics_arena_item {
  background: rgba(153, 153, 153, 0.05);
  padding: 10px 20px;
  box-shadow: 0 1px 0 rgba(0, 0, 0, 0.3),
    inset 0 -1px 0 rgba(255, 255, 255, 0.01);
}
.statistics_arena_item:last-child {
  border-bottom-left-radius: 5px;
  border-bottom-right-radius: 5px;
  border-bottom: none;
}
.statistics_arena_item #rank {
  font-family: Arial, Helvetica, sans-serif;
  font-size: 26px;
  font-weight: 700;
  float: left;
}
.statistics_arena_item #stats {
  float: left;
  padding-top: 5px;
  padding-left: 15px;
  width: 140px;
  text-align: left;
}
.statistics_arena_item #stats #team-name {
  font-weight: 700;
  font-size: 15px;
  color: #9a814b;
}
.statistics_arena_item #stats #team-rating {
  font-style: italic;
}
.statistics_arena_item #stats #team-members {
  margin-bottom: 10px;
}
#team-member {
  float: left;
  margin-top: 5px;
  margin-right: 5px;
}
.clear {
  clear: both;
}
</style>

