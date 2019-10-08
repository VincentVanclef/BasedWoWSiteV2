import { HubConnectionBuilder, LogLevel } from "@aspnet/signalr";
import SignalRChatHooks from "./signalRChatHooks";

const SIGNALR_URL = process.env.SIGNALR.CHAT;
const SIGNALR_LOGLEVEL =
  process.env.NODE_ENV === "development" ? LogLevel.Information : LogLevel.None;
const TIMEOUT = 5000;

export default class ChatHub {
  constructor(vm) {
    this.vm = vm;

    this.CreateConnection();
    this.RegisterCallbacks();
  }

  CreateConnection() {
    const token = localStorage.getItem("token");
    if (!token) return false;

    this.connection = new HubConnectionBuilder()
      .withUrl(SIGNALR_URL, {
        accessTokenFactory: () => token
      })
      .configureLogging(SIGNALR_LOGLEVEL)
      .build();

    return true;
  }

  async Connect() {
    try {
      console.log("SignalR - Chat: connecting..");
      await this.connection.start();
      console.log("SignalR - Chat: connected");
      return Promise.resolve();
    } catch (error) {
      console.log(
        `SignalR: connection failed, trying again in ${TIMEOUT /
          1000} seconds...`
      );
      setTimeout(() => this.Connect(), TIMEOUT);
      return Promise.reject(error);
    }
  }

  async Disconnect() {
    await this.connection.stop();
  }

  async RegisterCallbacks() {
    this.connection.onclose(async () => {
      await this.Connect();
    });
  }

  // ---------------- INCOMING -----------------

  // ---------------- OUTGOING -----------------
  async CreateGroup() {}

  async SendMessage(msg) {
    await this.connection.invoke("SendMessage", msg);
  }
}
