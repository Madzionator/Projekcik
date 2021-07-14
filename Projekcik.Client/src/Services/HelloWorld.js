import Api from "./Api";

export const getHelloWorldList = async () => {
  return await Api.get("/HelloWorld");
};

export const postHelloWorld = async (name) => {
  return await Api.post("/HelloWorld", name);
};

export const removeHelloWorld = async (id) => {
  return Api.delete(`/HelloWorld/${id}`);
};
