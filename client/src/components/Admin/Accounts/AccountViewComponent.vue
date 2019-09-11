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
              <b-button
                v-b-toggle="'account-access-' + index"
                variant="primary"
                block
              >Toggle Account Access</b-button>
              <b-collapse :id="'account-access-' + index">
                <b-row class="mt-3">
                  <b-container>
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
                  </b-container>
                </b-row>
              </b-collapse>
            </b-list-group-item>
          </b-list-group>
        </b-card-body>

        <b-card-footer footer-variant="info" footer-bg-variant="info" footer-text-variant="white">
          <b-row>
            <b-col sm="12" md="6" lg="6" class="mt-2">
              <b-button variant="success" block @click="OpenRoleEditor(account)">Manage Access</b-button>
            </b-col>
            <b-col sm="12" md="6" lg="6" class="mt-2">
              <b-button variant="success" block disabled>Manage Account</b-button>
            </b-col>
            <b-col sm="12" md="6" lg="6" class="mt-2">
              <b-button
                variant="warning"
                block
                :to="'/admin/members/search?query=' + account.email"
              >View Profile</b-button>
            </b-col>
            <b-col sm="12" md="6" lg="6" class="mt-2">
              <b-button
                variant="warning"
                block
                @click="OpenCharacterEditor(account)"
              >View Characters</b-button>
            </b-col>

            <b-col sm="12" md="6" lg="6" class="mt-2">
              <b-button variant="danger" block @click="OpenAccountBanEditor(account)">Ban</b-button>
            </b-col>
            <b-col sm="12" md="6" lg="6" class="mt-2">
              <b-button variant="light" block @click="UnBanAccount(account)">Unban</b-button>
            </b-col>

            <b-col sm="12" md="6" lg="6" class="mt-2">
              <b-button variant="danger" block @click="OpenAccountMuteEditor(account)">Mute</b-button>
            </b-col>
            <b-col sm="12" md="6" lg="6" class="mt-2">
              <b-button variant="light" block @click="UnMuteAccount(account)">Unmute</b-button>
            </b-col>
          </b-row>
        </b-card-footer>
      </b-card>
    </b-col>
    <edit-access-component :roles="roles" :realms="realms" ref="editAccessComponent"></edit-access-component>
    <character-view-component :roles="roles" :realms="realms" ref="characerViewComponent"></character-view-component>
    <account-ban-component ref="accountBanComponent"></account-ban-component>
    <account-mute-component ref="accountMuteComponent"></account-mute-component>
  </b-card-group>
</template>

<script>
import moment from "moment";
import UserHelper from "@/helpers/UserHelper";
import CharactersViewComponent from "@/components/Admin/Characters/CharactersViewComponent";
import EditAccessComponent from "@/components/Admin/Accounts/Actions/EditAccessComponent";
import AccountBanComponent from "@/components/Admin/Accounts/Actions/AccountBanComponent";
import AccountMuteComponent from "@/components/Admin/Accounts/Actions/AccountMuteComponent";

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
    "edit-access-component": EditAccessComponent,
    "character-view-component": CharactersViewComponent,
    "account-ban-component": AccountBanComponent,
    "account-mute-component": AccountMuteComponent
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
    OpenCharacterEditor(account) {
      this.$refs.characerViewComponent.show(account);
    },
    OpenAccountBanEditor(account) {
      this.$refs.accountBanComponent.show(account);
    },
    OpenAccountMuteEditor(account) {
      this.$refs.accountMuteComponent.show(account);
    },
    async UnBanAccount(account) {
      const check = await this.$bvModal.msgBoxConfirm(
        `Are you sure you wish to unban ${account.username}?`,
        {
          centered: true,
          okTitle: "Yes"
        }
      );

      if (!check) return;

      const AccountId = account.id;

      await this.$store.dispatch("admin/UnBanAccount", AccountId);

      this.$toasted.success(`${account.username} has been unbanned.`);
    },
    async UnMuteAccount(account) {
      const check = await this.$bvModal.msgBoxConfirm(
        `Are you sure you wish to unmute ${account.username}?`,
        {
          centered: true,
          okTitle: "Yes"
        }
      );

      if (!check) return;

      const AccountId = account.id;

      await this.$store.dispatch("admin/UnMuteAccount", AccountId);

      this.$toasted.success(`${account.username} has been unmuted.`);
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
  }
};
</script>