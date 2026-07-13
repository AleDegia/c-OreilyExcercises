import { Routes, Route } from "react-router-dom";
import HomePage from "./pages/HomePage";
import HomePage2 from "./pages/HomePage2";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";

function App() {
  return (
    <Routes>
      <Route path="/" element={<LoginPage />} />
      <Route path="/register" element={<RegisterPage />} />
      <Route path="/home" element={<HomePage />} />
      <Route path="/home2" element={<HomePage2 />} />
    </Routes>
  );
}

export default App;
