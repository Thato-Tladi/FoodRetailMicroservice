import axios from "axios";
import { getToken } from "./auth";

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

const parseDate = (dateString) => {
  const [day, month, year] = dateString.split("|").map(Number);
  return new Date(`20${year}`, month - 1, day);
};

export const getConsumerHistory = async () => {
  try {
    const response = await axios.get(
      "https://api.sustenance.projects.bbdgrad.com/api/ConsumerHistory"
    );
    const data = response.data.map((item) => ({
      ...item,
      purchasedDate: parseDate(item.purchasedDate),
    }));
    return data;
  } catch (error) {
    throw error;
  }
};

export const getFinancialInfo = async () => {
  try {
    const response = await axios.get(
      "https://api.sustenance.projects.bbdgrad.com/api/FinancialInfo"
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};
export default api;
