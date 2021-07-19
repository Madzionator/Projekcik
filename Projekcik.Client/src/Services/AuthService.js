import Api from "./Api";

const authTokenKey = "auth_token";

export default {
  register: (login, password) => Api.post("/User/create", { login, password }),
  login: (login, password) =>
    Api.post("/User/login", { login, password }).then((response) => {
      const token = response;
      window.localStorage.setItem(authTokenKey, token);
    }),
  logout() {
    window.localStorage.removeItem(authTokenKey);
  },
};
