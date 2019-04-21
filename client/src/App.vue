<template>
  <div id="background">
    <nav-panel/>
    <main>
      <b-container class="bv-example-row main">
        <b-row class="no-margin">
          <b-col cols="9">
            <div class="title">
              <h1>{{ GetPageName }}</h1>
            </div>
            <div id="main-content" class="card rounded" v-bind:style="[HideAvatar() ? '' : {backgroundImage: 'url(' + require(`${image}`) + ')' }]">
              <router-view/>
            </div>
          </b-col>
          <b-col cols="3" class="main-side">
            <login-panel v-if="isLogginHidden() && !IsLoggedIn"/>
            <user-panel v-if="IsLoggedIn"/>
            <status-panel/>
            <discord-panel/>
          </b-col>
        </b-row>
      </b-container>
    </main>
    <footer-panel/>
  </div>
</template>

<script>
import DiscordWidget from "@/components/DiscordWidget";
import Login from "@/components/Login";
import Footer from "@/components/Footer";
import Nav from "@/components/Nav";
import ServerStatus from '@/components/ServerStatus';
import UserPanel from '@/components/UserPanel';
import UserHelper from './helpers/UserHelper'

export default {
  name: "App",
  data() {
    return {
      images: ['./assets/thrall.png', './assets/varian.png'],
      image: ''
    }
  },
  components: {
    'discord-panel': DiscordWidget,
    'login-panel': Login,
    'footer-panel': Footer,
    'nav-panel': Nav,
    'status-panel': ServerStatus,
    'user-panel': UserPanel
  },
  computed: {
    GetPageName() {
      return this.$route.meta.title;
    },
    GetImage() {
      return this.image;
    },
    IsLoggedIn() {
      return UserHelper.IsLoggedIn()
    }
  },
  methods: {
    isLogginHidden() {
      return this.$route.name != "Register" && this.$route.name != "Login";
    },
    SetImage() {
      this.image = this.images[Math.floor(Math.random() * this.images.length)];
    },
    HideAvatar() {
      return this.$route.name == "News";
    }
  },
  created() {
    this.SetImage();
  },
  watch: {
  	'$route': function(value) {
      if(value.name != 'News') {
      	this.SetImage();
      }
    }
  }
};
</script>

<style lang="scss">
@import "node_modules/bootstrap/scss/bootstrap";
@import "node_modules/bootstrap-vue/src/index.scss";
@import 'vuejs-dialog/dist/vuejs-dialog.min.css';

.no-padding {
  margin: 0 !important;
}

.no-margin {
  margin-right: 0 !important;
}

.alert {
  position:fixed; 
  top: 0px; 
  left: 0px; 
  width: 100%;
  z-index:9999; 
  border-radius:0px;
  text-align: center;
}

#background {
  margin: 0;
  background: url("./assets/background.jpg");
  background-position: center center;
  background-repeat: no-repeat;
  background-size: cover;
}

#main-content {
  height: 1114px;
  padding: 20px;
  margin-top: 20px;
  background: whitesmoke;
  background-position: bottom right;
  background-repeat: no-repeat;
  background-size: 240px;
  -webkit-border-radius: 6px;
  -moz-border-radius: 6px;
  border-radius: 6px;
}

.main {
  height: 1275px;
  font-weight: 500;
  border: none;
  padding: 20px;
  margin-top: 125px;
  margin-bottom: 80px;
  background: transparentize($color: black, $amount: 0.6);
  /*background-image: url('https://images.pexels.com/photos/1040473/pexels-photo-1040473.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260');
  background-position: top;
  background-repeat: no-repeat;
  background-blend-mode: darken;
  background-size: cover;*/
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

h1 {
  font-size: 50px;
  text-align: center;
  text-rendering: optimizeLegibility;
  
  color: whitesmoke;
  letter-spacing: .05em;
  font-weight: bold;
}
</style>
