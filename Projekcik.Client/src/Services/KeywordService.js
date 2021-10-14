import Api from "./Api";

export default {
  getKeywordsList: () => Api.get("/keyword"),

  getKeywordsStatsList: () => Api.get("/keyword/stats"),

  createKeyword: (name) => Api.post("/keyword", { name }),

  editKeyword: (id, name) => Api.put(`/keyword/${id}`, { name }),

  deleteKeyword: (id) => Api.delete(`/keyword/${id}`),
};
