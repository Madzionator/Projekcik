import Api from "./Api";

export default {
  getTodoList: () => Api.get("/todo"),
};
