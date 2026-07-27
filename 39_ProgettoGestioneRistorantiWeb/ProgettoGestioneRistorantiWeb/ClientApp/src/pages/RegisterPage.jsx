import { useState } from "react";
import { Link } from "react-router-dom";
import { Eye, EyeOff, FileText, LockKeyhole, Mail, MapPin, Phone, UserRound } from "lucide-react";
import AuthLayout from "../components/AuthLayout";

export default function RegisterPage() {
    const [form, setForm] = useState({
        userName: "",
        password: "",
        descrizione: "",
        email: "",
        telefono: "",
        citta: ""
    });

    const [message, setMessage] = useState("");
    const [errors, setErrors] = useState([]);
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [showPassword, setShowPassword] = useState(false);

    function handleChange(event) {
        const { name, value } = event.target;

        setForm({
            ...form,
            [name]: value
        });
    }

    async function handleSubmit(event) {
        event.preventDefault();
        setMessage("");
        setErrors([]);
        setIsSubmitting(true);

        try {
            const response = await fetch("/api/auth/register", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(form)
            });

            if (response.ok) {
                setMessage("Registrazione completata");
                return;
            }

            if (response.status === 409) {
                setMessage("Username gia esistente");
                return;
            }

            if (response.status === 400) {
                const data = await response.json();
                const validationErrors = Object.values(data.errors ?? {}).flat();       //estraggo gli errori di validazione dal server se ci sono, e li converto in un array (da array di array a array singolo cosi con map posso ciclare sulle stringhe di errore))
                console.log(data);
                console.log(data.errors);

                if (validationErrors.length > 0) {
                    setErrors(validationErrors);
                    return;
                }
            }

            setMessage("Errore durante la registrazione");
        } catch {
            setMessage("Server non raggiungibile");
        } finally {
            setIsSubmitting(false);
        }
    }

    return (
        <AuthLayout
            eyebrow="Inizia da qui"
            title="Crea il tuo account"
            subtitle="Configura il tuo profilo per iniziare a gestire i tuoi ristoranti."
            footer={<>Hai già un account? <Link to="/login">Accedi</Link></>}
        >
            <form className="auth-form auth-form-register" onSubmit={handleSubmit}>
                <AuthField label="Username" icon={<UserRound size={18} />} input={{
                    type: "text", name: "userName", placeholder: "Almeno 4 caratteri",
                    value: form.userName, autoComplete: "username", minLength: 4, required: true
                }} onChange={handleChange} />

                <label className="auth-field">
                    <span>Password</span>
                    <div className="auth-input">
                        <LockKeyhole size={18} aria-hidden="true" />
                        <input
                            type={showPassword ? "text" : "password"}
                            name="password"
                            placeholder="Almeno 8 caratteri"
                            value={form.password}
                            onChange={handleChange}
                            autoComplete="new-password"
                            minLength="8"
                            required
                        />
                        <button
                            className="auth-password-toggle"
                            type="button"
                            onClick={() => setShowPassword((visible) => !visible)}
                            aria-label={showPassword ? "Nascondi password" : "Mostra password"}
                        >
                            {showPassword ? <EyeOff size={18} /> : <Eye size={18} />}
                        </button>
                    </div>
                    <small>Usa lettere, un numero e un carattere speciale.</small>
                </label>

                <AuthField label="Email" icon={<Mail size={18} />} input={{
                    type: "email", name: "email", placeholder: "nome@esempio.it",
                    value: form.email, autoComplete: "email"
                }} onChange={handleChange} />

                <AuthField label="Telefono" icon={<Phone size={18} />} input={{
                    type: "tel", name: "telefono", placeholder: "+39 333 123 4567",
                    value: form.telefono, autoComplete: "tel"
                }} onChange={handleChange} />

                <AuthField label="Città" icon={<MapPin size={18} />} input={{
                    type: "text", name: "citta", placeholder: "La tua città",
                    value: form.citta, autoComplete: "address-level2"
                }} onChange={handleChange} />

                <AuthField label="Descrizione" icon={<FileText size={18} />} input={{
                    type: "text", name: "descrizione", placeholder: "Il tuo ruolo o la tua attività",
                    value: form.descrizione
                }} onChange={handleChange} />

                {(errors.length > 0 || message) && (
                    <div
                        className={`auth-message ${message === "Registrazione completata" ? "auth-message-success" : "auth-message-error"}`}
                        role="alert"
                    >
                        {message && <p>{message}</p>}
                        {errors.length > 0 && (
                            <ul>
                                {errors.map((error, index) => <li key={`${error}-${index}`}>{error}</li>)}
                            </ul>
                        )}
                    </div>
                )}

                <button className="auth-submit auth-register-submit" type="submit" disabled={isSubmitting}>
                    {isSubmitting ? "Creazione account..." : "Crea account"}
                </button>
            </form>
        </AuthLayout>
    );
}

function AuthField({ label, icon, input, onChange }) {
    return (
        <label className="auth-field">
            <span>{label}</span>
            <div className="auth-input">
                <span aria-hidden="true">{icon}</span>
                <input {...input} onChange={onChange} />
            </div>
        </label>
    );
}
