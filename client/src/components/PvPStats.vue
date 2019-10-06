<template>
  <div class="card rounded" style="margin-bottom: 20px">
    <div class="card-body">
      <h5 class="card-title text-center mb-4 mt-1">PvP Statistics</h5>
      <hr class="border-dark" />
      <div class="form-group" v-if="SelectedRealm != null">
        <select name="realm-selection" class="form-control" v-model="SelectedRealm">
          <option v-for="realm in realms" :key="realm.id" :value="realm">{{ realm.name }}</option>
        </select>
        <div class="mt-3 toppvp_select"></div>
        <div v-for="player in SelectedTotalHKPlayers" :key="player.rank">
          <div class="toppvp_character font-weight-bold text-capitalize">
            <div class="float-right">{{player.kills}} kills</div>
            <span class="mr-1">{{player.rank}}</span>
            <img
              class="img-fluid"
              alt="race-icon"
              :src="require('@/assets/images/race/' + player.race + '-' + player.gender + '.gif')"
            />
            <img
              class="img-fluid"
              alt="class-icon"
              :src="require('@/assets/images/class/' + player.class + '.gif')"
            />
            <router-link
              v-if="IsAdmin"
              :player-data="JSON.stringify({player: player, realm: SelectedRealm.id})"
              :to="`/admin/accounts/search?query=${player.accountId}`"
            >{{ player.name }}</router-link>
            <router-link
              v-if="!IsAdmin"
              :player-data="JSON.stringify({player: player, realm: SelectedRealm.id})"
              :to="`/armory/characters/Search?query=${player.name}&realm=${SelectedRealm.id}`"
            >{{ player.name }}</router-link>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import UserHelper from "@/helpers/UserHelper";

export default {
  name: "TopPvPPanel",
  props: ["realms"],
  data() {
    return {
      SelectedRealm: null,
      MaxTotalKills: 100
    };
  },
  computed: {
    TopHKPlayers() {
      return this.$store.getters["stats/GetTopHKPlayers"];
    },
    SelectedTotalHKPlayers() {
      const players = this.TopHKPlayers.find(
        x => x.RealmType == this.SelectedRealm.id
      );
      return players ? players.Data.slice(0, 5) : [];
    },
    IsAdmin() {
      return UserHelper.IsAdmin() || UserHelper.IsModerator();
    }
  },
  methods: {
    GetClassColor(classId) {
      return UserHelper.GetClassColor(classId);
    },
    setupContextMenu() {
      const links = this.$el.querySelectorAll("a");
      links.forEach(element => {
        element.addEventListener(
          "contextmenu",
          event => {
            const playerData = JSON.parse(element.getAttribute("player-data"));
            const player = playerData.player;
            const realmId = playerData.realm;

            let ctxMenuData = [
              {
                title: "View Account",
                requiresAdmin: true,
                handler: () =>
                  window.open(
                    `/admin/accounts/search?query=${player.accountId}`,
                    "_blank"
                  )
              },
              {
                type: "divider"
              },
              {
                title: "View Character",
                requiresAdmin: false,
                handler: () =>
                  window.open(
                    `/armory/characters/Search?query=${player.name}&realm=${realmId}`,
                    "_blank"
                  )
              },
              {
                title: "View Character Armory",
                requiresAdmin: false,
                handler: () =>
                  window.open(
                    `/armory/characters/Search?query=${player.name}&realm=${realmId}&showArmory=${player.name}`,
                    "_blank"
                  )
              },
              {
                title: "View Character Inventory",
                requiresAdmin: true,
                handler: () =>
                  window.open(
                    `/armory/characters/Search?query=${player.name}&realm=${realmId}&showInventory=${player.name}`,
                    "_blank"
                  )
              }
            ];

            if (!this.IsAdmin) {
              ctxMenuData = ctxMenuData.filter(x => !x.requiresAdmin);
            }

            this.$root.$emit("contextmenu", { event, ctxMenuData });
          },
          false
        );
      });
    },
    async LoadTopHKPlayers() {
      for (const realm of this.realms) {
        await this.$store.dispatch("stats/GetTopHKPlayers", {
          RealmType: realm.id,
          Limit: this.MaxTotalKills
        });
      }
    }
  },
  created() {
    this.SelectedRealm = this.realms[0];

    if (this.$store.getters["stats/GetTopHKPlayers"].length == 0) {
      this.LoadTopHKPlayers().finally(() => this.setupContextMenu());
    }
  }
};
</script>

<style scoped>
.pvp-image {
  width: 100%;
}

.toppvp_select {
  border-bottom: 1px solid rgba(14, 24, 32, 0.5);
}

.toppvp_character {
  padding: 10px;
  color: #786043;
  border-bottom: 1px solid rgba(14, 24, 32, 0.5);
}

.toppvp_character {
  padding: 10px;
  font-size: 12px;
  text-align: left;
}
</style>


