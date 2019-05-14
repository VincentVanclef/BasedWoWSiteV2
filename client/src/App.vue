<template lang="html">
  <div class="main" id="background">
    <nav-panel/>
      <div class="container content">
        <div class="row">
          <div class="col-md-9">
            <div class="title">
              <h1>{{ GetPageName }}</h1>
            </div>
            <!-- Main View -->
            <div>
              <router-view :avatar="HideAvatar ? '' : image"/>
            </div>
          </div>
          <!-- Static Side -->
          <div class="col-md-3">
            <login-panel v-if="isLogginHidden && !IsLoggedIn"/>
            <user-panel v-if="IsLoggedIn"/>
            <status-panel/>
            <top-voters/>
            <discord-panel/>
          </div>
        </div>
      </div>
      <!-- <shout-box/> -->
    <footer-panel/>
  </div>
</template>

<script>
import DiscordWidget from "@/components/DiscordWidget";
import Login from "@/components/Login";
import Footer from "@/components/Footer";
import Nav from "@/components/Nav";
import ServerStatus from "@/components/ServerStatus";
import UserPanel from "@/components/UserPanel";
import UserHelper from "./helpers/UserHelper";
import TopVoters from "@/components/TopVoters";
import Shoutbox from "@/components/Shoutbox";

export default {
  name: "App",
  data() {
    return {
      images: ["/static/images/thrall.png", "/static/images/varian.png"],
      image: ""
    };
  },
  components: {
    "discord-panel": DiscordWidget,
    "login-panel": Login,
    "footer-panel": Footer,
    "nav-panel": Nav,
    "status-panel": ServerStatus,
    "user-panel": UserPanel,
    "top-voters": TopVoters,
    "shout-box": Shoutbox
  },
  computed: {
    GetPageName() {
      return this.$route.meta.title;
    },
    GetImage() {
      return this.image;
    },
    IsLoggedIn() {
      return UserHelper.IsLoggedIn();
    },
    HideAvatar() {
      return this.$route.meta.hideAvatar;
    },
    isLogginHidden() {
      return this.$route.name != "Register" && this.$route.name != "Login";
    }
  },
  methods: {
    SetImage() {
      this.image = this.images[Math.floor(Math.random() * this.images.length)];
    }
  },
  created() {
    this.SetImage();
  },
  mounted() {},
  watch: {
    $route: function(value) {
      if (value.name != "News") {
        this.SetImage();
      }
    }
  }
};
</script>

<style lang="scss">
@import "node_modules/bootstrap/scss/bootstrap.scss";
@import "node_modules/bootstrap-vue/src/index.scss";
@import "vuejs-dialog/dist/vuejs-dialog.min.css";
@import "static/main.scss";

.alert {
  position: fixed;
  top: 0px;
  left: 0px;
  width: 100%;
  z-index: 9999;
  border-radius: 0px;
  text-align: center;
}

#background {
  background: url("/static/images/background.png");
  background-position: top center;
  background-repeat: no-repeat;
  background-color: #050505;
}

.content {
  height: 100%;
  font-weight: 500;
  padding: 15px;
  margin-top: 5%;
  margin-bottom: 5%;
  background: transparentize($color: black, $amount: 0.6);
  -webkit-border-radius: 6px;
  -moz-border-radius: 6px;
  border-radius: 6px;
}

h1 {
  text-align: center;
  text-rendering: optimizeLegibility;

  color: whitesmoke;
  letter-spacing: 0.05em;
  font-weight: bold;
}
</style>
