import Api from "./Api";

export default {
  getJobsList: () => Api.get("/job"),

  getJob: (id) => Api.get(`/job/${id}`),

  createJob: (job) => Api.post("/job", job),

  editJob: (id, job) => Api.put(`/job/${id}`, job),

  deleteJob: (id) => Api.delete(`/job/${id}`),
};
