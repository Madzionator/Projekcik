import axios from "axios";
import config from "../config";

const axiosAPI = axios.create({
  baseURL: config.baseUrl,
});

const apiRequest = (method, url, request) => {
  const headers = {
    authorization: "",
    Accept: "application/json",
    "Content-Type": "application/json",
  };
  return axiosAPI({
    method,
    url,
    data: request,
    headers,
  })
    .then((res) => {
      return Promise.resolve(res.data);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

const get = (url, request) => apiRequest("get", url, request);

const deleteRequest = (url, request) => apiRequest("delete", url, request);

const post = (url, request) => apiRequest("post", url, request);

const put = (url, request) => apiRequest("put", url, request);

const patch = (url, request) => apiRequest("patch", url, request);

const API = {
  get,
  delete: deleteRequest,
  post,
  put,
  patch,
};
export default API;