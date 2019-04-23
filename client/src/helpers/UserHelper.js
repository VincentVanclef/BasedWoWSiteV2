import Store from "../store";

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
  }
};
