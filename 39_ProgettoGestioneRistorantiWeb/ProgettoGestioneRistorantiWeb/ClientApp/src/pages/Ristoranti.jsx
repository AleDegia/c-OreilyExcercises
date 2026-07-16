import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import Sidebar from "../components/Sidebar";
import StatsGridRistoranti from "../components/ristoranti/StatsGridRistoranti";
import Filtri from "../components/ristoranti/Filtri";
import CardRistorante from "../components/ristoranti/CardRistorante";
import {
  Store,
  CircleCheck,
  CirclePause,
  MapPin,
} from "lucide-react";



export default function Ristoranti() {
    const [ristoranti, setRistoranti] = useState([]);
    const [caricamento, setCaricamento] = useState(true);
    const [errore, setErrore] = useState("");

    const stats = [
        {
            label: "Totale ristoranti",
            value: 12,
            icon: <Store size={22} />,
            color: "blue",
        },
        {
            label: "Attivi",
            value: 10,
            icon: <CircleCheck size={22} />,
            color: "green",
        },
        {
            label: "Inattivi",
            value: 2,
            icon: <CirclePause size={22} />,
            color: "gray",
        },
        {
            label: "Città presenti",
            value: "9 / 12",
            icon: <MapPin size={22} />,
            color: "purple",
        },
    ];

    useEffect(() => {
        async function caricaRistoranti() {
            try {
                const response = await fetch("/api/ristoranti/miei", {
                    credentials: "include"
                });

                if (response.status === 404) {
                    setRistoranti([]);
                    return;
                }

                if (!response.ok) {
                    throw new Error("Errore durante il caricamento dei ristoranti");
                }

                const dati = await response.json();         //response.json legge il body e converte il json in array (o ogg se è un solo elemento) javascript
                setRistoranti(dati);                        //carico l'array in ristoranti
            } catch (error) {
                setErrore(error.message);
            } finally {
                setCaricamento(false);
            }
        }

        caricaRistoranti();
    }, []);

    return (
        <div className="home-container">
                <Sidebar/>
                <main className="restaurants-main">
                    <Link to="/home">← Torna alla dashboard</Link>
                    <h1>I miei ristoranti</h1>

                    <StatsGridRistoranti stats={stats}/>

                    {errore && <p>{errore}</p>}

                    {!caricamento && !errore && ristoranti.length === 0 && (
                        <p>Non hai ancora registrato ristoranti.</p>
                    )}

                    <div className="RistEFiltriContainer">
                    
                        <Filtri/>
                        <>
                            {ristoranti.map((ristorante) => (
                                <CardRistorante
                                    key={ristorante.id}
                                    ristorante={ristorante}
                                />
                            ))}
                        </>
                        {/*
                        {ristoranti.map((ristorante) => (
                            <article
                                key={ristorante.id}
                                style={{ borderBottom: "1px solid #cccccc", padding: "16px 0" }}
                            >
                                <h2>{ristorante.ragioneSociale}</h2>
                                <p><strong>Indirizzo:</strong> {ristorante.indirizzo}</p>
                                <p><strong>Città:</strong> {ristorante.citta || "Non indicata"}</p>
                                <p><strong>Telefono:</strong> {ristorante.telefono || "Non indicato"}</p>
                                <p><strong>Numero posti:</strong> {ristorante.numeroPosti}</p>
                                <p><strong>Prezzo medio:</strong> € {ristorante.prezzoMedio}</p>
                            </article>
                        ))}
                        */}
                    </div>
                </main>
        </div>
    );
}
