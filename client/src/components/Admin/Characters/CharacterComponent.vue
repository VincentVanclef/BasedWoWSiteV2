<template>
  <b-card no-body border-variant="dark" class="mt-2 mb-2">
    <b-card-header
      :header-bg-variant="GetVariant"
      header-text-variant="white"
      class="text-capitalize font-weight-bold"
    >{{character.name}}</b-card-header>

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
              <span class="float-right font-weight-bold">{{character.totalHonorPoints}}</span>
            </b-list-group-item>
            <b-list-group-item>
              Arena Points:
              <span class="float-right font-weight-bold">{{character.arenaPoints}}</span>
            </b-list-group-item>
            <b-list-group-item>
              Kills Today:
              <span class="float-right font-weight-bold">{{character.todayKills}}</span>
            </b-list-group-item>
            <b-list-group-item>
              Total Today:
              <span class="float-right font-weight-bold">{{character.totalKills}}</span>
            </b-list-group-item>
          </b-list-group>
        </b-col>
      </b-row>
    </b-card-body>
    <b-card-footer
      :footer-variant="GetVariant"
      :footer-bg-variant="GetVariant"
      footer-text-variant="white"
    >
      <b-row>
        <b-col sm="6" md="4" lg="3" class="mt-2">
          <b-button variant="dark" block @click="OpenBanComponent(character)">Ban</b-button>
        </b-col>
        <b-col sm="6" md="4" lg="3" class="mt-2">
          <b-button variant="dark" block @click="UnbanCharacter(character)">Unban</b-button>
        </b-col>
      </b-row>
    </b-card-footer>
    <character-ban-component ref="characterBanComponent" :realm="realm"></character-ban-component>
  </b-card>
</template>

<script>
import moment from "moment";
import UserHelper from "@/helpers/UserHelper";
import MapHelper from "@/helpers/MapHelper";

import CharacterBanComponent from "./Actions/CharacterBanComponent";

export default {
  name: "CharacterComponent",
  props: ["character", "realm"],
  data() {
    return {};
  },
  components: {
    "character-ban-component": CharacterBanComponent
  },
  computed: {
    GetVariant() {
      return this.character.online ? "success" : "info";
    }
  },
  methods: {
    OpenBanComponent(character) {
      this.$refs.characterBanComponent.show(character);
    },
    async UnbanCharacter(character) {
      const check = await this.$bvModal.msgBoxConfirm(
        `Are you sure you wish to unban ${character.name}?`,
        {
          centered: true,
          okTitle: "Yes"
        }
      );

      if (!check) return;

      const Guid = character.guid;
      const RealmType = this.realm.id;

      await this.$store.dispatch("admin/UnBanCharacter", {
        Guid,
        RealmType
      });

      this.$toasted.success(`${character.name} has been unbanned.`);
    },
    OpenMuteComponent(character) {
      this.$refs.characterMuteComponent.show(character);
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
      const GOLD = 10 * SILVER;
      return (
        money / GOLD +
        "g" +
        (money % GOLD) / SILVER +
        "s" +
        (money % SILVER) +
        "c"
      );
    }
  }
};
</script>