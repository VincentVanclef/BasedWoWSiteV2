<template>
  <div id="background">
    <Nav/>
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
            <login v-if="isLogginHidden()"/>
            <DiscordWidget/>
          </b-col>
        </b-row>
      </b-container>
    </main>
    <Footer/>
  </div>
</template>

<script>
import DiscordWidget from "@/components/DiscordWidget";
import Login from "@/components/Login";
import Footer from "@/components/Footer";
import Nav from "@/components/Nav";

export default {
  name: "App",
  data() {
    return {
      images: ['./assets/thrall.png', './assets/varian.png'],
      image: ''
    }
  },
  components: {
    DiscordWidget,
    Login,
    Footer,
    Nav
  },
  computed: {
    GetPageName() {
      return this.$route.meta.title;
    },
    
  },
  methods: {
    isLogginHidden() {
      return this.$route.name != "Register" && this.$route.name != "Login";
    },
    GetImage() {
      console.log("success");
      return this.images[Math.floor(Math.random() * this.images.length)];
    },
    HideAvatar() {
      return this.$route.name == "Home";
    }
  },
  created() {
    this.image = this.GetImage();
  }
};
</script>

<style lang="scss">
@import "node_modules/bootstrap/scss/bootstrap";
@import "node_modules/bootstrap-vue/src/index.scss";

.no-padding {
  margin: 0 !important;
}

.no-margin {
  margin-right: 0 !important;
}

#background {
  margin: 0;
  background: url("./assets/background.jpg");
  background-position: center center;
  background-repeat: no-repeat;
  background-size: cover;
}

#main-content {
  height: 900px;
  padding: 20px;
  margin-top: 20px;
  background-color: whitesmoke;
  background-position: bottom right;
  background-repeat: no-repeat;
  background-size: 240px;
}

.main {
  border: none;
  padding: 20px;
  margin-top: 40px;
  margin-bottom: 40px;
  background: lightgrey;
  box-shadow: 2px 2px 4px #888888;
  -webkit-border-radius: 6px;
  -moz-border-radius: 6px;
  border-radius: 6px;
}

.main-side {
  border: none;
  padding: 15px;
  max-height: 900px;
  background: whitesmoke;
  box-shadow: 2px 1px 3px #888888;
  -webkit-border-radius: 6px;
  -moz-border-radius: 6px;
  border-radius: 6px;
}
</style>
