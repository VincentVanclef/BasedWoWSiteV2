<template>
  <b-container class="text-center mt-1">
    <b-row>
      <b-col sm="12" md="6" lg="3">
        <b-dropdown center split variant="dark" class="btn-block mb-1">
          <template slot="button-content">
            <i class="fas fa-newspaper"></i> News
          </template>
          <b-dropdown-item to="/admin/news/create">Create</b-dropdown-item>
          <b-dropdown-item to="/admin/news/edit">Edit</b-dropdown-item>
          <b-dropdown-item to="/admin/news/delete">Delete</b-dropdown-item>
        </b-dropdown>
      </b-col>
      <b-col sm="12" md="6" lg="3">
        <b-dropdown center split variant="dark" class="btn-block mb-1">
          <template slot="button-content">
            <i class="fas fa-users"></i> Members
          </template>
          <b-dropdown-item to="/admin/members/create">Create</b-dropdown-item>
          <b-dropdown-item to="/admin/members/edit">Edit</b-dropdown-item>
          <b-dropdown-item to="/admin/members/delete">Delete</b-dropdown-item>
        </b-dropdown>
      </b-col>
      <b-col sm="12" md="6" lg="3">
        <b-dropdown center split variant="dark" class="btn-block mb-1">
          <template slot="button-content">
            <i class="fas fa-crown"></i> GameMasters
          </template>
          <b-dropdown-item to="/admin/members/create">Create</b-dropdown-item>
          <b-dropdown-item to="/admin/members/edit">Edit</b-dropdown-item>
          <b-dropdown-item to="/admin/members/delete">Delete</b-dropdown-item>
        </b-dropdown>
      </b-col>
      <b-col sm="12" md="6" lg="3">
        <b-dropdown center split variant="dark" class="btn-block mb-1">
          <template slot="button-content">
            <i class="fas fa-crown"></i> GameMasters
          </template>
          <b-dropdown-item to="/admin/members/create">Create</b-dropdown-item>
          <b-dropdown-item to="/admin/members/edit">Edit</b-dropdown-item>
          <b-dropdown-item to="/admin/members/delete">Delete</b-dropdown-item>
        </b-dropdown>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
export default {
  name: "AdminNav",
  data() {
    return {};
  }
};
</script>
