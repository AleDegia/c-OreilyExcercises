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

    function handleChange(event) {
        const { name, value } = event.target;

        setForm({
            ...form,
            [name]: value
        });
    }

    async function handleSubmit(event) {
        event.preventDefault();

        const response = await fetch("http://localhost:5287/api/auth/register", {
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
            setMessage("Username già esistente");
            return;
        }

        setMessage("Errore durante la registrazione");
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

                <input type="text" name="citta" placeholder="Città" value={form.citta} onChange={handleChange} />
                <br /><br />

                <button type="submit">Registrati</button>
            </form>

            <p>{message}</p>
        </div>
    );
}