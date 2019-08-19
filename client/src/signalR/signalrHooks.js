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

  GetNewestUser() {
    this.connection.on("UpdateNewestUser", user => {
      console.log(user);
      Store.commit("user/SetNewestUser", user);
    });
  }

  // -------------------------------------------------
  RunHooks() {
    this.OnlineUsersUpdate();
    this.GetNewestUser();
  }
}
