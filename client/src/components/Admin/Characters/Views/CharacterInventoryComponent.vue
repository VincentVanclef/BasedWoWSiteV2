<template>
  <b-modal
    centered
    size="xl"
    id="inventory-modal"
    v-if="Character && Realm"
    @show="OpenModal()"
    @hide="CloseModal()"
    :title="Character.name + '\'s Inventory'"
    header-bg-variant="warning"
  >
    <character-inventory v-if="Character" :character="Character" :realm="Realm"></character-inventory>
  </b-modal>
</template>

<script>
import CharacterInventoryView from "@/components/Admin/Characters/Views/CharacterInventoryView";

export default {
  name: "CharacterInventoryComponent",
  data() {
    return {};
  },
  components: {
    "character-inventory": CharacterInventoryView
  },
  computed: {
    ShowModal() {
      return this.$store.getters["armory/InventoryViewComponent"].ShowModal;
    },
    Character() {
      return this.$store.getters["armory/InventoryViewComponent"].Character;
    },
    Realm() {
      return this.$store.getters["armory/InventoryViewComponent"].Realm;
    }
  },
  methods: {
    async OpenModal() {
      try {
        await this.$router.replace({
          query: Object.assign({}, this.$route.query, {
            showInventory: this.Character.name,
            showArmory: undefined
          })
        });
      } catch (e) {}
    },
    async CloseModal() {
      this.$store.dispatch("armory/CloseInventoryComponent");

      const QUERY = this.$route.query;

      try {
        await this.$router.replace({
          query: Object.assign({}, QUERY, {
            showInventory: undefined,
            showArmory: undefined
          })
        });
      } catch (e) {}
    }
  }
};
</script>