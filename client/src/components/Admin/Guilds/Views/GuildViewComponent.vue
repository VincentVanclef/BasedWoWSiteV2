<template>
  <b-container>
    <b-row class="text-capitalize">
      <b-col>
        <b-list-group>
          <b-list-group-item variant="primary">
            <h3 class="font-weight-bold">Guild Informations</h3>
          </b-list-group-item>
          <b-list-group-item variant="primary">
            Level:
            <span class="float-right font-weight-bold">{{guild.level}}</span>
          </b-list-group-item>
          <b-list-group-item variant="primary">
            EXP:
            <span class="float-right font-weight-bold">{{guild.exp}}</span>
          </b-list-group-item>
          <b-list-group-item variant="primary">
            Bank Money:
            <span class="float-right font-weight-bold">{{GetMoney(guild.bankMoney)}}</span>
          </b-list-group-item>
          <b-list-group-item variant="primary">
            Total Members:
            <span class="float-right font-weight-bold">{{guild.guildMembers.length}}</span>
          </b-list-group-item>
          <b-list-group-item variant="primary">
            Created Date:
            <span class="float-right font-weight-bold">{{GetDate(guild.createDate)}}</span>
          </b-list-group-item>
          <b-list-group-item variant="primary">
            Motd:
            <span class="float-right font-weight-bold">{{guild.motd}}</span>
          </b-list-group-item>
          <b-list-group-item variant="primary">
            Info:
            <span class="float-right font-weight-bold">{{guild.info}}</span>
          </b-list-group-item>
        </b-list-group>
      </b-col>
      <b-col>
        <b-list-group>
          <b-list-group-item variant="danger">
            <h3 class="font-weight-bold">Guild Ranks</h3>
          </b-list-group-item>
          <b-list-group-item variant="danger" v-for="rank in guild.guildRanks" :key="rank.id">
            <b-badge pill variant="dark">{{rank.rankName}}</b-badge>
            <span class="float-right font-weight-bold">
              Members in rank:
              <b-badge pill variant="dark">{{GetMembersInRank(rank.id)}}</b-badge>
            </span>
          </b-list-group-item>
        </b-list-group>
      </b-col>
    </b-row>
    <b-row class="mt-3">
      <b-container>
        <b-row>
          <b-col sm="12" md="12" lg="4">
            <b-button
              class="mb-3"
              block
              variant="dark"
              @click="OpenGuildVault()"
              v-if="CanModerate || IsUserInGuild"
            >
              <i class="fas fa-university"></i> Open Guild Vault
            </b-button>
          </b-col>
          <b-col sm="12" md="12" lg="4">
            <b-button
              class="mb-3"
              block
              variant="dark"
              @click="OpenGuildMoneyLogs()"
              v-if="CanModerate || IsUserInGuild"
            >
              <i class="fas fa-clipboard"></i> View Guild Money Log
            </b-button>
          </b-col>
          <b-col sm="12" md="12" lg="4">
            <b-button
              class="mb-3"
              block
              variant="dark"
              @click="OpenGuildEventLogs()"
              v-if="CanModerate || IsUserInGuild"
            >
              <i class="fas fa-clipboard"></i> View Guild Event Log
            </b-button>
          </b-col>
        </b-row>
        <b-button v-b-toggle="'view-members'" variant="dark" block>
          Toggle Members
          <b-badge pill variant="warning">{{guild.guildMembers.length}}</b-badge>
        </b-button>
        <b-collapse id="view-members" class="container-fluid pr-0 pl-0">
          <b-row>
            <b-col v-for="member in GetMembersByRank" :key="member.guid" sm="12" md="6" lg="6">
              <b-list-group class="mt-3">
                <b-list-group-item>
                  <span class="float-right font-weight-bolder">
                    Guild Rank
                    <b-badge pill variant="dark">{{GetMemberRank(member.rankId).rankName}}</b-badge>
                  </span>
                </b-list-group-item>
                <!-- <b-collapse :id="'view-member-' + member.guid"> -->
                <b-list-group-item class="text-dark">
                  <character-component :character="member.character" :realm="realm"></character-component>
                </b-list-group-item>
                <!-- </b-collapse> -->
              </b-list-group>
            </b-col>
          </b-row>
        </b-collapse>
      </b-container>
    </b-row>
    <guild-bank />
    <guild-event-logs ref="guildEventLogsComponent" :guild="guild" :realm="realm" />
    <guild-money-logs ref="guildMoneyLogsComponent" :guild="guild" :realm="realm" />
  </b-container>
</template>

<script>
import GuildBankViewComponent from "./GuildBankViewComponent";
import GuildEventLogsComponent from "./GuildEventLogsComponent";
import GuildMoneyLogsComponent from "./GuildMoneyLogsComponent";
import UserHelper from "@/helpers/UserHelper";
import moment from "moment";

export default {
  name: "GuildViewComponent",
  props: ["guild", "realm", "user"],
  data() {
    return {};
  },
  components: {
    "guild-bank": GuildBankViewComponent,
    "guild-event-logs": GuildEventLogsComponent,
    "guild-money-logs": GuildMoneyLogsComponent
  },
  computed: {
    GetGuildLeader() {
      const leaderGuid = this.guild.leaderGuid;
      const leader = this.guild.guildMembers.find(x => x.guid == leaderGuid);
      return leader;
    },
    GetMembersByRank() {
      const members = [...this.guild.guildMembers];
      members.sort((a, b) => {
        if (a.rankId > b.rankId) return 1;
        if (a.rankId < b.rankId) return -1;

        if (a.online > b.online) return 1;
        if (a.online < b.online) return -1;

        if (a.guid > b.guid) return -1;
        if (a.guid < b.guid) return 1;
      });
      return members;
    },
    CanModerate() {
      return UserHelper.IsAdmin() || UserHelper.IsModerator();
    },
    GetUser() {
      return this.$store.getters["user/GetUser"];
    },
    IsUserInGuild() {
      return (
        this.GetUser &&
        this.guild.guildMembers.some(
          x => x.character.account === this.GetUser.accountId
        )
      );
    }
  },
  methods: {
    OpenGuildVault() {
      if (!this.CanModerate && !this.IsUserInGuild) return;

      this.$store
        .dispatch("user/guild/ShowGuildBankComponent", {
          Realm: this.realm,
          Guild: this.guild
        })
        .then(() => this.$bvModal.show("guild-bank-modal"));
    },
    OpenGuildMoneyLogs() {
      this.$refs.guildMoneyLogsComponent.show();
    },
    OpenGuildEventLogs() {
      this.$refs.guildEventLogsComponent.show();
    },
    GetDate(unix) {
      return moment(unix * 1000).format("MMMM Do YYYY, HH:mm:ss");
    },
    GetMembersInRank(rank) {
      const members = this.guild.guildMembers;
      const count = members.filter(x => x.rankId === rank).length;
      return count;
    },
    GetMemberRank(rankId) {
      const ranks = this.guild.guildRanks;
      const rank = ranks.find(x => x.id === rankId);
      return rank;
    },
    GetMoney(money) {
      const SILVER = 100;
      const GOLD = 100 * SILVER;
      return (
        parseInt(money / GOLD) +
        "g" +
        parseInt((money % GOLD) / SILVER) +
        "s" +
        parseInt((money % GOLD) % SILVER) +
        "c"
      );
    },
    CheckArmoryQuery() {
      const query = this.$route.query;
      if (!query) return;

      const showArmory = query.showArmory;
      if (!showArmory) return;

      const character = this.GetMembersByRank.find(
        x => x.character.name === showArmory
      );
      if (!character) return;

      this.$store
        .dispatch("armory/ShowArmoryComponent", {
          Realm: this.realm,
          Character: character.character
        })
        .then(() => this.$bvModal.show("armory-modal"));
    },
    CheckGuildVaultQuery() {
      const query = this.$route.query;
      if (!query) return;

      const showVault = query.showVault;
      if (!showVault) return;

      this.OpenGuildVault();
    }
  },
  created() {
    this.CheckArmoryQuery();
    this.CheckGuildVaultQuery();
  }
};
</script>