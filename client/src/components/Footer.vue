<template>
  <!-- Footer -->
  <footer class="page-footer font-small footer-background">
    <div class="footer-top-bar">
      <div class="container">
        <div class="row py-4 d-flex align-items-center">
          <div class="col-md-6 col-lg-5 text-center text-md-left mb-4 mb-md-0 text-white-50">
            <h5 class="mb-0"></h5>
          </div>
          <div class="col-md-6 col-lg-7 text-center text-md-right">
            <!-- Facebook -->
            <a class="fb-ic">
              <i class="fab fa-facebook-f text-white-50 mr-4"></i>
            </a>
            <!-- Twitter -->
            <a class="tw-ic">
              <i class="fab fa-twitter text-white-50 mr-4"></i>
            </a>
            <!-- Google +-->
            <a class="gplus-ic">
              <i class="fab fa-google-plus text-white-50 mr-4"></i>
            </a>
            <!--Linkedin -->
            <a class="li-ic">
              <i class="fab fa-linkedin text-white-50 mr-4"></i>
            </a>
            <!--Instagram-->
            <a class="ins-ic">
              <i class="fab fa-instagram text-white-50"></i>
            </a>
          </div>
        </div>
      </div>
    </div>

    <div class="container text-center text-md-left mt-5 text-white">
      <div class="row">
        <div class="col-md-3 col-lg-4 col-xl-3 mx-auto mb-4">
          <h5 class="text-uppercase font-weight-bold">titans-league</h5>
          <hr class="mb-4 mt-0 d-inline-block mx-auto footer-hr" />
          <p>
            A gaming experience above the usual. We guarantee to deliver content
            you have never seen before. Join now,
            <router-link to="/user/register">create an account</router-link>&nbsp;today!
          </p>
          <div class="text-secondary">
            Welcome to our newest member
            <router-link :to="'/profile/' + GetNewestUser" class="text-capitalize">{{GetNewestUser}}</router-link>!
            Total members
            <span class="font-orange">{{GetTotalUserCount}}</span>.
          </div>
        </div>

        <div class="col-md-2 col-lg-2 col-xl-2 mx-auto mb-4">
          <h5 class="text-uppercase font-weight-bold text-white">Profile</h5>
          <hr class="mb-4 mt-0 d-inline-block mx-auto footer-hr" />
          <p>
            <router-link to="/user/profile">View Profile</router-link>
          </p>
          <p>
            <router-link to="/user/account">Ingame Account</router-link>
          </p>
          <p>
            <router-link to="/user/vote">Vote Panel</router-link>
          </p>
          <p>
            <router-link to="/user/donate">Donate Panel</router-link>
          </p>
        </div>

        <div class="col-md-3 col-lg-2 col-xl-2 mx-auto mb-4">
          <h5 class="text-uppercase font-weight-bold text-white">links</h5>
          <hr class="mb-4 mt-0 d-inline-block mx-auto footer-hr" />
          <p>
            <router-link to="/changelog">Changelog</router-link>
          </p>
          <p>
            <router-link to="/pvpstats">PvP Statistics</router-link>
          </p>
          <p>
            <router-link to="/online">Online Players</router-link>
          </p>
          <p>
            <router-link to="/connect">How to Connect</router-link>
          </p>
        </div>

        <div class="col-md-4 col-lg-3 col-xl-3 mx-auto mb-md-0 mb-4 text-white">
          <h5 class="text-uppercase font-weight-bold">Contact</h5>
          <hr class="mb-4 mt-0 d-inline-block mx-auto footer-hr" />
          <p>
            <i class="fas fa-envelope"></i> admin@titans-league.org
          </p>
          <p>
            <i class="fab fa-discord"></i> Vincent Vanclef
            <span class="text-info">#9518</span>
          </p>
        </div>
      </div>
    </div>

    <div class="footer-copyright text-center py-3 text-white-50">
      © {{GetYear}} Copyright
      <a href="#">{{title}}</a>
    </div>

    <div class="text-secondary mr-3 user-info">
      <i class="fas fa-users"></i>
      Online Users {{GetOnlineUsers}}
    </div>
  </footer>
</template>

<script>
import config from "@/assets/config/config";

export default {
  data() {
    return {
      title: config.VUE_APP_TITLE
    };
  },
  methods: {},
  computed: {
    GetYear() {
      return new Date().getFullYear();
    },
    GetOnlineUsers() {
      return this.$store.getters["stats/GetOnlineUsers"];
    },
    GetNewestUser() {
      return this.$store.getters["user/GetNewestUser"];
    },
    GetTotalUserCount() {
      return this.$store.getters["user/GetTotalUserCount"];
    }
  }
};
</script>

<style>
.footer-background {
  background: url("~@/assets/images/footer-background.jpg");
  background-size: 100%;
}
.footer-top-bar {
  background: linear-gradient(to right, #33373e, rgb(1, 5, 7));
  box-shadow: 0 4px 7px rgba(0, 0, 0, 0.16), 0 4px 7px rgba(0, 0, 0, 0.23);
}
.footer-hr {
  border: 0;
  width: 50%;
  height: 2px;
  background: black;
}
.back-to-top img {
  width: 20px;
  height: 20px;
}

.user-info {
  position: fixed;
  bottom: 0;
  right: 0;
}
</style>