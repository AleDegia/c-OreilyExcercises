import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";

export default function LoginPage() {            
    const [form, setForm] = useState({              //faccio state 'form' con valori di default
        userName: "",
        password: ""
    });

    const [message, setMessage] = useState(""); 
    const navigate = useNavigate();

    return (
        <div>
            <h1>Login</h1>
            <form onSubmit={handleSubmit}>
                <input type="text" name="userName" placeholder="Username" value={form.userName} onChange={handleChange} />
                <br /><br />
                <input type="password" name="password" placeholder="Password" value={form.password} onChange={handleChange} />
                <br /><br />
                <button type="submit">Login</button>
                <Link to="/register">Registrati</Link>
            </form>
            {message && <p>{message}</p>}
        </div>
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

        try {
            const response = await fetch("/api/auth/login", {
                method: "POST",    
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
        }
    }
}
