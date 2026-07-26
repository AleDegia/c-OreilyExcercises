import { ChevronLeft, ChevronRight, Search } from "lucide-react";
import { useState } from "react";

function formattaDataInput(data) {
    const anno = data.getFullYear();
    const mese = String(data.getMonth() + 1).padStart(2, "0");
    const giorno = String(data.getDate()).padStart(2, "0");
    return `${anno}-${mese}-${giorno}`;
}

export default function FiltriPrenotazioni({ ricerca, onRicerca }) {
    const oggi = formattaDataInput(new Date());
    const [dataSelezionata, setDataSelezionata] = useState(oggi);

    function cambiaGiorno(numeroGiorni) {
        const data = new Date(`${dataSelezionata || oggi}T12:00:00`);
        data.setDate(data.getDate() + numeroGiorni);
        setDataSelezionata(formattaDataInput(data));
    }

    return (
        <section className="booking-section">
            <h2>2. Filtri e periodo</h2>

            <div className="booking-filters">
                <div className="booking-date-picker">
                    <button
                        type="button"
                        aria-label="Giorno precedente"
                        onClick={() => cambiaGiorno(-1)}
                    >
                        <ChevronLeft size={17} />
                    </button>

                    <input
                        type="date"
                        value={dataSelezionata}
                        onChange={(event) => setDataSelezionata(event.target.value)}
                        aria-label="Data delle prenotazioni"
                    />

                    <button
                        type="button"
                        aria-label="Giorno successivo"
                        onClick={() => cambiaGiorno(1)}
                    >
                        <ChevronRight size={17} />
                    </button>
                </div>

                <label className="booking-search">
                    <Search size={17} />
                    <input
                        type="search"
                        value={ricerca}
                        onChange={(event) => onRicerca(event.target.value)}
                        placeholder="Cerca prenotazione, cliente..."
                    />
                </label>
            </div>
        </section>
    );
}
