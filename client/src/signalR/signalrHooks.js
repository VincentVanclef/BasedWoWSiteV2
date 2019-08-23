import store from "../store";

export default class SignalrHooks {
  constructor(connection) {
    this.connection = connection;
  }

  OnOnlineUsersUpdate() {
    this.connection.on("UpdateOnlineUsers", count => {
      store.commit("stats/SetOnlineUsers", count);
    });
  }

  OnUpdateUserInformations() {
    this.connection.on("UpdateUserInformations", (user, count) => {
      store.commit("user/SetNewestUser", user);
      store.commit("user/SetTotalUserCount", count);
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

  // -------------------------------------------------
  RunHooks() {
    this.OnOnlineUsersUpdate();
    this.OnUpdateUserInformations();
    this.OnReceiveShoutBoxMessage();
    this.OnClearShoutBox();
    this.OnEditShout();
    this.OnDeleteShout();
  }
}
