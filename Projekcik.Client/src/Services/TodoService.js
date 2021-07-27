import Api from "./Api";

export default {
  getTodoList: () => Api.get("/todo"),

  createTodo: (title, termin) => Api.post("/todo", { title, termin }),

  deleteTodo: (id) => Api.delete(`/todo/${id}`),
};
