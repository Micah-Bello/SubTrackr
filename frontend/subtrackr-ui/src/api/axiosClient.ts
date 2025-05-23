import axios from "axios";

const axiosClient = axios.create({
    baseURL: "https://localhost:7082/api",
});

// Add token to headers if available
axiosClient.interceptors.request.use((config) => {
    const token = localStorage.getItem("token");
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

export default axiosClient;
