import UserHelper from "@/helpers/UserHelper";

export default class EventController {
  constructor(vm) {
    this.vm = vm;
    this.store = vm.$store;
  }

  // ------------------ local Functions -------------------
  GetGroupChats() {
    const loaded = this.store.getters["chat/GetLoadingStatus"];
    if (!loaded) {
      this.store.dispatch("chat/GetGroupChats");
    }
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
    }
  }

  RunHooks() {
    this.vm.$on("Login", () => this.OnLogin());
    this.vm.$on("Logout", () => this.OnLogout());
    this.vm.$on("Initialize", () => this.Initialize());
  }
}
