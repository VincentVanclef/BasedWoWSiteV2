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

    <b-container fluid class="mt-5 text-white w-90 pl-5">
      <b-row>
        <b-col sm="12" md="6" lg="3" class="mb-3">
          <h5 class="text-uppercase font-weight-bold">titans-league</h5>
          <hr class="mb-3 mt-0 d-inline-block mx-auto footer-hr" />
          <div class="w-95">
            <p>
              A gaming experience above the usual. We guarantee to deliver content
              you have never seen before.
              <br />Join now,
              <router-link to="/user/register">create an account</router-link>&nbsp;today!
            </p>
          </div>
          <div class="text-secondary" v-if="GetNewestUser">
            Welcome to our newest member,
            <router-link
              :to="'/profile/' + GetNewestUser.username"
              v-contextmenu.member="{ User: GetNewestUser }"
              class="text-capitalize"
            >{{GetNewestUser.username}}</router-link>!
          </div>
          <div class="text-secondary">
            Total members
            <span class="font-orange">{{GetTotalUserCount}}</span>.
          </div>
        </b-col>

        <b-col sm="12" md="6" lg="3" class="mb-3">
          <h5 class="text-uppercase font-weight-bold text-white">Active Users</h5>
          <hr class="mb-3 mt-0 d-inline-block mx-auto footer-hr" />
          <p>
            There are currently
            <b class="text-info">{{GetOnlineUsers.length + GetOnlineVisitors}}</b>
            users online.
            <br />These are
            <b class="text-info">{{GetOnlineUsers.length}}</b> members and
            <b class="text-info">{{GetOnlineVisitors}}</b> guests.
          </p>
          <div class="online-users-list text-md-left" ref="onlineUserList">
            <span
              class="list-inline text-capitalize"
              v-for="(user, index) in GetOnlineUsers"
              :key="user.id"
            >
              <router-link
                class="p-0 text-info"
                :to="`/profile/${user.clients[0].clientName}`"
                v-contextmenu.member="{ User: user }"
              >{{user.clients[0].clientName}}{{(GetOnlineUsers.length - 1 > index) ? ',' : ''}}</router-link>&nbsp;
            </span>
          </div>
          <div v-if="GetUserListCharLength >= 70">
            <button
              class="text-secondary remove-button-style"
              @click="ToggleMembers()"
              v-if="!UserListExpanded"
            >
              Show more
              <i class="fas fa-angle-double-down" style="font-size: 0.5rem;"></i>
            </button>
            <button
              class="text-secondary remove-button-style"
              @click="ToggleMembers()"
              v-if="UserListExpanded"
            >
              Show less
              <i class="fas fa-angle-double-up" style="font-size: 0.5rem;"></i>
            </button>
          </div>
        </b-col>

        <b-col sm="12" md="6" lg="2" class="mb-3">
          <h5 class="text-uppercase font-weight-bold text-white">Profile</h5>
          <hr class="mb-3 mt-0 d-inline-block mx-auto footer-hr" />
          <ul>
            <li class="mb-1">
              <router-link to="/user/profile">View Profile</router-link>
            </li>
            <li class="mb-1">
              <router-link to="/user/account">Ingame Account</router-link>
            </li>
            <li class="mb-1">
              <router-link to="/user/vote">Vote Panel</router-link>
            </li>
            <li class="mb-1">
              <router-link to="/user/donate">Donate Panel</router-link>
            </li>
          </ul>
        </b-col>

        <b-col sm="12" md="6" lg="2" class="mb-3">
          <h5 class="text-uppercase font-weight-bold text-white">links</h5>
          <hr class="mb-3 mt-0 d-inline-block mx-auto footer-hr" />
          <ul>
            <li class="mb-1">
              <router-link to="/changelog">Changelog</router-link>
            </li>
            <li class="mb-1">
              <router-link to="/pvpstats">PvP Statistics</router-link>
            </li>
            <li class="mb-1">
              <router-link to="/online">Online Players</router-link>
            </li>
            <li class="mb-1">
              <router-link to="/connect">How to Connect</router-link>
            </li>
          </ul>
        </b-col>

        <b-col sm="12" md="6" lg="2" class="mb-3">
          <h5 class="text-uppercase font-weight-bold">Contact</h5>
          <hr class="mb-4 mt-0 d-inline-block mx-auto footer-hr" />
          <p>
            <i class="fas fa-envelope"></i> admin@titans-league.org
          </p>
          <p>
            <i class="fab fa-discord"></i> Vincent Vanclef
            <span class="text-info">#9518</span>
          </p>
        </b-col>
      </b-row>
    </b-container>

    <div class="footer-copyright text-center py-2 text-white-50 mt-2">
      © {{GetYear}} Copyright
      <a href="#">{{Title}}</a>
      <div>
        <small>Website Version {{GetWebsiteVersion}}</small>
      </div>
    </div>

    <div class="text-secondary mr-3 user-info click-able" @click="DisplayOnlineUsers">
      <i class="fas fa-users"></i>
      Online Users {{GetOnlineUsers.length + GetOnlineVisitors}}
    </div>

    <b-modal
      id="show-users-modal"
      centered
      size="md"
      header-bg-variant="dark"
      header-text-variant="white"
      title="Online Users"
      ok-only
    >
      <b-row class="font-weight-bold">
        <b-col>
          <div class="d-flex float-left">
            <h5>
              Members:
              <b-badge>{{GetOnlineUsers.length}}</b-badge>
            </h5>
          </div>
          <div class="d-flex float-right">
            <h5>
              Guests:
              <b-badge>{{GetOnlineVisitors}}</b-badge>
            </h5>
          </div>
        </b-col>
      </b-row>
      <b-row class="font-weight-bold mt-3 view-users-modal">
        <b-col>
          <div class="font-italic text-capitalize w-100">
            <span v-for="(user, index) in GetOnlineUsers" :key="user.id">
              <a
                class="p-0"
                :href="`/profile/${user.clients[0].clientName}`"
                target="_blank"
                v-contextmenu.member="{ User: user }"
              >{{user.clients[0].clientName}}{{(GetOnlineUsers.length - 1 > index) ? ',' : ''}}</a>&nbsp;
            </span>
          </div>
        </b-col>
      </b-row>
    </b-modal>
  </footer>
</template>

<script>
import config from "@/assets/config/config";

export default {
  data() {
    return {
      UserListExpanded: false
    };
  },
  computed: {
    GetYear() {
      return new Date().getFullYear();
    },
    GetOnlineUsers() {
      const sortedUsers = [...this.$store.getters["stats/GetOnlineUsers"]];
      return sortedUsers.sort((a, b) =>
        a.clients[0].clientName < b.clients[0].clientName ? 1 : -1
      );
    },
    GetOnlineVisitors() {
      return this.$store.getters["stats/GetOnlineVisitors"];
    },
    GetNewestUser() {
      return this.$store.getters["stats/GetNewestUser"];
    },
    GetTotalUserCount() {
      return this.$store.getters["stats/GetTotalUserCount"];
    },
    Title() {
      return config.SERVER_TITLE;
    },
    GetWebsiteVersion() {
      return this.$store.getters.GetWebsiteVersion;
    },
    GetUserListCharLength() {
      const total = this.GetOnlineUsers.reduce((acc, ele) => {
        return (acc += ele.clients[0].clientName.length);
      }, 0);
      return total;
    }
  },
  methods: {
    ToggleMembers() {
      const userList = this.$refs.onlineUserList;
      userList.classList.toggle("online-users-list");
      this.UserListExpanded = !this.UserListExpanded;
    },
    DisplayOnlineUsers() {
      this.$bvModal.show("show-users-modal");
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

.online-users-list {
  max-height: 50px;
  overflow: hidden;
}

.view-users-modal {
  font-size: 1.2rem;
}
</style>