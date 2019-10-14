<template>
  <div class="main" id="background">
    <nav-panel />
    <div class="container content">
      <div class="row">
        <div class="col-md-9">
          <div class="title">
            <h1 class="page-title">{{ GetPageTitle }}</h1>
          </div>
          <!-- Main View -->
          <router-view :user="GetUser" :realms="Realms" :avatar="HideAvatar ? '' : image" />
          <shout-box :user="GetUser"></shout-box>
        </div>
        <!-- Static Side -->
        <div class="col-md-3">
          <login-panel :user="GetUser" v-if="isLogginHidden && !IsLoggedIn" />
          <user-panel :user="GetUser" v-if="IsLoggedIn" />
          <status-panel :realms="Realms" />
          <pvp-stats :realms="Realms" />
          <top-voters :realms="Realms" />
          <discord-panel />
        </div>
      </div>
    </div>
    <footer-panel />
    <!-- Misc -->
    <context-menu />
    <chat-box />
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
import Shoutbox from "@/components/Shoutbox/Shoutbox";
import PvPStats from "@/components/PvPStats";
import ContextMenu from "@/components/ContextMenu/ContextMenuComponent";
import ChatBox from "@/components/ChatWindow/ChatBox";

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
    "shout-box": Shoutbox,
    "pvp-stats": PvPStats,
    "context-menu": ContextMenu,
    "chat-box": ChatBox
  },
  computed: {
    GetPageTitle() {
      return this.$store.getters.GetPageTitle;
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
    },
    GetUser() {
      return this.$store.getters["user/GetUser"];
    },
    Realms() {
      return this.$store.getters["realms/GetRealms"];
    }
  },
  methods: {
    SetImage() {
      this.image = this.images[Math.floor(Math.random() * this.images.length)];
    }
  },
  created() {
    this.SetImage();
    this.$root.$emit("Initialize");
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
@import "node_modules/bootstrap/scss/bootstrap.scss";
@import "node_modules/bootstrap-vue/src/index.scss";
@import "assets/css/app.css";
@import "assets/scss/main.scss";

#background {
  background: url("~@/assets/images/background.png");
  background-position: top center;
  background-repeat: no-repeat;
  background-size: 100%;
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
  border-radius: 8px;
}

.page-title {
  text-align: center;
  text-rendering: optimizeLegibility;

  color: whitesmoke;
  letter-spacing: 0.05em;
  font-weight: bold;
}
</style>
