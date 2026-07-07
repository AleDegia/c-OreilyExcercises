import { useState } from "react";

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
        }
    }

    return (
        <div>
            <h1>Registrazione</h1>

            <form onSubmit={handleSubmit}>
                <input type="text" name="userName" placeholder="Username" value={form.userName} onChange={handleChange} />
                <br /><br />

                <input type="password" name="password" placeholder="Password" value={form.password} onChange={handleChange} />
                <br /><br />

                <input type="text" name="descrizione" placeholder="Descrizione" value={form.descrizione} onChange={handleChange} />
                <br /><br />

                <input type="email" name="email" placeholder="Email" value={form.email} onChange={handleChange} />
                <br /><br />

                <input type="text" name="telefono" placeholder="Telefono" value={form.telefono} onChange={handleChange} />
                <br /><br />

                <input type="text" name="citta" placeholder="Citta" value={form.citta} onChange={handleChange} />
                <br /><br />

                <button type="submit">Registrati</button>
            </form>

            {errors.length > 0 && (
                <ul>
                    {errors.map((error) => (
                        <li key={error}>{error}</li>
                    ))}
                </ul>
            )}

            <p>{message}</p>
        </div>
    );
}
