<template>
  <b-container>
    <b-row>
      <b-col sm="12" md="6" lg="6">
        <div>
          <label class="control-label">Search Armory</label>
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
          >Found {{searchCount}} results. {{searchResult.length}} listed below.</span>
        </div>
      </b-col>
      <b-col sm="12" md="6" lg="6">
        <b-card
          border-variant="dark"
          bg-variant="info"
          text-variant="white"
          header="Ingame Account Statistics"
          class="text-center"
        >
          <b-card-text>
            <span class="float-left">Total Accounts</span>
            <span class="float-right">{{GetTotalAccounts}}</span>
          </b-card-text>
        </b-card>
      </b-col>
    </b-row>
    <b-row>
      <account-view-component
        v-if="searchResult.length > 0"
        :user="user"
        :accounts="searchResult"
        :roles="roles"
        :realms="realms"
        :sm="12"
        :md="6"
        :lg="6"
        :query="GetQuery"
      ></account-view-component>
    </b-row>
  </b-container>
</template>

<script>
import _ from "lodash";
import moment from "moment";
import { HollowDotsSpinner } from "epic-spinners";
import AccountViewComponent from "@/components/Admin/Accounts/AccountViewComponent";

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
    "account-view-component": AccountViewComponent
  },
  watch: {
    searchQuery: _.debounce(function() {
      this.isTyping = false;
    }, 1000),
    isTyping: async function(value) {
      if (!value && this.searchQuery.length > 0 && !this.isLoading) {
        this.$router.replace({ query: { query: this.searchQuery } });
        await this.SearchAccount(this.searchQuery);
      }
    },
    GetQuery: function(val) {
      if (this.searchQuery != val) {
        this.SearchAccount(val);
      }
    }
  },
  computed: {
    GetTotalAccounts() {
      return this.$store.getters["stats/GetTotalAccounts"];
    },
    GetQuery() {
      return this.$route.query.query;
    }
  },
  methods: {
    OpenRoleEditor(account) {
      if (!this.IsSuperAdmin) {
        this.$toasted.error("You are not authorized to edit account roles.");
        return;
      }

      this.$refs.editRolesComponent.show(account);
    },
    async SearchAccount(searchQuery) {
      this.searchQuery = searchQuery;
      this.isLoading = true;
      try {
        await this.$store
          .dispatch("user/account/SearchAccounts", searchQuery)
          .then(result => {
            this.isLoading = false;
            const { accounts, count } = result;
            this.searchCount = count;
            this.searchResult = accounts;
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
      this.SearchAccount(query);
    }
  }
};
</script>
