import { token } from "../stores";
import Api from "./Api";

const authTokenKey = "auth_token";

export default {
  register: (login, password) => Api.post("/user/create", { login, password }),
  login: (login, password) =>
    Api.post("/user/login", { login, password }).then((response) => {
      const tokenValue = response;
      window.localStorage.setItem(authTokenKey, tokenValue);
      token.set(window.localStorage.getItem(authTokenKey));
    }),
  logout: () => {
    window.localStorage.removeItem(authTokenKey);
    token.set(window.localStorage.getItem(authTokenKey));
  },
  isLogged: () => {
    //todo: validate token expiry date
    return !!window.localStorage.getItem(authTokenKey);
  },
};
