import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import SubscriptionsPage from "./pages/SubscriptionsPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<LoginPage />} />
        <Route path="/subscriptions" element={<SubscriptionsPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
