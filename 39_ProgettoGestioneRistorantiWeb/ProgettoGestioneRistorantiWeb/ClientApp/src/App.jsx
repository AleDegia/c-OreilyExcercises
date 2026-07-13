import { Routes, Route, Navigate } from "react-router-dom";
import HomePage from "./pages/HomePage";
import HomePage2 from "./pages/HomePage2";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import ProtectedRoute from "./components/ProtectedRoute";

function App() {
  return (
    <Routes>
      <Route path="/" element={<LoginPage />} />
      <Route path="/login" element={<LoginPage />} />
      <Route path="/register" element={<RegisterPage />} />
      <Route path="/home2" element={<HomePage2 />} />

      <Route                    /*Protected Route fa si che la pagina sia accessibile solo se l'utente è autenticato*/
        path="/home"
        element={
                  <ProtectedRoute>          {/*faccio il wrap della pagina con il componente ProtectedRoute*/}
                      <HomePage />
                  </ProtectedRoute>
                }
      />

      <Route path="/" element={<Navigate to="/login" replace />} />
    </Routes>
  );
}

export default App;
