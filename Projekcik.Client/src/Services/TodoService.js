import Api from "./Api";

export default {
  getTodoList: () => Api.get("/todo"),

  getTodo: (id) => Api.get(`/todo/${id}`),

  createTodo: (todo) => Api.post("/todo", todo),

  editTodo: (todo, id) => Api.put(`/todo/${id}`, todo),

  deleteTodo: (id) => Api.delete(`/todo/${id}`),
};
