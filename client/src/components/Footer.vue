<template>
  <!-- Footer -->
  <footer class="page-footer font-small footer-background">
    <div class="footer-top-bar">
      <div class="container">
        <!-- Grid row-->
        <div class="row py-4 d-flex align-items-center">
          <!-- Grid column -->
          <div class="col-md-6 col-lg-5 text-center text-md-left mb-4 mb-md-0 text-white-50">
            <h5 class="mb-0"></h5>
          </div>
          <!-- Grid column -->

          <!-- Grid column -->
          <div class="col-md-6 col-lg-7 text-center text-md-right">
            <!-- Facebook -->
            <a class="fb-ic">
              <i class="fa fa-facebook-f text-white-50 mr-4"></i>
            </a>
            <!-- Twitter -->
            <a class="tw-ic">
              <i class="fa fa-twitter text-white-50 mr-4"></i>
            </a>
            <!-- Google +-->
            <a class="gplus-ic">
              <i class="fa fa-google-plus text-white-50 mr-4"></i>
            </a>
            <!--Linkedin -->
            <a class="li-ic">
              <i class="fa fa-linkedin text-white-50 mr-4"></i>
            </a>
            <!--Instagram-->
            <a class="ins-ic">
              <i class="fa fa-instagram text-white-50"></i>
            </a>
          </div>
          <!-- Grid column -->
        </div>
        <!-- Grid row-->
      </div>
    </div>

    <!-- Footer Links -->
    <div class="container text-center text-md-left mt-5 text-white">
      <!-- Grid row -->
      <div class="row mt-3">
        <!-- Grid column -->
        <div class="col-md-3 col-lg-4 col-xl-3 mx-auto mb-4">
          <!-- Content -->
          <h5 class="text-uppercase font-weight-bold">titans-league</h5>
          <hr class="mb-4 mt-0 d-inline-block mx-auto footer-hr" />
          <p>
            A gaming experience above the usual. We guarantee to deliver content
            you have never seen before. Join now,
            <router-link to="/user/register">create an account</router-link>&nbsp;today!
          </p>
        </div>
        <!-- Grid column -->

        <!-- Grid column -->
        <div class="col-md-2 col-lg-2 col-xl-2 mx-auto mb-4">
          <!-- Links -->
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
        </div>
        <!-- Grid column -->

        <!-- Grid column -->
        <div class="col-md-3 col-lg-2 col-xl-2 mx-auto mb-4">
          <!-- Links -->
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
        </div>
        <!-- Grid column -->

        <!-- Grid column -->
        <div class="col-md-4 col-lg-3 col-xl-3 mx-auto mb-md-0 mb-4 text-white">
          <!-- Links -->
          <h5 class="text-uppercase font-weight-bold">Contact</h5>
          <hr class="mb-4 mt-0 d-inline-block mx-auto footer-hr" />
          <p>
            <i class="fa fa-envelope"></i> admin@titans-league.org
          </p>
        </div>
        <!-- Grid column -->
      </div>
      <!-- Grid row -->
    </div>
    <!-- Footer Links -->

    <!-- Copyright -->
    <div class="footer-copyright text-center py-3 text-white-50">
      © {{GetYear}} Copyright
      <a href="https://titans-league.org">{{title}}</a>
    </div>
    <!-- Copyright -->
  </footer>
  <!-- Footer -->
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
    }
  }
};
</script>

<style>
.footer-background {
  background: url("https://ifrescuemission.org/wp-content/uploads/2018/10/footer-background.jpg");
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
</style>
