import { ArrowUpDown, CircleCheck, MapPin } from "lucide-react";
import BarraRicerca from "./BarraRicerca";
import { useState } from "react";


function Filtri({ricerca, setRicerca, citta, setCitta, ordinamento, setOrdinamento}) {
    //const [ricerca, setRicerca] = useState("");
    //const [citta, setCitta] = useState("");
    const [stato, setStato] = useState("");

    return (
        <section className="filtri-ristoranti">
            <div className="itemFiltroRist filtro-ricerca">
                <BarraRicerca ricerca={ricerca} setRicerca={setRicerca}/>
            </div>

            <label className="filtro-select" >
                <MapPin size={16} />
                <select defaultValue="" onChange={(e) => {setCitta(e.target.value)}}>
                    <option value="">Tutte le città</option>
                    <option value="Roma">Roma</option>
                    <option value="Milano">Milano</option>
                    <option value="Rimini">Rimini</option>
                    <option value="Bologna">Bologna</option>
                </select>
            </label>

            <label className="filtro-select">
                <CircleCheck size={16} />
                <select defaultValue="">
                    <option value="">Tutti gli stati</option>
                    <option value="attivi">Attivi</option>
                    <option value="inattivi">Inattivi</option>
                </select>
            </label>

            <label className="filtro-select">
                <ArrowUpDown size={16} />
                <select defaultValue="az" onChange={(e) => setOrdinamento(e.target.value)}>
                    <option value="az">Ordina: A-Z</option>
                    <option value="za">Ordina: Z-A</option>
                    <option value="prezzo-crescente">Prezzo crescente</option>
                    <option value="prezzo-decrescente">Prezzo decrescente</option>
                </select>
            </label>
        </section>
    );
}

export default Filtri;
