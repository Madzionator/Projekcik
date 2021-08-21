import Api from "./Api";

const authTokenKey = "auth_token";

export default {
  register: (login, password) => Api.post("/uer/create", { login, password }),
  login: (login, password) =>
    Api.post("/user/login", { login, password }).then((response) => {
      const token = response;
      window.localStorage.setItem(authTokenKey, token);
    }),
  logout: () => {
    window.localStorage.removeItem(authTokenKey);
  },
  isLogged: () => {
    //todo: validate token expiry date
    return !!window.localStorage.getItem(authTokenKey);
  },
};
