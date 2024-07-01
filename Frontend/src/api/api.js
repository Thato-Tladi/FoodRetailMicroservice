import axios from "axios";
import { getToken } from "./auth";

//dummy baseurl replace with real
const api = axios.create({
  baseURL: "https://api.sustenance.projects.bbdgrad.com/api",
  headers: {
    "Content-Type": "application/json",
  },
});

api.interceptors.request.use(
  async (config) => {
    try {
      const token = await getToken();
      if (token) {
        config.headers.Authorization = `Bearer ${token}`;
      }
    } catch (error) {
      console.error("Error setting token:", error);
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

//dummy example api call replace endpath
export const getConsumerHistory = async () => {
  try {
    const response = await api.get("/ConsumerHistory");

    return response.data;
  } catch (error) {
    throw error;
  }
};

export default api;
