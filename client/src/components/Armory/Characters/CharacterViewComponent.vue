<template>
  <b-card-group class="card-member">
    <b-col
      v-for="(character, index) in GetSortedCharacters"
      :key="index"
      :sm="sm"
      :md="md"
      :lg="lg"
    >
      <character-component :character="character" :realm="selectedRealm" :query="query"></character-component>
    </b-col>
    <guild-component />
    <character-armory />
  </b-card-group>
</template>

<script>
import moment from "moment";
import UserHelper from "@/helpers/UserHelper";
import GuildComponent from "@/components/Admin/Guilds/Views/GuildComponent";
import CharacterArmoryComponent from "@/components/Armory/Characters/CharacterArmoryComponent";
import { setTimeout } from "timers";

export default {
  name: "AccountViewComponent",
  props: [
    "user",
    "characters",
    "roles",
    "sm",
    "md",
    "lg",
    "query",
    "realms",
    "selectedRealm"
  ],
  data() {
    return {};
  },
  components: {
    "guild-component": GuildComponent,
    "character-armory": CharacterArmoryComponent
  },
  computed: {
    GetSortedCharacters() {
      const characters = [...this.characters];
      return characters.sort((a, b) => {
        if (a.online > b.online) return -1;
        if (a.online < b.online) return 1;

        if (a.guid < b.guid) return -1;
        if (a.guid > b.guid) return 1;
      });
    },
    GetQuery() {
      return this.query ? this.query : "";
    }
  },
  methods: {
    FilterAccount(account) {
      this.$router.push(`/admin/accounts/search?query=${account.email}`);
    },
    CheckGuildQuery() {
      const query = this.$route.query;
      if (!query) return;

      const guildName = query.guild;
      if (!guildName) return;

      const character = this.GetSortedCharacters.find(
        x => x.guild && x.guild.name == guildName
      );
      if (!character) return;

      const guild = character.guild;
      if (!guild) return;

      this.$store
        .dispatch("user/guild/ShowGuildComponent", {
          Realm: this.selectedRealm,
          Guild: guild
        })
        .then(() => this.$bvModal.show("guild-modal"));
    },
    CheckArmoryQuery() {
      const query = this.$route.query;
      if (!query) return;

      const showArmory = query.showArmory;
      if (!showArmory) return;

      const character = this.GetSortedCharacters.find(
        x => x.name === showArmory
      );
      if (!character) return;

      this.$store
        .dispatch("armory/ShowArmoryComponent", {
          Realm: this.selectedRealm,
          Character: character
        })
        .then(() => this.$bvModal.show("armory-modal"));
    }
  },
  mounted() {
    this.CheckGuildQuery();
    this.CheckArmoryQuery();
  }
};
</script>