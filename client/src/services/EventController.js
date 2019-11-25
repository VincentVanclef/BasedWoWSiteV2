import UserHelper from "@/helpers/UserHelper";
import { HubConnectionState } from "@aspnet/signalr";

export default class EventController {
  constructor(vm) {
    this.vm = vm;
    this.store = vm.$store;
    this.signalR = vm.$signalR;
  }

  // ------------- local Functions --------------
  SynchronizeAccountData() {
    const user = this.store.getters["user/GetUser"];
    const accountId = user.accountId;
    if (this.signalR.connectionState == HubConnectionState.Connected) {
      this.signalR.invoke("SynchronizeAccountData", accountId);
    }
  }

  GetGroupChats() {
    this.store.dispatch("chat/GetGroupChats");
  }

  GetNewestUser() {
    this.store.dispatch("stats/GetNewestUser");
  }

  GetAdminsAndModerators() {
    this.store.dispatch("admin/FetchAdmins");
  }

  // ------------------ HOOKS -------------------
  OnLogin() {
    this.GetGroupChats();
  }

  OnLogout() {
    this.store.commit("chat/Clear");
  }

  Initialize() {
    this.GetNewestUser();
    this.GetAdminsAndModerators();

    if (UserHelper.IsLoggedIn()) {
      this.GetGroupChats();
      this.SynchronizeAccountData();
    }
  }

  // ---------------- RUN HOOKS -----------------
  RunHooks() {
    this.vm.$on("Login", () => this.OnLogin());
    this.vm.$on("Logout", () => this.OnLogout());
    this.vm.$on("Initialize", () => this.Initialize());
  }
}
