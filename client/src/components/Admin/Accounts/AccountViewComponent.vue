<template>
  <b-card-group class="card-member">
    <b-col v-for="(account, index) in OrderAccounts" :key="index" :sm="sm" :md="md" :lg="lg">
      <b-card no-body border-variant="dark" class="mt-2 mb-2">
        <b-card-header header-bg-variant="info" header-text-variant="white" class="text-capitalize">
          <text-highlight :queries="query">{{account.username}}</text-highlight>
        </b-card-header>

        <b-card-body>
          <b-list-group>
            <b-list-group-item>
              Account Id:
              <span class="float-right">
                <text-highlight :queries="query">{{account.id}}</text-highlight>
              </span>
            </b-list-group-item>
            <b-list-group-item>
              Email:
              <span class="float-right">
                <text-highlight :queries="query">{{account.email}}</text-highlight>
              </span>
            </b-list-group-item>
            <b-list-group-item>
              Last Ip:
              <span class="float-right">
                <text-highlight :queries="query">{{account.lastIp}}</text-highlight>
              </span>
            </b-list-group-item>
            <b-list-group-item>
              Last Login:
              <span class="float-right">
                <text-highlight :queries="query">{{GetDate(account.lastLogin)}}</text-highlight>
              </span>
            </b-list-group-item>
            <b-list-group-item>
              Joindate:
              <span class="float-right">{{GetDate(account.joindate)}}</span>
            </b-list-group-item>
            <b-list-group-item>
              <div class="form-group text-center">Account Access:</div>
              <b-row>
                <b-table
                  responsive
                  striped
                  bordered
                  :items="account.accountAccess"
                  :fields="TableFields"
                  :sort-compare-options="{ numeric: true, sensitivity: 'base' }"
                >
                  <span slot="realmId" slot-scope="data">{{GetRealmNameById(data.value)}}</span>
                  <span slot="gmlevel" slot-scope="data">
                    <font :color="GetGameRankColor(data.value)">{{GetGameRankName(data.value)}}</font>
                  </span>
                </b-table>
              </b-row>
            </b-list-group-item>
          </b-list-group>
        </b-card-body>

        <b-card-footer footer-variant="info" footer-bg-variant="info" footer-text-variant="white">
          <b-row>
            <b-col sm="12" md="6" lg="4" class="mt-2">
              <b-button
                variant="dark"
                block
                :to="'/admin/members/search?query=' + account.email"
              >View Profile</b-button>
            </b-col>
            <b-col sm="12" md="6" lg="4" class="mt-2">
              <b-button variant="dark" block @click="OpenRoleEditor(account)">Manage Access</b-button>
            </b-col>
            <b-col sm="12" md="6" lg="4" class="mt-2">
              <b-button variant="dark" block>Manage Account</b-button>
            </b-col>
          </b-row>
        </b-card-footer>
      </b-card>
    </b-col>
    <edit-access-component :roles="roles" :realms="realms" ref="editAccessComponent"></edit-access-component>
  </b-card-group>
</template>

<script>
import moment from "moment";
import UserHelper from "@/helpers/UserHelper";
import EditAccessComponent from "@/components/Admin/Accounts/EditAccessComponent";

export default {
  name: "AccountViewComponent",
  props: ["user", "accounts", "roles", "sm", "md", "lg", "query", "realms"],
  data() {
    return {
      TableFields: [
        //{ key: "accountId", sortable: true, tdClass: "th-accountId" },
        {
          key: "gmlevel",
          label: "Rank",
          sortable: true,
          tdClass: "th-gmlevel"
        },
        {
          key: "realmId",
          label: "Realm",
          sortable: true,
          tdClass: "th-realmid"
        }
      ]
    };
  },
  components: {
    "edit-access-component": EditAccessComponent
  },
  computed: {
    IsSuperAdmin() {
      return UserHelper.IsSuperAdmin();
    },
    OrderAccounts() {
      const temp = [...this.accounts];
      return temp.sort((a, b) => (a.id > b.id ? 1 : -1));
    }
  },
  methods: {
    GetRealmById(id) {
      return this.realms.find(x => x.id == id);
    },
    GetRealmNameById(id) {
      const realm = this.GetRealmById(id);
      return realm ? realm.name : "Global";
    },
    OpenRoleEditor(account) {
      this.$refs.editAccessComponent.show(account);
    },
    GetGameRankColor(rank) {
      return UserHelper.GetGameRankColor(rank);
    },
    GetGameRankName(rank) {
      return UserHelper.GetGameRankName(rank);
    },
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    }
  },
  created() {}
};
</script>