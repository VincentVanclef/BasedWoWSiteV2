import { HubConnectionBuilder, LogLevel } from "@aspnet/signalr";
import SignalrHooks from "./signalrHooks";
import store from "../store";

const SIGNALR_URL = process.env.SIGNALR.URL;
const SIGNALR_LOGLEVEL =
  process.env.NODE_ENV === "development" ? LogLevel.Information : LogLevel.None;
const TIMEOUT = 15000;

export default {
  install(Vue) {
    const connection = new HubConnectionBuilder()
      .withUrl(SIGNALR_URL, {
        accessTokenFactory: () => store.getters["user/GetToken"]
      })
      .configureLogging(SIGNALR_LOGLEVEL)
      .build();

    new SignalrHooks(connection).RunHooks();

    async function start() {
      try {
        console.log("SignalR: connecting..");
        await connection.start();
        console.log("SignalR: connected");
      } catch (err) {
        console.log(
          `SignalR: connection failed, trying again in ${TIMEOUT /
            1000} seconds...`
        );
        setTimeout(() => start(), TIMEOUT);
      }
    }

    connection.onclose(async () => {
      await start();
    });

    start();

    Vue.prototype.$signalR = connection;
  }
};
