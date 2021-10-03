import Api from "./Api";

export default {
  getLocationsList: () => Api.get("/locations"),

  getLocationsStatsList: () => Api.get("/locations/stats"),

  createLocation: (name) => Api.post("/locations", { name }),

  editLocation: (id, name) => Api.put(`/locations/${id}`, { name }),

  //   deleteLocation: (id) => Api.delete(`/todo/${id}`),
};
