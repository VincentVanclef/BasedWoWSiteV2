<template>
  <b-card no-body border-variant="dark" class="mt-2 mb-2">
    <b-card-header
      :header-bg-variant="GetCardColor(character)"
      header-text-variant="white"
      class="text-capitalize font-weight-bold click-able"
      v-b-toggle="`view-character-${character.guid}`"
    >
      <text-highlight :queries="GetQuery">{{character.name}}</text-highlight>
      <span class="text-warning">{{character.guild ? "[" + character.guild.name + "]": ""}}</span>
      <span class="float-right">{{ GetActiveBanData(character) ? '[BANNED]' : '' }}</span>
    </b-card-header>

    <b-collapse :id="`view-character-${character.guid}`" class="container-fluid pr-0 pl-0">
      <b-card-body>
        <b-row class="text-capitalize">
          <b-col>
            <label class="font-weight-bold">Character Info</label>
            <b-list-group>
              <b-list-group-item>
                Race:
                <span class="float-right font-weight-bold">
                  <font :color="GetRaceColor(character.race)">{{GetRaceName(character.race)}}</font>
                </span>
              </b-list-group-item>
              <b-list-group-item>
                Class:
                <span class="float-right font-weight-bold">
                  <font :color="GetClassColor(character.class)">{{GetClassName(character.class)}}</font>
                </span>
              </b-list-group-item>
              <b-list-group-item>
                Level:
                <span class="float-right font-weight-bold">{{character.level}}</span>
              </b-list-group-item>
              <b-list-group-item>
                Gender:
                <span class="float-right font-weight-bold">{{GetGender(character.gender)}}</span>
              </b-list-group-item>
              <b-list-group-item>
                Map:
                <span class="float-right font-weight-bold">{{GetMapName(character.map)}}</span>
              </b-list-group-item>
              <b-list-group-item>
                Zone:
                <span class="float-right font-weight-bold">{{GetZoneName(character.zone)}}</span>
              </b-list-group-item>
            </b-list-group>
          </b-col>
          <b-col>
            <label class="font-weight-bold">Currency Info</label>
            <b-list-group>
              <b-list-group-item>
                EXP:
                <span class="float-right font-weight-bold">{{character.xp}}</span>
              </b-list-group-item>
              <b-list-group-item>
                Money:
                <span class="float-right font-weight-bold">{{GetMoney(character.money)}}</span>
              </b-list-group-item>
              <b-list-group-item>
                Honor Points:
                <span
                  class="float-right font-weight-bold"
                >{{character.totalHonorPoints}}</span>
              </b-list-group-item>
              <b-list-group-item>
                Arena Points:
                <span class="float-right font-weight-bold">{{character.arenaPoints}}</span>
              </b-list-group-item>
              <b-list-group-item>
                Kills:
                <span class="float-right font-weight-bold">{{character.totalKills}}</span>
              </b-list-group-item>
              <b-list-group-item>
                Played:
                <span
                  class="float-right font-weight-bold text-lowercase"
                >{{GetTotalPlayedTime(character.totaltime)}}</span>
              </b-list-group-item>
            </b-list-group>
          </b-col>
        </b-row>
      </b-card-body>
      <b-card-footer :footer-bg-variant="GetCardColor(character)" footer-text-variant="white">
        <b-row>
          <b-col sm="12" md="12" lg="6" class="mt-2" v-if="CanModerate">
            <b-button variant="dark" block @click="OpenBanComponent(character)">Ban</b-button>
          </b-col>
          <b-col sm="12" md="12" lg="6" class="mt-2" v-if="CanModerate">
            <b-button variant="dark" block @click="UnbanCharacter(character)">Unban</b-button>
          </b-col>
          <b-col sm="12" md="12" lg="6" class="mt-2" v-if="CanModerate">
            <b-button variant="dark" block @click="OpenBanHistoryComponent(character)">Ban History</b-button>
          </b-col>
          <b-col sm="12" md="12" lg="6" class="mt-2">
            <b-button
              block
              variant="dark"
              :disabled="ShowGuildModal || !character.guild"
              @click="OpenGuildViewComponent(character)"
            >View Guild</b-button>
          </b-col>
          <b-col sm="12" md="12" lg="6" class="mt-2" v-if="CanModerate || IsCharacterOwner">
            <b-button
              variant="dark"
              block
              @click="OpenViewInventoryComponent(character)"
            >View Inventory</b-button>
          </b-col>
          <b-col sm="12" md="12" lg="6" class="mt-2">
            <b-button
              variant="dark"
              block
              @click="OpenCharacterViewComponent(character)"
            >View Character</b-button>
          </b-col>
        </b-row>
      </b-card-footer>
    </b-collapse>
    <character-ban-component ref="characterBanComponent" :realm="realm"></character-ban-component>
    <character-view-ban-history-component :realm="realm" ref="viewCharacterBanHistory"></character-view-ban-history-component>
  </b-card>
</template>

<script>
import moment from "moment";
import UserHelper from "@/helpers/UserHelper";
import MapHelper from "@/helpers/MapHelper";
import { SecsToTimeString } from "@/helpers/MethodHelper";

import CharacterBanComponent from "@/components/Admin/Characters/Actions/CharacterBanComponent";
import CharacterViewBanHistoryComponent from "@/components/Admin/Characters/Views/CharacterViewBanHistoryComponent";

export default {
  name: "CharacterComponent",
  props: ["character", "realm", "query", "user"],
  data() {
    return {};
  },
  components: {
    "character-ban-component": CharacterBanComponent,
    "character-view-ban-history-component": CharacterViewBanHistoryComponent
  },
  computed: {
    ShowGuildModal() {
      return this.$store.getters["user/guild/GuildViewComponent"].ShowModal;
    },
    GetQuery() {
      return this.query ? this.query : "";
    },
    CanModerate() {
      return UserHelper.IsAdmin() || UserHelper.IsModerator();
    },
    IsCharacterOwner() {
      return this.GetUser && this.GetUser.accountId === this.character.account;
    },
    GetUser() {
      return this.$store.getters["user/GetUser"];
    }
  },
  methods: {
    OpenBanComponent(character) {
      if (!UserHelper.IsAdmin()) {
        this.$toasted.error("You are not authorized to perform action.");
        return;
      }
      this.$refs.characterBanComponent.show(character);
    },
    OpenBanHistoryComponent(character) {
      if (!this.CanModerate) return;
      this.$refs.viewCharacterBanHistory.show(character);
    },
    OpenGuildViewComponent(character) {
      this.$store
        .dispatch("user/guild/ShowGuildComponent", {
          Realm: this.realm,
          Guild: this.character.guild
        })
        .then(() => this.$bvModal.show("guild-modal"));
    },
    OpenViewInventoryComponent(character) {
      if (!this.CanModerate && !this.IsCharacterOwner) return;
      this.$store
        .dispatch("armory/ShowInventoryComponent", {
          Realm: this.realm,
          Character: this.character
        })
        .then(() => this.$bvModal.show("inventory-modal"));
    },
    OpenCharacterViewComponent(character) {
      this.$store
        .dispatch("armory/ShowArmoryComponent", {
          Realm: this.realm,
          Character: this.character
        })
        .then(() => this.$bvModal.show("armory-modal"));
    },
    GetBanData(character) {
      return character.characterBanned;
    },
    GetActiveBanData(character) {
      const banData = this.GetBanData(character);
      const banned = banData.find(x => x.active === 1);
      return banned;
    },
    GetCardColor(character) {
      return this.GetActiveBanData(character)
        ? "danger"
        : this.character.online
        ? "success"
        : "info";
    },
    async UnbanCharacter(character) {
      if (!UserHelper.IsAdmin()) {
        this.$toasted.error("You are not authorized to perform action.");
        return;
      }

      const check = await this.$bvModal.msgBoxConfirm(
        `Are you sure you wish to unban ${character.name}?`,
        {
          centered: true,
          okTitle: "Yes"
        }
      );

      if (!check) return;

      const Character = character;
      const RealmType = this.realm.id;

      await this.$store.dispatch("admin/UnBanCharacter", {
        Character,
        RealmType
      });

      this.$toasted.success(`${character.name} has been unbanned.`);
    },
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    },
    GetRaceName(raceId) {
      return UserHelper.GetRaceName(raceId);
    },
    GetRaceColor(raceId) {
      return UserHelper.GetRaceColor(raceId);
    },
    GetClassName(classId) {
      return UserHelper.GetClassName(classId);
    },
    GetClassColor(classId) {
      return UserHelper.GetClassColor(classId);
    },
    GetMapName(mapId) {
      return MapHelper.GetMap(mapId);
    },
    GetZoneName(zoneId) {
      return MapHelper.GetZone(zoneId);
    },
    GetGender(genderId) {
      return UserHelper.GetGender(genderId);
    },
    GetMoney(money) {
      const SILVER = 100;
      const GOLD = 100 * SILVER;
      return (
        parseInt(money / GOLD) +
        "g" +
        parseInt((money % GOLD) / SILVER) +
        "s" +
        parseInt((money % GOLD) % SILVER) +
        "c"
      );
    },
    GetTotalPlayedTime(time) {
      return SecsToTimeString(time, true);
    }
  }
};
</script>