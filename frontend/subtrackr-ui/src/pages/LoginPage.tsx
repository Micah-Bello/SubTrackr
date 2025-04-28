import { useState } from "react";
import { login } from "../auth/authService";

export default function LoginPage() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError("");

    try {
      await login(email, password);
      window.location.href = "/subscriptions"; // Redirect after login
    } catch (err) {
      console.error(err);
      setError("Invalid credentials. Please try again.");
    }
  };

  return (
    <div style={{ maxWidth: 400, margin: "0 auto" }}>
      <h2>Login</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="email"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
          style={{ width: "100%", marginBottom: "10px" }}
        />
        <input
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
          style={{ width: "100%", marginBottom: "10px" }}
        />
        <button type="submit" style={{ width: "100%" }}>Login</button>
      </form>
      {error && <p style={{ color: "red" }}>{error}</p>}
    </div>
  );
}
