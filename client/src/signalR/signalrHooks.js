import store from "../store";

export default class SignalrHooks {
  constructor(connection, vm) {
    this.connection = connection;
    this.vm = vm;
  }

  OnOnlineUsersUpdate() {
    this.connection.on("UpdateOnlineUsers", count => {
      store.commit("stats/SetOnlineUsers", count);
    });
  }

  OnUpdateUserInformations() {
    this.connection.on("UpdateUserInformations", (user, count) => {
      store.commit("stats/SetNewestUser", user);
      store.commit("stats/SetTotalUserCount", count);
    });
  }

  OnReceiveShoutBoxMessage() {
    this.connection.on("ReceiveShoutBoxMessage", shout => {
      store.commit("shoutbox/AddNewShout", shout);
    });
  }

  OnClearShoutBox() {
    this.connection.on("ClearShoutBox", () => {
      store.commit("shoutbox/SetShouts", []);
    });
  }

  OnEditShout() {
    this.connection.on("EditShout", shout => {
      store.commit("shoutbox/EditShout", shout);
    });
  }

  OnDeleteShout() {
    this.connection.on("DeleteShout", id => {
      store.commit("shoutbox/DeleteShout", id);
    });
  }

  async OnLogout() {
    this.connection.on("LogoutUser", async () => {
      await store.dispatch("user/Logout");
    });
  }

  OnValidateVersion() {
    this.connection.on("ValidateVersion", version => {
      const currentVersion = store.getters.GetWebsiteVersion;
      if (currentVersion !== version) {
        if (currentVersion.length === 0) {
          store.commit("UpdateWebsiteVersion", version);
        } else {
          this.vm.$bvToast.toast(
            "There has been deployed a new website version. The website will reload shortly to apply the new updates.",
            {
              title: "Website Update",
              variant: "primary",
              solid: true,
              autoHideDelay: 6000,
              noCloseButton: true
            }
          );
          setTimeout(() => window.location.reload(true), 5500);
        }
      }
    });
  }

  // -------------------------------------------------
  RunHooks() {
    this.OnOnlineUsersUpdate();
    this.OnUpdateUserInformations();
    this.OnReceiveShoutBoxMessage();
    this.OnClearShoutBox();
    this.OnEditShout();
    this.OnDeleteShout();
    this.OnLogout();
    this.OnValidateVersion();
  }
}
