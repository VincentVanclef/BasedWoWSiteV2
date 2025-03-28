<template>
  <div class="container">
    <div class="profile" v-if="user">
      <b-row>
        <b-col cols="3">
          <div class="gravatar">
            <vue-gravatar
              class="gravatar-image"
              :email="user.email"
              :style="{ background: IsUserOnline ? 'green' : 'white' }"
              alt="Gravatar"
              default-img="https://i.imgur.com/0AwrvCm.jpg"
            />
          </div>
        </b-col>
        <b-col cols="9" class="user-information">
          <p>User Information</p>
          <b-row>
            <b-col cols="1">
              <img
                class="profile-icon"
                alt="profile icon"
                :src="require('@/assets/images/user.png')"
                title="Name displayed on the site"
              />
            </b-col>
            <b-col cols="3">Nickname</b-col>
            <b-col cols="4">
              <div class="player-nickname">{{ user.username }}</div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img
                class="profile-icon"
                alt="profile icon"
                :src="require('@/assets/images/user.png')"
                title="Firstname"
              />
            </b-col>
            <b-col cols="3">Firstname</b-col>
            <b-col cols="4">
              <div class="player-nickname">{{ user.firstname }}</div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img
                class="profile-icon"
                alt="profile icon"
                :src="require('@/assets/images/user.png')"
                title="Firstname"
              />
            </b-col>
            <b-col cols="3">Lastname</b-col>
            <b-col cols="4">
              <div class="player-nickname">{{ user.lastname }}</div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img
                class="profile-icon"
                alt="profile icon"
                :src="require('@/assets/images/world.png')"
                title="Firstname"
              />
            </b-col>
            <b-col cols="3">Location</b-col>
            <b-col cols="4">
              <div
                :class="user.location ? 'player-nickname' : ''"
              >{{ user.location ? user.location : "Unknown" }}</div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img
                class="profile-icon"
                alt="profile icon"
                :src="require('@/assets/images/mail-small.png')"
                title="Firstname"
              />
            </b-col>
            <b-col cols="3">Email</b-col>
            <b-col cols="6">
              <div class="text-color-purple">{{ user.email }}</div>
            </b-col>
          </b-row>
          <b-row class="form-group">
            <b-col cols="1">
              <img
                class="profile-icon"
                alt="profile icon"
                :src="require('@/assets/images/rank.png')"
              />
            </b-col>
            <b-col cols="3">Website Roles</b-col>
            <b-col>
              <span v-for="role in user.roles" :key="role.id">
                <font :color="GetRoleColor(role)">[{{role}}]</font>
              </span>
            </b-col>
          </b-row>
          <p>Account Information</p>
          <b-row>
            <b-col cols="1">
              <img
                class="profile-icon"
                alt="profile icon"
                :src="require('@/assets/images/expansion.png')"
              />
            </b-col>
            <b-col cols="3">Expansion</b-col>
            <b-col cols="5">
              <img :src="require('@/assets/images/Wrath-Logo-Small.png')" />
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img
                class="profile-icon"
                alt="profile icon"
                :src="require('@/assets/images/shield.png')"
              />
            </b-col>
            <b-col cols="3">Account Status</b-col>
            <b-col class="text-success">Active</b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img
                class="profile-icon"
                alt="profile icon"
                :src="require('@/assets/images/date.png')"
              />
            </b-col>
            <b-col cols="3">Join Date</b-col>
            <b-col>{{ GetDate(user.joinDate) }}</b-col>
          </b-row>
          <b-row class="form-group">
            <b-col cols="1">
              <img
                class="profile-icon"
                alt="profile icon"
                :src="require('@/assets/images/lightning.png')"
              />
            </b-col>
            <b-col cols="3">Total Votes</b-col>
            <b-col cols="3" class="text-color-green">
              <strong>{{ user.totalVotes }}</strong>
            </b-col>
          </b-row>
        </b-col>
      </b-row>
      <hr class="border-dark" />
      <b-button
        variant="warning"
        class="font-weight-bold"
        block
        @click="OpenCharacterEditor(user.account)"
      >View Characters</b-button>
      <character-view-component :realms="realms" :user="user" ref="characerViewComponent"></character-view-component>
      <hr class="border-dark" />
      <b-button v-b-toggle="'account-access'" variant="dark" block>Toggle Account Access</b-button>
      <b-collapse :id="'account-access'">
        <b-list-group-item>
          <b-container>
            <b-row>
              <b-table
                responsive
                striped
                bordered
                :items="user.account.accountAccess"
                :fields="TableFields"
                :sort-compare-options="{ numeric: true, sensitivity: 'base' }"
              >
                <template v-slot:cell(realmId)="data">{{GetRealmNameById(data.value)}}</template>
                <template v-slot:cell(gmlevel)="data">
                  <font :color="GetGameRankColor(data.value)">{{GetGameRankName(data.value)}}</font>
                </template>
              </b-table>
            </b-row>
          </b-container>
        </b-list-group-item>
      </b-collapse>
      <b-row v-if="IsAdmin">
        <b-col sm="6" lg="4" md="4" class="mt-3 mb-3">
          <b-card
            header="Admin Shortcuts"
            header-bg-variant="dark"
            header-text-variant="white"
            border-variant="dark"
            no-body
            align="center"
          >
            <b-button-group vertical>
              <b-button
                variant="warning"
                block
                squared
                text-variant="primary"
                class="font-weight-bold"
                :to="'/admin/members/Search?query=' + user.username"
              >Edit Member</b-button>
              <b-button
                variant="warning"
                block
                squared
                text-variant="primary"
                class="font-weight-bold"
                :to="'/admin/accounts/Search?query=' + user.accountId"
              >Edit Account</b-button>
            </b-button-group>
          </b-card>
        </b-col>
      </b-row>
    </div>
  </div>
</template>

<script>
import Gravatar from "vue-gravatar";
import moment from "moment";
import UserHelper from "@/helpers/UserHelper";
import CharactersViewComponent from "@/components/Admin/Characters/CharactersViewComponent";

export default {
  props: ["user", "realms"],
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
    "vue-gravatar": Gravatar,
    "character-view-component": CharactersViewComponent
  },
  computed: {
    IsAdmin() {
      return UserHelper.IsAdmin();
    },
    GetOnlineUsers() {
      return this.$store.getters["stats/GetOnlineUsers"];
    },
    IsUserOnline() {
      return this.GetOnlineUsers.some(x => x.id == this.user.id);
    }
  },
  methods: {
    async OpenCharacterEditor(account) {
      this.$refs.characerViewComponent.show(account);
      try {
        await this.$router.replace({
          query: Object.assign({}, this.$route.query, {
            characters: account.username
          })
        });
      } catch (e) {}
    },
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    },
    GetRoleColor(role) {
      return UserHelper.GetRoleColor(role);
    },
    GetGameRankColor(rank) {
      return UserHelper.GetGameRankColor(rank);
    },
    GetGameRankName(rank) {
      return UserHelper.GetGameRankName(rank);
    },
    GetRealmById(id) {
      return this.realms.find(x => x.id == id);
    },
    GetRealmNameById(id) {
      const realm = this.GetRealmById(id);
      return realm ? realm.name : "Global";
    },
    CheckCharacterQuery() {
      const query = this.$route.query;
      if (!query) return;
      const character = query.characters;
      if (!character) return;

      this.OpenCharacterEditor(this.user.account);
    }
  },
  mounted() {
    this.CheckCharacterQuery();
  }
};
</script>


<style scoped>
.gravatar-image {
  width: 100%;
  height: 100%;
  max-width: 130px;
  max-height: 130px;
  border: 1px solid #cbcbcb;
  padding: 0.3vw;
  -webkit-border-radius: 4px;
  -moz-border-radius: 4px;
  border-radius: 4px;
  -webkit-box-shadow: -2px 2px 6px -1px rgba(0, 0, 0, 0.3);
  -moz-box-shadow: -2px 2px 6px -1px rgba(0, 0, 0, 0.3);
  -o-box-shadow: -2px 2px 6px -1px rgba(0, 0, 0, 0.3);
  box-shadow: -2px 2px 6px -1px rgba(0, 0, 0, 0.3);
}

.text-color-green {
  color: #408080;
  text-transform: capitalize;
}

.text-color-purple {
  color: #7289da;
}

.player-nickname {
  color: #c47e2c;
  text-transform: capitalize;
}

.user-information {
  padding-right: 0 !important;
}

.profile-update-button {
  background: none;
  color: inherit;
  border: none;
  padding: 0;
  font: inherit;
  cursor: pointer;
  outline: inherit;
}

.profile-update-input {
  min-width: 60px;
}

.update-buttons {
  margin-left: 1px;
}
</style>