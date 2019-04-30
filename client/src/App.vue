<template lang="html">
  <div id="background">
    <nav-panel/>
      <b-container id="main">
        <b-row class="main-row">
          <b-col cols="9">
            <div class="title">
              <h1>{{ GetPageName }}</h1>
            </div>
            <div class="main-content" v-bind:style="[HideAvatar ? '' : {backgroundImage: 'url(' + require(`${image}`) + ')' }]">
              <router-view/>
            </div>
          </b-col>
          <b-col cols="3" class="main-side">
            <login-panel v-if="isLogginHidden && !IsLoggedIn"/>
            <user-panel v-if="IsLoggedIn"/>
            <status-panel/>
            <discord-panel/>
          </b-col>
        </b-row>
      </b-container>
    <footer>
    <footer-panel/>
    </footer>
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

export default {
  name: "App",
  data() {
    return {
      images: ["./assets/thrall.png", "./assets/varian.png"],
      image: ""
    };
  },
  components: {
    "discord-panel": DiscordWidget,
    "login-panel": Login,
    "footer-panel": Footer,
    "nav-panel": Nav,
    "status-panel": ServerStatus,
    "user-panel": UserPanel
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
@import "node_modules/bootstrap/scss/bootstrap";
@import "node_modules/bootstrap-vue/src/index.scss";
@import "vuejs-dialog/dist/vuejs-dialog.min.css";

.no-padding {
  margin: 0 !important;
}

.no-margin {
  margin-right: 0 !important;
}

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
  background: url("./assets/background.jpg");
  background-position: center center;
  background-repeat: no-repeat;
  background-size: cover;
}

.main-content {
  height: 90%;
  width: 100%;
  padding: 0.75vw;
  margin-top: 4%;
  background: whitesmoke;
  background-position: bottom right;
  background-repeat: no-repeat;
  background-size: 30%;
  -webkit-border-radius: 6px;
  -moz-border-radius: 6px;
  border-radius: 6px;
}

.main-row {
  height: 100%;
}

#main {
  height: 1250px;
  font-weight: 500;
  font-size: 0.85vw;
  padding: 1vw;
  margin-top: 125px;
  margin-bottom: 80px;
  background: transparentize($color: black, $amount: 0.6);
  -webkit-border-radius: 6px;
  -moz-border-radius: 6px;
  border-radius: 6px;
}

.main-side {
  border: none;
  padding-top: 5px;
  background: transparent;
  -webkit-border-radius: 6px;
  -moz-border-radius: 6px;
  border-radius: 6px;
}

@media screen and (max-width: 1000px) {
  .input-group-prepend {
    display: none;
  }

  .main-content {
    height: 800px;
  }
}

@media screen and (max-width: 700px) {
  .main-content {
    height: 500px;
  }
}

h1 {
  font-size: 2.3vw;
  text-align: center;
  text-rendering: optimizeLegibility;

  color: whitesmoke;
  letter-spacing: 0.05em;
  font-weight: bold;
}
</style>
