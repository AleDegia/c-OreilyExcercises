import { useEffect, useState } from "react";
import { Navigate } from "react-router-dom";

export default function ProtectedRoute({ children }) {
    const [authStatus, setAuthStatus] = useState("loading");

    useEffect(() => {
        async function checkAuthentication() {
            try {
                const response = await fetch("/api/auth/check", {
                    credentials: "include"              //includo le credenzial del browser, tra cui i cookie, nella richiesta per verificare l'autenticazione
                });

                setAuthStatus(response.ok ? "authenticated" : "unauthenticated");
            } catch {
                setAuthStatus("unauthenticated");
            }
        }

        checkAuthentication();
    }, []);

    if (authStatus === "loading") {
        return <p>Caricamento...</p>;
    }

    if (authStatus === "unauthenticated") {
        return <Navigate to="/login" replace />;
    }

    return children;
}