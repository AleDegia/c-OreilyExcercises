import { Link} from "react-router-dom";
import { useState } from "react";

export default function SituazioneRistoranti({restaurantSummaries})
{
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [message, setMessage] = useState(""); 


    const [form, setForm] = useState({
        ragioneSociale: "",
        partitaIva: "",
        indirizzo: "",
        tipologiaId: "",
        numeroPosti: "",
        prezzoMedio: ""
    });

    const getRestaurants = async () => {
        try {
            const response = await fetch("/api/ristoranti");
            const data = await response.json();
            console.log(data);
        } catch (error) {
            console.error("Errore durante il recupero dei ristoranti:", error);
        }
    };

    const handleChange = (e) => {
        const { name, value } = e.target;

        setForm((prevForm) => ({
            ...prevForm,
            [name]: value
        }));
    };

    async function handleSubmit(event) {
        event.preventDefault();

        try {
            const response = await fetch("/api/ristoranti/nuovo", {
                method: "POST",   
                credentials: "include", 
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(form)                  //converto oggetto in json da inviare al server
            });   

            if (response.ok) {
                setMessage("Ristorante aggiunto correttamente");
                return;
            }
            if (response.status === 401) {
                setMessage("Errore durante l'inserimento");
                return;
            }

            setMessage("Errore durante l'inserimento");
        } catch {
            setMessage("Server non raggiungibile");
        }
    }

    return (
        <article className="home-panel restaurant-summary-panel">
            <h2>Riepilogo ristoranti</h2>

            <div className="restaurant-table">
                <div className="restaurant-table-head">
                    <span>Ristorante</span>
                    <span>Stato</span>
                    <span>Prenotazioni oggi</span>
                    <span>Clienti</span>
                    <span>Occupazione</span>
                </div>

                {restaurantSummaries.map((restaurant) => (
                    <div className="restaurant-table-row" key={restaurant.name}>
                        <div>
                            <strong>{restaurant.ragioneSociale}</strong>
                            <span>{restaurant.address}</span>
                        </div>
                        <span className="restaurant-status">Attivo</span>
                        <strong>{restaurant.bookings}</strong>
                        <strong>{restaurant.clients}</strong>
                        <div className="restaurant-occupancy">
                            <span>
                                <b style={{ width: `${restaurant.occupancy}%` }}></b>
                            </span>
                            <strong>{restaurant.occupancy}%</strong>
                        </div>
                    </div>
                ))}
            </div>
            <div className="restaurant-actions">
                <Link
                    to="/ristoranti"
                    className="restaurant-action restaurant-action-secondary"
                >
                    Vedi tutti i ristoranti
                    <span aria-hidden="true">→</span>
                </Link>

                <button
                    className="restaurant-action restaurant-action-primary"
                    onClick={() => setIsModalOpen(true)}            /*passo callback cosi non esegue subito il metodo*/
                >
                    <span aria-hidden="true">＋</span>
                    Aggiungi ristorante
                </button>
            </div>

            {/*frontend modale*/}
            {isModalOpen && (
                <div
                    className="modal-overlay"
                    onClick={() => setIsModalOpen(false)}
                >
                    <div
                        className="modal-content"
                        onClick={(event) => event.stopPropagation()}
                    >
                        <button
                            type="button"
                            className="modal-close"
                            onClick={() => setIsModalOpen(false)}
                            aria-label="Chiudi modale"
                        >
                            ×
                        </button>

                        <h2>Aggiungi ristorante</h2>

                        <form onSubmit={handleSubmit}>
                            {/* campi del form */}
                            <div className="form-group">
                                <label htmlFor="ragioneSociale">
                                    Ragione sociale
                                </label>
                                <input
                                    type="text"
                                    id="ragioneSociale"
                                    name="ragioneSociale"
                                    value={form.ragioneSociale}
                                    onChange={(e) =>
                                        setForm({
                                            ...form,
                                            ragioneSociale: e.target.value
                                        })
                                    }
                                    placeholder="Es. Osteria Centro"
                                    required
                                />
                            </div>
                            <div className="form-group">
                                <label htmlFor="partitaIva">
                                    Partita IVA
                                </label>
                                <input
                                    type="text"
                                    id="partitaIva"
                                    name="partitaIva"
                                    value={form.partitaIva}
                                    onChange={handleChange}
                                    placeholder="Es. 12345678901"
                                    required
                                />
                            </div>

                            <div className="form-group form-group-full">
                                <label htmlFor="indirizzo">
                                    Indirizzo
                                </label>
                                <input
                                    type="text"
                                    id="indirizzo"
                                    name="indirizzo"
                                    value={form.indirizzo}
                                    onChange={handleChange}
                                    placeholder="Es. Via Roma 10, Milano"
                                    required
                                />
                            </div>

                            <div className="form-group">
                                <label htmlFor="tipologiaId">
                                    Tipologia
                                </label>
                                <select
                                    id="tipologiaId"
                                    name="tipologiaId"
                                    value={form.tipologiaId}
                                    onChange={handleChange}
                                    required
                                >
                                    <option value="">Seleziona una tipologia</option>
                                    <option value="1">Italiano</option>
                                    <option value="2">Pizzeria</option>
                                    <option value="3">Sushi</option>
                                    <option value="4">Fast Food</option>
                                </select>
                            </div>

                            <div className="form-group">
                                <label htmlFor="numeroPosti">
                                    Numero posti
                                </label>
                                <input
                                    type="number"
                                    id="numeroPosti"
                                    name="numeroPosti"
                                    value={form.numeroPosti}
                                    onChange={handleChange}
                                    min="1"
                                    placeholder="Es. 50"
                                    required
                                />
                            </div>

                            <div className="form-group">
                                <label htmlFor="prezzoMedio">
                                    Prezzo medio 
                                </label>
                                <input
                                    type="number"
                                    id="prezzoMedio"
                                    name="prezzoMedio"
                                    value={form.prezzoMedio}
                                    onChange={handleChange}
                                    min="0"
                                    step="0.01"
                                    placeholder="Es. 35"
                                />
                            </div>
                            <div>
                                <button type="submit">Invio</button>
                                {  message &&
                                  <p>{message}</p>
                                }
                            </div>
                        </form>
                    </div>
                </div>
            )}
            

        </article>

    )
}