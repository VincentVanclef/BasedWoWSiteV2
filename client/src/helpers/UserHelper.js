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
    return user ? roles.includes(user.role) : false;
  },

  IsAdmin: () => {
    const user = store.getters["user/GetUser"];
    return user ? user.role === Ranks.WebsiteRoles.ADMIN : false;
  },

  IsModerator: () => {
    const user = store.getters["user/GetUser"];
    return user ? user.role === Ranks.WebsiteRoles.MODERATOR : false;
  },

  Equals: userId => {
    const user = store.getters["user/GetUser"];
    return user ? user.id == userId : false;
  },

  CanShout: () => {
    const user = store.getters["user/GetUser"];
    return user ? user.shoutBoxTimer : false;
  },

  GetRoleColor: rank => {
    switch (rank) {
      case Ranks.WebsiteRoles.ADMIN:
        return "Red";
      case Ranks.WebsiteRoles.MODERATOR:
        return "Blue";
    }
  },

  GetGameRankName: rank => {
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

  GetGameRankColor: rank => {
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
