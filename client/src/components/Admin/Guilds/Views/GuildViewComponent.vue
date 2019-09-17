<template>
  <b-container>
    <b-row class="text-capitalize">
      <b-col>
        <b-list-group>
          <b-list-group-item variant="success">
            <h3 class="font-weight-bold">Guild Leader</h3>
          </b-list-group-item>
          <b-list-group-item variant="success" class="text-dark">
            <character-component :character="GetGuildLeader.character" :realm="realm"></character-component>
          </b-list-group-item>
        </b-list-group>
      </b-col>
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
        <b-list-group class="mt-3">
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
      <b-button v-b-toggle="'view-members'" variant="dark" block>
        Toggle Members
        <b-badge pill variant="warning">{{guild.guildMembers.length}}</b-badge>
      </b-button>
      <b-collapse id="view-members" class="container-fluid pr-0 pl-0">
        <b-row>
          <b-col v-for="member in GetMembersByRank" :key="member.guid" sm="12" md="6" lg="6">
            <b-list-group class="mt-3">
              <b-list-group-item>
                <b-button
                  v-b-toggle="'view-member-' + member.guid"
                  :variant="member.character.online === 1 ? 'success' : 'dark'"
                  block
                >
                  <span class="float-left">
                    <b-badge pill variant="light">{{member.character.name}}</b-badge>
                  </span>
                  <span class="float-right">
                    Guild Rank
                    <b-badge pill variant="light">{{GetMemberRank(member.rankId).rankName}}</b-badge>
                  </span>
                </b-button>
              </b-list-group-item>
              <b-collapse :id="'view-member-' + member.guid">
                <b-list-group-item class="text-dark">
                  <character-component :character="member.character" :realm="realm"></character-component>
                </b-list-group-item>
              </b-collapse>
            </b-list-group>
          </b-col>
        </b-row>
      </b-collapse>
    </b-row>
  </b-container>
</template>

<script>
import moment from "moment";

export default {
  name: "GuildViewComponent",
  props: ["guild", "realm"],
  data() {
    return {};
  },
  computed: {
    GetGuildLeader() {
      const leaderGuid = this.guild.leaderGuid;
      const leader = this.guild.guildMembers.find(x => x.guid == leaderGuid);
      return leader;
    },
    GetMembersByRank() {
      const members = [...this.guild.guildMembers];
      return members.sort((a, b) => (a.rankId > b.rankId ? 1 : -1));
    }
  },
  methods: {
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
    }
  }
};
</script>