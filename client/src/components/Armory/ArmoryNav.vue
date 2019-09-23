<template>
  <b-container class="text-center mt-1">
    <b-row>
      <b-col sm="12" md="4" lg="4">
        <router-link to="/armory/characters/search">
          <b-button variant="dark" block>
            <i class="fas fa-users"></i> Search Characters
          </b-button>
        </router-link>
      </b-col>
      <b-col sm="12" md="4" lg="4">
        <b-button variant="dark" block>
          <i class="fas fa-users-cog"></i> Search Guilds
        </b-button>
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
  data() {
    return {};
  },
  computed: {}
};
</script>
