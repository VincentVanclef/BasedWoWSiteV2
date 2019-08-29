<template>
  <b-container>
    <b-row>
      <b-col sm="12" md="6" lg="6">
        <div>
          <label class="control-label">Search Website Member</label>
          <b-input
            type="text"
            @input="isTyping = true"
            v-model="searchQuery"
            placeholder="Enter username, firstname or email"
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
          >Found {{searchCount}} members. {{searchResult.length}} listed below.</span>
        </div>
      </b-col>
      <b-col sm="12" md="6" lg="6">
        <b-card
          border-variant="dark"
          bg-variant="info"
          text-variant="white"
          header="Website Member Statistics"
          class="text-center"
        >
          <b-card-text>
            <span class="float-left">Total Members</span>
            <span class="float-right">{{GetTotalUserCount}}</span>
          </b-card-text>
        </b-card>
      </b-col>
    </b-row>
    <b-row>
      <member-view-component
        :user="user"
        :members="searchResult"
        :roles="roles"
        :sm="12"
        :md="6"
        :lg="6"
        :query="searchQuery"
      ></member-view-component>
    </b-row>
  </b-container>
</template>

<script>
import _ from "lodash";
import moment from "moment";
import { HollowDotsSpinner } from "epic-spinners";
import MemberViewComponent from "@/components/Admin/Members/MemberViewComponent";

export default {
  props: ["roles", "user"],
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
    "member-view-component": MemberViewComponent
  },
  watch: {
    searchQuery: _.debounce(function() {
      this.isTyping = false;
    }, 1000),
    isTyping: async function(value) {
      if (!value && this.searchQuery.length > 0) {
        await this.SearchUser(this.searchQuery);
      }
    }
  },
  computed: {
    GetTotalUserCount() {
      return this.$store.getters["stats/GetTotalUserCount"];
    }
  },
  methods: {
    OpenRoleEditor(member) {
      if (!this.IsSuperAdmin) {
        this.$toasted.error("You are not authorized to edit member roles.");
        return;
      }

      this.$refs.editRolesComponent.show(member);
    },
    async SearchUser(searchQuery) {
      this.searchQuery = searchQuery;
      this.isLoading = true;
      this.$router.replace({ query: { query: searchQuery } });
      try {
        await this.$store
          .dispatch("admin/SearchUsers", searchQuery)
          .then(result => {
            this.isLoading = false;
            const { members, count } = result;
            this.searchCount = count;
            this.searchResult = members;
          });
      } finally {
        this.isLoading = false;
      }
    }
  },
  created() {
    const query = this.$route.query.query;
    if (query) {
      this.searchQuery = query;
      this.SearchUser(query);
    }
  }
};
</script>

<style scoped>
.card-member {
  width: 100%;
}
</style>