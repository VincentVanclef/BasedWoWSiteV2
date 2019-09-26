<template>
  <b-modal
    centered
    size="xl"
    id="guild-bank-modal"
    v-if="Guild"
    @show="OpenModal()"
    @hide="CloseModal()"
    :title="Guild.name + '\'s Vault'"
    header-text-variant="white"
    header-bg-variant="dark"
  >
    <guild-bank-component v-if="Guild" :guild="Guild" :realm="Realm"></guild-bank-component>
  </b-modal>
</template>

<script>
import GuildBankComponent from "./GuildBankComponent";

export default {
  name: "GuildBankViewComponent",
  data() {
    return {};
  },
  components: {
    "guild-bank-component": GuildBankComponent
  },
  computed: {
    ShowModal() {
      return this.$store.getters["user/guild/GuildBankComponent"].ShowModal;
    },
    Realm() {
      return this.$store.getters["user/guild/GuildBankComponent"].Realm;
    },
    Guild() {
      return this.$store.getters["user/guild/GuildBankComponent"].Guild;
    }
  },
  methods: {
    OpenModal() {
      const Guild = this.Guild.name;
      const RealmType = this.Realm.id;

      this.$router.replace({
        query: Object.assign({}, this.$route.query, {
          guild: Guild,
          showVault: true
        })
      });
    },
    CloseModal() {
      this.$store.dispatch("user/guild/CloseGuildBankComponent");

      const QUERY = this.$route.query;

      this.$router.replace({
        query: Object.assign(
          {},
          {
            query: QUERY.query ? QUERY.query : undefined,
            realm: QUERY.realm,
            characters: QUERY.characters ? QUERY.characters : undefined,
            guild: QUERY.guild ? QUERY.guild : undefined,
            showVault: undefined
          }
        )
      });
    }
  }
};
</script>