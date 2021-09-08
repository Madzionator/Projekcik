import Api from "./Api";

export default {
  getJobsList: () => Api.get("/job"),

  createJob: (name) => Api.post("/job", { name }),

  editJob: (id, name) => Api.put(`/job/${id}`, { name }),
};
