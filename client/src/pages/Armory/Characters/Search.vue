<template>
  <b-container v-if="GetSelectedRealm">
    <b-row>
      <b-col sm="12" md="6" lg="6">
        <div>
          <label class="control-label">Search {{GetSelectedRealm.name}} Armory</label>
          <b-input
            type="text"
            id="search"
            name="search"
            @input="isTyping = true"
            v-model="searchQuery"
            placeholder="Enter character name"
            v-validate="'required|min:1|max:50'"
            :class="{'form-control': true, 'error': errors.has('search') }"
          />
          <b-tooltip placement="bottom" target="search">{{ getErrorMsg('search') }}</b-tooltip>
        </div>

        <div class="mt-4">
          <epic-spinner
            v-if="isLoading"
            :animation-duration="2000"
            :dot-size="15"
            :dots-num="5"
            color="black"
          />
          <span
            v-if="!isLoading"
          >Found {{searchCount}} characters. {{searchResult.length}} listed below.</span>
        </div>
      </b-col>
      <b-col sm="12" md="6" lg="6">
        <b-card
          border-variant="dark"
          bg-variant="info"
          text-variant="white"
          header="Ingame Character Statistics"
          class="text-center"
        >
          <b-card-text>
            <span class="float-left">Total Characters</span>
            <span class="float-right">{{GetTotalCharacters}}</span>
          </b-card-text>
        </b-card>
      </b-col>
    </b-row>
    <b-row>
      <b-card-group class="card-member">
        <b-col
          v-for="(character, index) in GetSortedCharacters"
          :key="index"
          :sm="12"
          :md="12"
          :lg="12"
        >
          <character-component
            :character="character"
            :realm="GetSelectedRealm"
            :query="GetQuery"
            :user="user"
          ></character-component>
        </b-col>
        <guild-component :user="user" />
        <character-armory />
        <character-inventory />
      </b-card-group>
    </b-row>
  </b-container>
</template>

<script>
import _ from "lodash";
import moment from "moment";
import { HollowDotsSpinner } from "epic-spinners";
import GuildComponent from "@/components/Admin/Guilds/Views/GuildComponent";
import CharacterArmoryComponent from "@/components/Armory/Characters/CharacterArmoryComponent";
import CharacterInventoryComponent from "@/components/Admin/Characters/Views/CharacterInventoryComponent";
import UserHelper from "@/helpers/UserHelper";

export default {
  props: ["user", "roles", "realms"],
  data() {
    return {
      searchQuery: "",
      isTyping: false,
      searchResult: [],
      searchCount: 0,
      isLoading: false
    };
  },
  components: {
    "epic-spinner": HollowDotsSpinner,
    "guild-component": GuildComponent,
    "character-armory": CharacterArmoryComponent,
    "character-inventory": CharacterInventoryComponent
  },
  watch: {
    searchQuery: _.debounce(function() {
      this.isTyping = false;
    }, 1000),
    isTyping: async function(value) {
      if (!value && this.searchQuery.length > 0 && !this.isLoading) {
        this.$router.replace({
          query: { realm: this.GetRealmId, query: this.searchQuery }
        });
        await this.SearchCharacters(this.searchQuery);
      }
    },
    GetQuery: function(val) {
      if (this.searchQuery != val) {
        this.SearchCharacters(val);
      }
    },
    GetSelectedRealm: function(val, old) {
      if (!val || !old) return;

      if (val.id != old.id) {
        this.SearchCharacters(this.searchQuery);
      }
    },
    CanModerate() {
      return UserHelper.IsAdmin() || UserHelper.IsModerator();
    }
  },
  computed: {
    GetTotalCharacters() {
      return this.$store.getters["stats/GetTotalCharacters"](this.GetRealmId);
    },
    GetSortedCharacters() {
      const characters = [...this.searchResult];
      return characters.sort((a, b) => {
        if (a.online > b.online) return -1;
        if (a.online < b.online) return 1;

        if (a.guid < b.guid) return -1;
        if (a.guid > b.guid) return 1;
      });
    },
    GetQuery() {
      return this.$route.query.query;
    },
    GetRealmId() {
      return parseInt(this.$route.query.realm);
    },
    GetSelectedRealm() {
      return this.realms.find(x => x.id == this.GetRealmId);
    }
  },
  methods: {
    getErrorMsg(field) {
      return this.errors.first(field);
    },
    async SearchCharacters(searchQuery) {
      if (!searchQuery || !this.GetSelectedRealm) return;

      const result = await this.$validator.validateAll();
      if (!result) return;

      this.isLoading = true;
      try {
        await this.$store
          .dispatch("user/characters/GetAllCharactersByName", {
            RealmType: this.GetRealmId,
            Name: searchQuery
          })
          .then(result => {
            this.isLoading = false;
            const { characters, count } = result;
            this.searchCount = count;
            this.searchResult = characters;

            this.CheckGuildQuery();
            this.CheckArmoryQuery();
            this.CheckInventoryQuery();
          });
      } finally {
        this.isLoading = false;
      }
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
          Realm: this.GetSelectedRealm,
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
          Realm: this.GetSelectedRealm,
          Character: character
        })
        .then(() => this.$bvModal.show("armory-modal"));
    },
    CanShowInventory(user, character) {
      return this.CanModerate || (user && user.accountId === character.account);
    },
    CheckInventoryQuery() {
      const query = this.$route.query;
      if (!query) return;

      const inventory = query.showInventory;
      if (!inventory) return;

      const character = this.GetSortedCharacters.find(
        x => x.name === inventory
      );
      if (!character) return;

      if (!this.CanShowInventory(this.user, character)) return;

      this.$store
        .dispatch("armory/ShowInventoryComponent", {
          Realm: this.GetSelectedRealm,
          Character: character
        })
        .then(() => this.$bvModal.show("inventory-modal"));
    }
  },
  created() {
    const query = this.GetQuery;
    if (query) {
      this.searchQuery = query;
      this.SearchCharacters(query);
    }
  }
};
</script>
