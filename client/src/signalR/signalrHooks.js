import Store from "../store";

export default class SignalrHooks {
  constructor(connection) {
    this.connection = connection;
  }

  OnlineUsersUpdate() {
    this.connection.on("UpdateOnlineUsers", count => {
      Store.commit("stats/SetOnlineUsers", count);
    });
  }

  UpdateUserInformations() {
    this.connection.on("UpdateUserInformations", (user, count) => {
      Store.commit("user/SetNewestUser", user);
      Store.commit("user/SetTotalUserCount", count);
    });
  }

  // -------------------------------------------------
  RunHooks() {
    this.OnlineUsersUpdate();
    this.UpdateUserInformations();
  }
}
