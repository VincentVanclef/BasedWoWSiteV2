import { HubConnectionBuilder, LogLevel } from "@aspnet/signalr";
import SignalrHooks from "./signalrHooks";

const SIGNALR_URL = process.env.SIGNALR.URL;
const SIGNALR_LOGLEVEL =
  process.env.NODE_ENV === "development" ? LogLevel.Information : LogLevel.None;
const TIMEOUT = 10000;
const token = localStorage.getItem("token") || "";

let autoConnect = false;

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
        if (autoConnect) {
          autoConnect = false;
          vm.$bvToast.toast("Connection successful.", {
            title: "SignalR",
            variant: "success",
            solid: true,
            autoHideDelay: 5000
          });
          vm.$bvToast.hide("signalR-toast");
        }
      } catch (err) {
        if (!autoConnect) {
          vm.$bvToast.toast("Connection failed, attempting to reconnect...", {
            id: "signalR-toast",
            title: "SignalR",
            variant: "warning",
            solid: true,
            noAutoHide: true,
            noCloseButton: true
          });
        }
        console.log(
          `SignalR: connection failed, trying again in ${TIMEOUT /
            1000} seconds...`
        );
        autoConnect = true;
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
