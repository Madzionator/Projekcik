import Api from "./Api";

export default {
  getHelloWorldList: async () => {
    return await Api.get("/HelloWorld");
  },
  postHelloWorld: async (name) => {
    return await Api.post("/HelloWorld", name);
  },
  removeHelloWorld: async (id) => {
    return Api.delete(`/HelloWorld/${id}`);
  },
  editHelloWorld: async (id, name) => {
    return Api.put(`/HelloWorld/${id}`, name);
  },
};
