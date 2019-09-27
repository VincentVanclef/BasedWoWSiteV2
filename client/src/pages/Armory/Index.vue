<template>
  <div class="main-content" v-bind:style="{backgroundImage: 'url(' + avatar + ')' }">
    <armory-nav :realms="realms"></armory-nav>
    <hr class="border-dark" />
    <router-view :realms="realms" :user="user"></router-view>

    <guild-component :user="user" />
    <character-armory />
    <character-inventory />
  </div>
</template>

<script>
import ArmoryNav from "@/components/Armory/ArmoryNav";
import CharacterArmoryComponent from "@/components/Armory/Characters/CharacterArmoryComponent";
import CharacterInventoryComponent from "@/components/Admin/Characters/Views/CharacterInventoryComponent";
import GuildComponent from "@/components/Admin/Guilds/Views/GuildComponent";

export default {
  name: "Armory",
  props: ["avatar", "user", "realms"],
  data() {
    return {};
  },
  components: {
    "armory-nav": ArmoryNav,
    "character-armory": CharacterArmoryComponent,
    "character-inventory": CharacterInventoryComponent,
    "guild-component": GuildComponent
  }
};
</script>