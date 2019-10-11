<template>
  <b-container class="text-center mt-1">
    <b-row>
      <b-col sm="12" md="4" lg="4">
        <b-dropdown center split variant="dark" class="btn-block mb-1" :disabled="!IsAdmin">
          <template v-slot:button-content>
            <i class="fas fa-newspaper"></i> News
          </template>
          <b-dropdown-item to="/admin/news/create">Create</b-dropdown-item>
          <b-dropdown-item to="/admin/news/edit">Edit</b-dropdown-item>
          <b-dropdown-item to="/admin/news/delete">Delete</b-dropdown-item>
        </b-dropdown>
      </b-col>
      <b-col sm="12" md="4" lg="4">
        <b-dropdown center split variant="dark" class="btn-block mb-1">
          <template v-slot:button-content>
            <i class="fas fa-users"></i> Members
          </template>
          <b-dropdown-item to="/admin/members/admins">Admins</b-dropdown-item>
          <b-dropdown-item to="/admin/members/moderators">Moderators</b-dropdown-item>
          <b-dropdown-item to="/admin/members/search">Search</b-dropdown-item>
        </b-dropdown>
      </b-col>
      <b-col sm="12" md="4" lg="4">
        <b-dropdown center split variant="dark" class="btn-block mb-1">
          <template v-slot:button-content>
            <i class="fas fa-users"></i> Accounts
          </template>
          <b-dropdown-item to="/admin/accounts/admins">Admins</b-dropdown-item>
          <b-dropdown-item to="/admin/accounts/gamemasters">GameMasters</b-dropdown-item>
          <b-dropdown-item to="/admin/accounts/trials">Trials</b-dropdown-item>
          <b-dropdown-item to="/admin/accounts/search">Search</b-dropdown-item>
        </b-dropdown>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import UserHelper from "@/helpers/UserHelper";

export default {
  name: "AdminNav",
  data() {
    return {};
  },
  computed: {
    IsAdmin() {
      return UserHelper.IsAdmin();
    }
  }
};
</script>
