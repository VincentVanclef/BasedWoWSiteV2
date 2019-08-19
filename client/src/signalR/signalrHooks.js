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

  // -------------------------------------------------
  RunHooks() {
    this.OnlineUsersUpdate();
  }
}
