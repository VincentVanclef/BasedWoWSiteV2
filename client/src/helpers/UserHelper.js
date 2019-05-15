import Store from "../store";
import GMRanks from "../data/models/Ranks";

export default {
  name: "UserHelper",
  IsLoggedIn: () => {
    const token = Store.getters.GetToken;
    if (!token) {
      return false;
    }

    const data = JSON.parse(atob(token.split(".")[1]));
    const exp = new Date(data.exp * 1000); // JS deals with dates in milliseconds since epoch
    const now = new Date();
    return now < exp;
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
  }
};
