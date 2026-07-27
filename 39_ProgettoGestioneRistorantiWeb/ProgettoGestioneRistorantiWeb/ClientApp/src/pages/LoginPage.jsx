import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { Eye, EyeOff, LockKeyhole, UserRound } from "lucide-react";
import AuthLayout from "../components/AuthLayout";

export default function LoginPage() {            
    const [form, setForm] = useState({              //faccio state 'form' con valori di default
        userName: "",
        password: ""
    });

    const [message, setMessage] = useState("");
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [showPassword, setShowPassword] = useState(false);
    const navigate = useNavigate();

    return (
        <AuthLayout
            eyebrow="Bentornato"
            title="Accedi al tuo spazio"
            subtitle="Inserisci le tue credenziali per continuare a gestire la tua attività."
            footer={<>Non hai ancora un account? <Link to="/register">Crealo ora</Link></>}
        >
            <form className="auth-form" onSubmit={handleSubmit}>
                <label className="auth-field">
                    <span>Username</span>
                    <div className="auth-input">
                        <UserRound size={18} aria-hidden="true" />
                        <input
                            type="text"
                            name="userName"
                            placeholder="Il tuo username"
                            value={form.userName}
                            onChange={handleChange}
                            autoComplete="username"
                            required
                        />
                    </div>
                </label>

                <label className="auth-field">
                    <span>Password</span>
                    <div className="auth-input">
                        <LockKeyhole size={18} aria-hidden="true" />
                        <input
                            type={showPassword ? "text" : "password"}
                            name="password"
                            placeholder="Inserisci la password"
                            value={form.password}
                            onChange={handleChange}
                            autoComplete="current-password"
                            required
                        />
                        <button
                            className="auth-password-toggle"
                            type="button"
                            onClick={() => setShowPassword((visible) => !visible)}   //inverto valore attuale
                            aria-label={showPassword ? "Nascondi password" : "Mostra password"}
                        >
                            {showPassword ? <EyeOff size={18} /> : <Eye size={18} />}
                        </button>
                    </div>
                </label>

                {message && (
                    <p className="auth-message auth-message-error" role="alert">{message}</p>
                )}

                <button className="auth-submit" type="submit" disabled={isSubmitting}>
                    {isSubmitting ? "Accesso in corso..." : "Accedi"}
                </button>
            </form>
        </AuthLayout>
    );

    function handleChange(event) {                      //chiamata ogni volta che l'utente scrive in un <input>.
        const { name, value } = event.target;           
        setForm({
            ...form,
            [name]: value                               //aggiorno lo state 'form' con il nuovo valore dell'input che ha triggerato l'evento
        });
    }
    
    async function handleSubmit(event) {
        event.preventDefault();
        setMessage("");
        setIsSubmitting(true);

        try {
            const response = await fetch("/api/auth/login", {
                method: "POST",   
                credentials: "include", 
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(form)                  //converto oggetto in json da inviare al server
            });   

            if (response.ok) {
                setMessage("Login completato");
                navigate("/home", { replace: true });       //reindirizzo l'utente alla homepage dopo il login (ma va a protected route, e se non è autenticato lo reindirizza a login)
                return;
            }
            if (response.status === 401) {
                setMessage("Username o password errati");
                return;
            }

            setMessage("Errore durante il login");
        } catch {
            setMessage("Server non raggiungibile");
        } finally {
            setIsSubmitting(false);
        }
    }
}
