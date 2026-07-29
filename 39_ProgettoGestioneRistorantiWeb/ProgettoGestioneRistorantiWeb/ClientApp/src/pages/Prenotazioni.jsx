import { useEffect, useState } from "react";
import Sidebar from "../components/Sidebar";
import ElencoPrenotazioni from "../components/prenotazioni/ElencoPrenotazioni";
import FiltriPrenotazioni from "../components/prenotazioni/FiltriPrenotazioni";
import NuovaPrenotazione from "../components/prenotazioni/NuovaPrenotazione";
import PanoramicaTavoli from "../components/prenotazioni/PanoramicaTavoli";
import RiepilogoPrenotazioni from "../components/prenotazioni/RiepilogoPrenotazioni";
import SelettoreRistorante from "../components/prenotazioni/SelettoreRistorante";

function dataLocaleInput() {
    const data = new Date();
    const anno = data.getFullYear();
    const mese = String(data.getMonth() + 1).padStart(2, "0");
    const giorno = String(data.getDate()).padStart(2, "0");
    return `${anno}-${mese}-${giorno}`;
}

export default function Prenotazioni() {
    const [ristoranti, setRistoranti] = useState([]);
    const [ristoranteId, setRistoranteId] = useState(null);
    const [prenotazioni, setPrenotazioni] = useState([]);
    const [dataPrenotazione, setDataPrenotazione] = useState(dataLocaleInput());
    const [ricerca, setRicerca] = useState("");
    const [errore, setErrore] = useState("");

    useEffect(() => {
        async function caricaRistoranti() {
            try {
                const response = await fetch("/api/ristoranti/miei", {
                    credentials: "include"
                });

                if (!response.ok) {
                    throw new Error("Impossibile caricare i ristoranti");
                }

                const dati = await response.json();
                setRistoranti(dati);
                setRistoranteId(dati[0]?.id ?? null);           //seleziona il primo di default
            } catch (error) {
                setErrore(error.message);
            }
        }

        caricaRistoranti();
    }, []);                                     //[] significa "Esegui questo effetto solo una volta, quando il componente viene montato."

    useEffect(() => {
        if (!ristoranteId) {
            setPrenotazioni([]);
            return;
        }

        async function caricaPrenotazioni() {
            try {
                const response = await fetch(
                    `/api/prenotazioni/ristorante/${ristoranteId}`,
                    { credentials: "include" }
                );

                if (!response.ok) {
                    throw new Error("Impossibile caricare le prenotazioni");
                }

                setPrenotazioni(await response.json());
            } catch (error) {
                setErrore(error.message);
            }
        }

        caricaPrenotazioni();   
    }, [ristoranteId]);                                           //"Ogni volta che cambia il ristorante selezionato, ricarica le prenotazioni."

    const prenotazioniFiltrate = prenotazioni.filter((prenotazione) =>
        (prenotazione.nomeCliente || prenotazione.nomeUtente)
            .toLowerCase()
            .includes(ricerca.trim().toLowerCase())
    );
    const ristoranteSelezionato = ristoranti.find(
        (ristorante) => ristorante.id === ristoranteId
    );

    return (
        <div className="home-container">
            <Sidebar />

            <main className="bookings-main">
                <header className="bookings-header">
                    <h1>Prenotazioni</h1>
                    <p>Gestisci tutte le prenotazioni dei tuoi ristoranti</p>
                </header>

                {errore && <p className="bookings-error">{errore}</p>}

                <SelettoreRistorante
                    ristoranti={ristoranti}
                    ristoranteId={ristoranteId}
                    onSeleziona={setRistoranteId}                                        /*permettere al figlio di comunicare quale ristorante è stato selezionato.*/
                />

                <FiltriPrenotazioni ricerca={ricerca} onRicerca={setRicerca} />
                <RiepilogoPrenotazioni prenotazioni={prenotazioni} />

                <div className="bookings-content">
                    <ElencoPrenotazioni prenotazioni={prenotazioniFiltrate} />

                    <div className="bookings-side">
                        <PanoramicaTavoli
                            numeroPosti={ristoranteSelezionato?.numeroPosti ?? 0}
                            prenotazioni={prenotazioni}
                            data={dataPrenotazione}
                        />
                        <NuovaPrenotazione
                            ristoranteId={ristoranteId}
                            data={dataPrenotazione}
                            onDataChange={setDataPrenotazione}
                            onCreata={(prenotazione) =>
                                setPrenotazioni((correnti) => [...correnti, prenotazione])
                            }
                        />
                    </div>
                </div>
            </main>
        </div>
    );
}
