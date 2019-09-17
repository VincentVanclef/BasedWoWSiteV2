<template>
  <b-modal
    centered
    size="xl"
    id="guild-modal"
    v-if="Guild"
    @show="OpenModal()"
    @hide="CloseModal()"
    :title="Guild.name"
    header-bg-variant="warning"
  >
    <guild-view-component v-if="Guild" :guild="Guild" :realm="Realm"></guild-view-component>
  </b-modal>
</template>

<script>
import GuildViewComponent from "./GuildViewComponent";

export default {
  name: "GuildComponent",
  data() {
    return {};
  },
  components: {
    "guild-view-component": GuildViewComponent
  },
  computed: {
    ShowModal() {
      return this.$store.getters["user/guild/GuildViewComponent"].ShowModal;
    },
    Realm() {
      return this.$store.getters["user/guild/GuildViewComponent"].Realm;
    },
    Character() {
      return this.$store.getters["user/guild/GuildViewComponent"].Character;
    },
    Guild() {
      return this.$store.getters["user/guild/GuildViewComponent"].Guild;
    }
  },
  methods: {
    OpenModal() {
      const Guid = this.Character.guid;
      const RealmType = this.Realm.id;

      this.$router.replace({
        query: Object.assign({}, this.$route.query, {
          guild: this.Character.name
        })
      });
    },
    CloseModal() {
      this.$store.dispatch("user/guild/CloseGuildComponent");

      const QUERY = this.$route.query;

      this.$router.replace({
        query: Object.assign(
          {},
          {
            query: QUERY.query,
            realm: QUERY.realm,
            characters: QUERY.characters
          }
        )
      });
    }
  }
};
</script>