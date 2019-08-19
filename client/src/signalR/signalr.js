import { HubConnectionBuilder, LogLevel } from "@aspnet/signalr";
import Store from "../store";
import hooks from "./signalrHooks";

const token = localStorage.getItem("token");
const SIGNALR_URL = process.env.SIGNALR.URL;
const SIGNALR_LOGLEVEL =
  process.env.NODE_ENV === "development" ? LogLevel.Information : LogLevel.None;

export default {
  install(Vue) {
    const connection = new HubConnectionBuilder()
      .withUrl(SIGNALR_URL, {
        accessTokenFactory: () => token
      })
      .configureLogging(SIGNALR_LOGLEVEL)
      .build();

    connection.on("UpdateOnlineUsers", count => {
      Store.commit("stats/SetOnlineUsers", count);
    });

    async function start() {
      try {
        console.log("SignalR: connecting..");
        await connection.start();
        console.log("SignalR: connected");
      } catch (err) {
        console.log(err);
        console.log(
          "SignalR: connection failed, trying again in 10 seconds..."
        );
        setTimeout(() => start(), 10000);
      }
    }

    connection.onclose(async () => {
      await start();
    });

    start();
  }
};
