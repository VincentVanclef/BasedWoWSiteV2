<template>
  <div class="container">
    <profile-nav></profile-nav>
    <div class="row">
      <keep-alive>
        <router-view v-bind:User="User"></router-view>
      </keep-alive>
    </div>
  </div>
</template>

<script>
import ProfileNav from '@/components/ProfileNav'

export default {
  name: "Profile",
  data() {
    return {
      User: null
    };
  },
  components: {
    'profile-nav': ProfileNav
  },
  methods: {},
  created() {
    this.User = this.$store.getters.GetUser;
  }
};
</script>

<style scoped>
h5 {
  text-transform: capitalize;
}

.user-menu a {
  display: block;
  background: #efdb06;
  border: 1px solid #f9e610;
  color: #3d3d3d;
  padding: 10px 15px;
  font-family: "PT Sans", sans-serif;
  font-weight: bold;
  text-transform: uppercase;
  font-size: 15px;
  transform: scaleX(1);
  transition: transform 200ms ease-in;
}

.user-menu a:hover {
  text-decoration: none;
  transform: scaleX(1.02);
}

</style>