import API from "./Api";

export default {
  applyForJob: (jobId, formData) => API.post(`/candidate/${jobId}`, formData),

  getCandidatesList: () => API.get("/candidate"),

  downloadFile: (candidateId) =>
    API.blobGet(`/candidate/download-request/${candidateId}`),

  deleteCandidate: (id) => API.delete(`/candidate/${id}`),
};
