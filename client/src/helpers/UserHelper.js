import Store from "../store";
import moment from "moment";
import GMRanks from "../data/models/Ranks";
import WoWClasses from "@/data/models/WoWClasses";

export default {
  name: "UserHelper",
  IsLoggedIn: () => {
    const token = Store.getters["user/GetToken"];
    if (!token) {
      return false;
    }

    const data = JSON.parse(atob(token.split(".")[1]));
    const exp = new Date(data.exp * 1000); // JS deals with dates in milliseconds since epoch
    const now = new Date();
    return now < exp;
  },

  GetUserRank: () => {
    const user = Store.getters["user/GetUser"];
    return user ? user.rank : 0;
  },

  IsAdmin: () => {
    const user = Store.getters["user/GetUser"];
    return user ? user.rank >= GMRanks.ADMIN : false;
  },

  IsGameMaster: () => {
    const user = Store.getters["user/GetUser"];
    return user ? user.rank >= GMRanks.GAMEMASTER : false;
  },

  IsTrial: () => {
    const user = Store.getters["user/GetUser"];
    return user ? user.rank >= GMRanks.TRIAL : false;
  },

  IsPlayer: () => {
    const user = Store.getters["user/GetUser"];
    return user.rank == GMRanks.PLAYER || !user;
  },

  Equals: userId => {
    const user = Store.getters["user/GetUser"];
    return user ? user.id == userId : false;
  },

  CanShout: () => {
    const user = Store.getters["user/GetUser"];
    return user ? user.shoutBoxTimer : false;
  },

  GetRankName: rank => {
    switch (rank) {
      case GMRanks.ADMIN:
        return "Admin";
      case GMRanks.GAMEMASTER:
        return "Gamemaster";
      case GMRanks.TRIAL:
        return "Trial Gamemaster";
      case GMRanks.PLAYER:
        return "Player";
    }
  },

  GetRankColor: rank => {
    switch (rank) {
      case GMRanks.ADMIN:
        return "Red";
      case GMRanks.GAMEMASTER:
        return "Blue";
      case GMRanks.TRIAL:
        return "Teal";
      case GMRanks.PLAYER:
        return "Green";
    }
  },

  GetClassColor: classId => {
    const _class = WoWClasses.get(classId);
    return _class ? _class.color : "";
  },

  GetClassName: classId => {
    const _class = WoWClasses.get(classId);
    return _class ? _class.name : "";
  }
};
