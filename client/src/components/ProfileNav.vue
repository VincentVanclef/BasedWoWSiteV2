<template>
  <div>
    <b-container class="text-center mt-1">
      <b-row>
        <b-col sm="12" md="6" lg="3">
          <b-button to="/user/profile" variant="dark" class="btn-block mb-1">
            <i class="fas fa-user"></i> Website Profile
          </b-button>
        </b-col>
        <b-col sm="12" md="6" lg="3">
          <b-button to="/user/profile/password" variant="dark" class="btn-block mb-1">
            <i class="fas fa-lock"></i> Change Password
          </b-button>
        </b-col>
        <b-col sm="12" md="6" lg="3">
          <b-button to="/user/account" variant="dark" class="btn-block mb-1">
            <i class="fas fa-magic"></i> Ingame Account
          </b-button>
        </b-col>
        <b-col sm="12" md="6" lg="3">
          <b-button to="/user/characters" variant="dark" class="btn-block mb-1">
            <i class="fas fa-wrench"></i> Characters Tools
          </b-button>
        </b-col>
      </b-row>
    </b-container>
    <hr class="border-dark" />
  </div>
</template>

<script>
export default {
  name: "ProfileNav",
  data() {
    return {};
  }
};
</script>
