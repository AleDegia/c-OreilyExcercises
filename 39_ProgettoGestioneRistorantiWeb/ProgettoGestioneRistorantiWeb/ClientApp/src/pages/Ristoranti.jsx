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

    //filtri
    const [ricerca, setRicerca] = useState("");
    const [citta, setCitta] = useState("");
    const [ordinamento, setOrdinamento] = useState("az");

    const ristorantiFiltrati = ristoranti  
    //ricerca per nome         
    .filter((ristorante) => {                                                     //rieseguito al rerender (filter, x ogni rist, restituisce i rist per cui ritorna true)
        const matchRicerca = ristorante.ragioneSociale
            .toLowerCase()
            .includes(ricerca.toLowerCase());

        //controllo se città selezionata con filtro (con setCitta) è uguale a ristorante.citta (citta del rist su cui sto looppando)
        const matchCitta = citta === "" || ristorante.citta === citta;   

        return matchRicerca && matchCitta;
    })
        
    //ordinamento
    .sort((a, b) => {
        switch (ordinamento) {
            case "az":
                return a.ragioneSociale.localeCompare(b.ragioneSociale, "it");

            case "za":
                return b.ragioneSociale.localeCompare(a.ragioneSociale, "it");

            case "prezzo-crescente":
                return Number(a.prezzoMedio) - Number(b.prezzoMedio);

            case "prezzo-decrescente":
                return Number(b.prezzoMedio) - Number(a.prezzoMedio);

            default:
                return 0;
        
        }
    })

    //statistiche hardcoded
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

    useEffect(() => {

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
                    
                        <Filtri ricerca={ricerca} setRicerca={setRicerca} citta={citta} setCitta={setCitta} ordinamento={ordinamento} setOrdinamento={setOrdinamento}/>
                        <>
                            {/*dato che questo metodo si trova all'interno del componente viene rieseguito a ogni rerender*/}
                            {ristorantiFiltrati.map((ristorante) => (
                                <CardRistorante
                                    key={ristorante.id}
                                    ristorante={ristorante}
                                    refreshRistoranti={caricaRistoranti}
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
