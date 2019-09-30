import { HubConnectionBuilder, LogLevel } from "@aspnet/signalr";
import SignalrHooks from "./signalrHooks";

const SIGNALR_URL = process.env.SIGNALR.URL;
const SIGNALR_LOGLEVEL =
  process.env.NODE_ENV === "development" ? LogLevel.Information : LogLevel.None;
const TIMEOUT = 10000;
const token = localStorage.getItem("token") || "";

export default {
  install(Vue) {
    const vm = new Vue();

    const connection = new HubConnectionBuilder()
      .withUrl(SIGNALR_URL, {
        accessTokenFactory: () => token
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
        vm.$bvToast.toast("Connection failed, attempting to reconnect...", {
          title: "SignalR",
          variant: "warning",
          autoHideDelay: TIMEOUT
        });
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
