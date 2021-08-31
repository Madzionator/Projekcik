import Api from "./Api";

export default {
  getLocationsList: () => Api.get("/locations"),

  createLocation: (name) => Api.post("/locations", { name }),

  editLocation: (id, name) => Api.put(`/locations/${id}`, { name }),

  //   deleteLocation: (id) => Api.delete(`/todo/${id}`),
};
