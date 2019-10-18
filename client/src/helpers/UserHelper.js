import store from "../store";
import Ranks from "../data/models/Ranks";
import WoWClasses from "@/data/models/WoWClasses";
import WoWRaces from "@/data/models/WoWRaces";

export default {
  name: "UserHelper",
  IsLoggedIn: () => {
    return store.getters["user/IsUserLoggedIn"];
  },

  HasRole: roles => {
    const userRoles = store.getters["user/GetUserRoles"];
    return userRoles ? userRoles.some(val => roles.includes(val)) : false;
  },

  IsSuperAdmin: () => {
    const roles = store.getters["user/GetUserRoles"];
    return roles ? roles.includes(Ranks.WebsiteRoles.SUPERADMIN) : false;
  },

  IsAdmin: () => {
    const roles = store.getters["user/GetUserRoles"];
    return roles ? roles.includes(Ranks.WebsiteRoles.ADMIN) : false;
  },

  IsModerator: () => {
    const roles = store.getters["user/GetUserRoles"];
    return roles ? roles.includes(Ranks.WebsiteRoles.MODERATOR) : false;
  },

  CanModerate: function() {
    return this.IsAdmin() || this.IsModerator();
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
      case Ranks.WebsiteRoles.SUPERADMIN:
        return "Purple";
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

  GetGameRankNameShort: rank => {
    switch (rank) {
      case Ranks.GameRanks.ADMIN:
        return "Admin";
      case Ranks.GameRanks.GAMEMASTER:
        return "GM";
      case Ranks.GameRanks.TRIAL:
        return "Trial";
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

  GetRaceName: raceId => {
    const race = WoWRaces.get(raceId);
    return race ? race.name : "";
  },

  GetRaceColor: raceId => {
    const race = WoWRaces.get(raceId);
    return race ? race.color : "";
  },

  GetClassColor: classId => {
    return WoWClasses.GetClassColor(classId);
  },

  GetClassName: classId => {
    return WoWClasses.GetClassName(classId);
  },

  GetGender: genderId => {
    switch (genderId) {
      case 0:
        return "Male";
      case 1:
        return "Female";
    }
  },

  IsAlliance(race) {
    switch (parseInt(race, 10)) {
      case 1:
      case 3:
      case 4:
      case 7:
      case 11:
        return true;
    }

    return false;
  },

  IsHorde(race) {
    switch (parseInt(race, 10)) {
      case 2:
      case 5:
      case 6:
      case 8:
      case 9:
      case 10:
        return true;
    }

    return false;
  }
};
