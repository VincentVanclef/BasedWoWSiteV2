<template>
  <b-modal
    centered
    size="xl"
    v-if="ShowEditor && Guild"
    v-model="ShowEditor"
    :title="Guild.name"
    header-bg-variant="warning"
  >
    <guild-view-component :guild="Guild" :realm="realm"></guild-view-component>
  </b-modal>
</template>

<script>
import GuildViewComponent from "./GuildViewComponent";

export default {
  name: "GuildComponent",
  props: ["realm"],
  data() {
    return {
      Character: null,
      ShowEditor: false,
      Guild: null
    };
  },
  components: {
    "guild-view-component": GuildViewComponent
  },
  computed: {},
  methods: {
    show(character) {
      this.Character = character;
      this.FetchGuild();
    },
    async FetchGuild() {
      const Guid = this.Character.guid;
      const RealmType = this.realm.id;

      try {
        const guild = await this.$store.dispatch(
          "user/guild/GetGuildByCharacter",
          {
            Guid,
            RealmType
          }
        );
        this.Guild = guild;
      } finally {
        if (this.Guild) {
          this.ShowEditor = true;
        }
      }
    }
  }
};
</script>