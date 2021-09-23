import API from "./Api";

export default {
  applyForJob: (jobId, formData) => API.post(`/candidate/${jobId}`, formData),
};
