import axiosClient from "../api/axiosClient";

interface LoginResponse {
  token: string;
}

export async function login(email: string, password: string): Promise<void> {
  const response = await axiosClient.post<LoginResponse>("/auth/login", { email, password });
  localStorage.setItem("token", response.data.token);
}
