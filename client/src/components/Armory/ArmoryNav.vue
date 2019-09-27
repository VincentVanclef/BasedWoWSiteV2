<template>
  <b-container class="text-center mt-1">
    <b-row>
      <b-col sm="12" md="4" lg="4">
        <b-dropdown center split variant="dark" class="btn-block mb-1">
          <template slot="button-content">
            <i class="fas fa-users"></i> Search Characters
          </template>
          <b-dropdown-item
            v-for="realm in realms"
            :key="realm.id"
            :to="'/armory/characters/search/?realm=' + realm.id"
          >{{realm.name}}</b-dropdown-item>
        </b-dropdown>
      </b-col>
      <b-col sm="12" md="4" lg="4">
        <b-dropdown center split variant="dark" disabled class="btn-block mb-1">
          <template slot="button-content">
            <i class="fas fa-users-cog"></i> Search Guilds
          </template>
          <b-dropdown-item
            v-for="realm in realms"
            :key="realm.id"
            :to="'/armory/guilds/search/?realm=' + realm.id"
          >{{realm.name}}</b-dropdown-item>
        </b-dropdown>
      </b-col>
      <b-col sm="12" md="4" lg="4">
        <router-link to>
          <b-button variant="dark" block disabled>Coming Soon</b-button>
        </router-link>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import UserHelper from "@/helpers/UserHelper";

export default {
  name: "ArmoryNav",
  props: ["realms"],
  data() {
    return {};
  },
  computed: {}
};
</script>
