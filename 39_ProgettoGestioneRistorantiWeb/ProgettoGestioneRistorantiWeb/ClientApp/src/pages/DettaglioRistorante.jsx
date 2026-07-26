import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { Eye, MapPin, MoreVertical, Pencil, Phone } from "lucide-react";
import Sidebar from "../components/Sidebar";

const sezioni = [
    "Panoramica",
    "Informazioni",
    "Prenotazioni",
    "Menu",
    "Tavoli",
    "Dipendenti",
    "Turni",
    "Costi e ricavi",
    "Clienti",
    "Galleria",
    "Impostazioni"
];

export default function DettaglioRistorante() {
    const { id } = useParams();
    const [ristorante, setRistorante] = useState(null);
    const [sezioneAttiva, setSezioneAttiva] = useState("Panoramica");
    const [errore, setErrore] = useState("");

    useEffect(() => {
        async function caricaRistorante() {
            try {
                const response = await fetch(`/api/ristoranti/${id}`, {
                    credentials: "include"
                });

                if (!response.ok) {
                    throw new Error("Ristorante non trovato");
                }

                setRistorante(await response.json());
            } catch (error) {
                setErrore(error.message);
            }
        }

        caricaRistorante();
    }, [id]);

    return (
        <div className="home-container">
            <Sidebar />

            <main className="restaurant-detail-main">
                <Link className="restaurant-detail-back" to="/ristoranti">
                    ← Torna alla lista ristoranti
                </Link>

                {errore && <p>{errore}</p>}
                {!ristorante && !errore && <p>Caricamento...</p>}

                {ristorante && (
                    <>
                        <header className="restaurant-detail-header">
                            {ristorante.immagine ? (
                                <img
                                    className="restaurant-detail-image"
                                    src={`data:image/jpeg;base64,${ristorante.immagine}`}
                                    alt={ristorante.ragioneSociale}
                                />
                            ) : (
                                <div className="restaurant-detail-image restaurant-detail-image--empty">
                                    Nessuna foto
                                </div>
                            )}

                            <div className="restaurant-detail-identity">
                                <div className="restaurant-detail-title">
                                    <h1>{ristorante.ragioneSociale}</h1>
                                    <span className="status-badge status-badge--active">Attivo</span>
                                </div>

                                <div className="restaurant-detail-meta">
                                    <span className="restaurant-type">Tipologia {ristorante.tipologiaId}</span>
                                    <span><MapPin size={15} /> {ristorante.indirizzo}, {ristorante.citta || "Città non indicata"}</span>
                                    <span><Phone size={15} /> {ristorante.telefono || "Telefono non indicato"}</span>
                                </div>
                            </div>

                            <div className="restaurant-detail-actions">
                                <button type="button"><Eye size={16} /> Anteprima pubblica</button>
                                <button type="button"><Pencil size={16} /> Modifica</button>
                                <button type="button" className="restaurant-detail-more" aria-label="Altre azioni">
                                    <MoreVertical size={18} />
                                </button>
                            </div>
                        </header>

                        <nav className="restaurant-detail-tabs" aria-label="Sezioni del ristorante">
                            {sezioni.map((sezione) => (
                                <button
                                    type="button"
                                    key={sezione}
                                    className={sezioneAttiva === sezione ? "active" : ""}
                                    onClick={() => setSezioneAttiva(sezione)}
                                >
                                    {sezione}
                                </button>
                            ))}
                        </nav>

                        <section className="restaurant-detail-placeholder">
                            <h2>{sezioneAttiva}</h2>
                            <p>I contenuti di questa sezione verranno aggiunti qui.</p>
                        </section>
                    </>
                )}
            </main>
        </div>
    );
}
