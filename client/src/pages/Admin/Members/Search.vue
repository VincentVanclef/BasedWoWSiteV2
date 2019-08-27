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
            placeholder="Enter member name"
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
            <span class="float-left">Total members</span>
            <span class="float-right">{{GetTotalUserCount}}</span>
          </b-card-text>
        </b-card>
      </b-col>
    </b-row>
    <b-row>
      <b-card-group class="card-member">
        <b-col v-for="(member, index) in searchResult" :key="index" sm="12" md="6" lg="6">
          <b-card no-body border-variant="dark" class="mt-2 mb-2">
            <b-card-header
              header-bg-variant="info"
              header-text-variant="white"
              class="text-capitalize click-able"
              @click="searchUser(member.userName)"
            >{{member.userName}}</b-card-header>

            <b-card-body>
              <b-list-group>
                <b-list-group-item>
                  Firstname:
                  <span class="float-right">{{member.firstname}}</span>
                </b-list-group-item>
                <b-list-group-item>
                  Lastname:
                  <span class="float-right">{{member.lastname}}</span>
                </b-list-group-item>
                <b-list-group-item>
                  Email:
                  <span class="float-right">{{member.email}}</span>
                </b-list-group-item>
                <b-list-group-item>
                  Joindate:
                  <span class="float-right">{{GetDate(member.joinDate)}}</span>
                </b-list-group-item>
              </b-list-group>
            </b-card-body>

            <b-card-footer
              footer-variant="info"
              footer-bg-variant="info"
              footer-text-variant="white"
            >
              <b-row>
                <b-col sm="12" md="6" lg="4" class="mt-2">
                  <b-button variant="dark" block>Manage Profile</b-button>
                </b-col>
                <b-col sm="12" md="6" lg="4" class="mt-2">
                  <b-button variant="dark" block @click="OpenRoleEditor(member)">Manage Roles</b-button>
                </b-col>
                <b-col sm="12" md="6" lg="4" class="mt-2">
                  <b-button variant="dark" block>Manage Account</b-button>
                </b-col>
              </b-row>
            </b-card-footer>
          </b-card>
        </b-col>
      </b-card-group>
    </b-row>

    <edit-roles-component :roles="roles" ref="editRolesComponent"></edit-roles-component>
  </b-container>
</template>

<script>
import _ from "lodash";
import moment from "moment";
import { HollowDotsSpinner } from "epic-spinners";
import EditRolesComponent from "@/components/Admin/Members/EditRolesComponent";

export default {
  props: ["roles"],
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
    "edit-roles-component": EditRolesComponent
  },
  watch: {
    searchQuery: _.debounce(function() {
      this.isTyping = false;
    }, 1000),
    isTyping: function(value) {
      if (!value && this.searchQuery.length > 0) {
        this.searchUser(this.searchQuery);
      }
    }
  },
  computed: {
    GetTotalUserCount() {
      return this.$store.getters["user/GetTotalUserCount"];
    }
  },
  methods: {
    OpenRoleEditor(member) {
      this.$refs.editRolesComponent.show(member);
    },
    searchUser(searchQuery) {
      this.searchQuery = searchQuery;
      this.isLoading = true;
      this.$store.dispatch("admin/SearchUsers", searchQuery).then(result => {
        this.isLoading = false;
        const { members, count } = result;
        this.searchCount = count;
        this.searchResult = members;
      });
    },
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    }
  },
  created() {}
};
</script>

<style scoped>
.card-member {
  width: 100%;
}
</style>