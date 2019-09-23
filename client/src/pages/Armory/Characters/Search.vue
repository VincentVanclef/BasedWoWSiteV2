<template>
  <b-container>
    <b-row>
      <b-col sm="12" md="6" lg="6">
        <div>
          <label class="control-label">Search {{GetSelectedRealm.name}} Armory</label>
          <b-input
            type="text"
            @input="isTyping = true"
            v-model="searchQuery"
            placeholder="Enter character name"
          />
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
      <character-view-component
        v-if="searchResult.length > 0"
        :user="user"
        :characters="searchResult"
        :roles="roles"
        :realms="realms"
        :selectedRealm="GetSelectedRealm"
        :sm="12"
        :md="12"
        :lg="12"
        :query="GetQuery"
      ></character-view-component>
    </b-row>
  </b-container>
</template>

<script>
import _ from "lodash";
import moment from "moment";
import { HollowDotsSpinner } from "epic-spinners";
import CharacterViewComponent from "@/components/Armory/Characters/CharacterViewComponent";

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
    "character-view-component": CharacterViewComponent
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
    }
  },
  computed: {
    GetTotalCharacters() {
      return this.$store.getters["stats/GetTotalCharacters"](this.GetRealmId);
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
    async SearchCharacters(searchQuery) {
      if (!searchQuery || searchQuery.length < 1) return;
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
          });
      } finally {
        this.isLoading = false;
      }
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
