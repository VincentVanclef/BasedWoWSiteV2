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
            placeholder="Enter guild name"
            v-validate="'required|min:1|max:50'"
            :class="{'form-control': true, 'error': errors.has('search') }"
          />
          <b-tooltip
            v-if="errors.has('search')"
            placement="bottom"
            target="search"
          >{{ getErrorMsg('search') }}</b-tooltip>
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
          >Found {{searchCount}} guilds. {{searchResult.length}} listed below.</span>
        </div>
      </b-col>
      <b-col sm="12" md="6" lg="6">
        <b-card
          border-variant="dark"
          bg-variant="info"
          text-variant="white"
          header="Ingame Guilds Statistics"
          class="text-center"
          v-if="!Loading"
        >
          <b-card-text>
            <span class="float-left">Total Guilds</span>
            <span class="float-right">{{GetTotalGuilds}}</span>
          </b-card-text>
        </b-card>
      </b-col>
    </b-row>
    <b-row>
      <b-card-group class="card-member">
        <b-col v-for="(guild, index) in GetSortedGuilds" :key="index" :sm="12" :md="12" :lg="12">
          <b-card no-body border-variant="dark" class="mt-2 mb-2">
            <b-card-header
              header-bg-variant="info"
              header-text-variant="dark"
              class="text-capitalize font-weight-bold click-able"
              @click="OpenGuildViewComponent(guild)"
            >
              <text-highlight :queries="searchQuery">[{{guild.name}}]</text-highlight>
              <span class="float-right">
                <b-badge variant="dark">{{guild.guildMembers.length}} Members</b-badge>
              </span>
            </b-card-header>
          </b-card>
        </b-col>
      </b-card-group>
    </b-row>
  </b-container>
</template>

<script>
import _ from "lodash";
import { HollowDotsSpinner } from "epic-spinners";

export default {
  props: ["user", "realms"],
  data() {
    return {
      Loading: true,

      searchQuery: "",
      isTyping: false,
      searchResult: [],
      searchCount: 0,
      isLoading: false
    };
  },
  components: {
    "epic-spinner": HollowDotsSpinner
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
        await this.SearchGuilds(this.searchQuery);
      }
    },
    GetQuery: function(val) {
      if (this.searchQuery != val) {
        this.SearchGuilds(val);
      }
    },
    GetSelectedRealm: function(val, old) {
      if (!val || !old) return;

      if (val.id != old.id) {
        this.SearchGuilds(this.searchQuery);
      }
    }
  },
  computed: {
    GetTotalGuilds() {
      return this.$store.getters["stats/GetTotalGuilds"](this.GetRealmId);
    },
    GetSortedGuilds() {
      return this.searchResult;
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
    async SearchGuilds(searchQuery) {
      if (!searchQuery || !this.GetSelectedRealm) return;

      this.searchQuery = searchQuery;

      const result = await this.$validator.validateAll();
      if (!result) return;

      this.isLoading = true;
      try {
        await this.$store
          .dispatch("user/guild/GetAllGuildsByName", {
            RealmType: this.GetRealmId,
            GuildName: searchQuery
          })
          .then(result => {
            this.isLoading = false;
            const { guilds, count } = result;
            this.searchCount = count;
            this.searchResult = guilds;

            this.CheckGuildQuery();
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
      const guild = this.GetSortedGuilds.find(x => x.name == guildName);
      if (!guild) return;
      this.$store
        .dispatch("user/guild/ShowGuildComponent", {
          Realm: this.GetSelectedRealm,
          Guild: guild
        })
        .then(() => this.$bvModal.show("guild-modal"));
    },
    OpenGuildViewComponent(guild) {
      this.$store
        .dispatch("user/guild/ShowGuildComponent", {
          Realm: this.GetSelectedRealm,
          Guild: guild
        })
        .then(() => this.$bvModal.show("guild-modal"));
    }
  },
  created() {
    for (const realm of this.realms) {
      this.$store
        .dispatch("stats/GetTotalGuilds", realm.id)
        .finally(() => (this.Loading = false));
    }

    const query = this.GetQuery;
    if (query) {
      this.searchQuery = query;
      this.SearchGuilds(query);
    }
  }
};
</script>
