<template>
  <div class="main-content" v-bind:style="{backgroundImage: 'url(' + avatar + ')' }">
    <armory-nav :realms="realms"></armory-nav>
    <hr class="border-dark" />
    <router-view v-if="!Loading" :realms="realms" :user="user"></router-view>
  </div>
</template>

<script>
import ArmoryNav from "@/components/Armory/ArmoryNav";

export default {
  name: "Armory",
  props: ["avatar", "user", "realms"],
  data() {
    return {
      Loading: false
    };
  },
  components: {
    "armory-nav": ArmoryNav
  },
  created() {
    this.Loading = true;
    for (const realm of this.realms) {
      this.$store
        .dispatch("stats/GetTotalCharacters", realm.id)
        .finally(() => (this.Loading = false));
    }
  }
};
</script>