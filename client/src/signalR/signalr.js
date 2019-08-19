import { HubConnectionBuilder, LogLevel } from "@aspnet/signalr";
import SignalrHooks from "./signalrHooks";

const TOKEN = localStorage.getItem("token");
const SIGNALR_URL = process.env.SIGNALR.URL;
const SIGNALR_LOGLEVEL =
  process.env.NODE_ENV === "development" ? LogLevel.Information : LogLevel.None;
const TIMEOUT = 10000;

export default {
  install(Vue) {
    const connection = new HubConnectionBuilder()
      .withUrl(SIGNALR_URL, {
        accessTokenFactory: () => TOKEN
      })
      .configureLogging(SIGNALR_LOGLEVEL)
      .build();

    const hooks = new SignalrHooks(connection);

    hooks.RunHooks();

    async function start() {
      try {
        console.log("SignalR: connecting..");
        await connection.start();
        console.log("SignalR: connected");
      } catch (err) {
        console.log(
          `SignalR: connection failed, trying again in ${TIMEOUT} seconds...`
        );
        setTimeout(() => start(), TIMEOUT);
      }
    }

    connection.onclose(async () => {
      await start();
    });

    start();
  }
};
