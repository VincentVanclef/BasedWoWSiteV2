<template>
  <b-modal
    centered
    size="xl"
    id="armory-modal"
    v-if="Character && Realm"
    @show="OpenModal()"
    @hide="CloseModal()"
    :title="Realm.name + ' Armory'"
    header-bg-variant="warning"
  >
    <character-armory-view v-if="Character" :character="Character" :realm="Realm"></character-armory-view>
  </b-modal>
</template>

<script>
import CharacterArmoryView from "./CharacterArmoryView";

export default {
  name: "CharacterArmoryComponent",
  data() {
    return {};
  },
  components: {
    "character-armory-view": CharacterArmoryView
  },
  computed: {
    ShowModal() {
      return this.$store.getters["armory/ArmoryViewComponent"].ShowModal;
    },
    Character() {
      return this.$store.getters["armory/ArmoryViewComponent"].Character;
    },
    Realm() {
      return this.$store.getters["armory/ArmoryViewComponent"].Realm;
    }
  },
  methods: {
    async OpenModal() {
      try {
        await this.$router.replace({
          query: Object.assign({}, this.$route.query, {
            showArmory: this.Character.name,
            showInventory: undefined
          })
        });
      } catch (e) {}
    },
    CloseModal() {
      this.$store.dispatch("armory/CloseArmoryComponent");

      const QUERY = this.$route.query;

      this.$router.replace({
        query: Object.assign(
          {},
          {
            query: QUERY.query ? QUERY.query : undefined,
            realm: QUERY.realm,
            characters: QUERY.characters ? QUERY.characters : undefined,
            guild: QUERY.guild ? QUERY.guild : undefined,
            showArmory: undefined
          }
        )
      });
    }
  }
};
</script>