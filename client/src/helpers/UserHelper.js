import store from "../store";
import Ranks from "../data/models/Ranks";
import WoWClasses from "@/data/models/WoWClasses";

export default {
  name: "UserHelper",
  IsLoggedIn: () => {
    const token = store.getters["user/GetToken"];
    if (!token) {
      return false;
    }

    const data = JSON.parse(atob(token.split(".")[1]));
    const exp = new Date(data.exp * 1000); // JS deals with dates in milliseconds since epoch
    const now = new Date();
    return now < exp;
  },

  HasRole: roles => {
    const user = store.getters["user/GetUser"];
    return user ? user.roles.some(val => roles.includes(val)) : false;
  },

  IsAdmin: () => {
    const user = store.getters["user/GetUser"];
    return user ? user.roles.includes(Ranks.WebsiteRoles.ADMIN) : false;
  },

  IsModerator: () => {
    const user = store.getters["user/GetUser"];
    return user ? user.roles.includes(Ranks.WebsiteRoles.MODERATOR) : false;
  },

  Equals: userId => {
    const user = store.getters["user/GetUser"];
    return user ? user.id == userId : false;
  },

  CanShout: () => {
    const user = store.getters["user/GetUser"];
    return user ? user.shoutBoxTimer : false;
  },

  GetRoleColor: role => {
    switch (role) {
      case Ranks.WebsiteRoles.ADMIN:
        return "Red";
      case Ranks.WebsiteRoles.MODERATOR:
        return "Blue";
    }
  },

  GetGameRankName: rank => {
    switch (rank) {
      case Ranks.GameRanks.ADMIN:
        return "Admin";
      case Ranks.GameRanks.GAMEMASTER:
        return "GameMaster";
      case Ranks.GameRanks.TRIAL:
        return "Trial GameMaster";
      case Ranks.GameRanks.PLAYER:
        return "Player";
    }
  },

  GetGameRankColor: rank => {
    switch (rank) {
      case Ranks.GameRanks.ADMIN:
        return "Red";
      case Ranks.GameRanks.GAMEMASTER:
        return "Blue";
      case Ranks.GameRanks.TRIAL:
        return "Teal";
      case Ranks.GameRanks.PLAYER:
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
