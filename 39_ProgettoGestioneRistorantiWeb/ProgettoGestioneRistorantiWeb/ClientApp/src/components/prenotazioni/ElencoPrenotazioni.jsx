import { MoreHorizontal, Users } from "lucide-react";

function formattaData(data) {
    return new Intl.DateTimeFormat("it-IT", {
        day: "2-digit",
        month: "2-digit",
        year: "numeric",
        hour: "2-digit",
        minute: "2-digit"
    }).format(new Date(data));
}

export default function ElencoPrenotazioni({ prenotazioni }) {
    return (
        <section className="booking-list-section">
            <h2>3. Elenco prenotazioni</h2>

            <div className="booking-table">
                <div className="booking-table-head">
                    <span>Prenotazione</span>
                    <span>Cliente</span>
                    <span>Coperti</span>
                    <span>Tavolo</span>
                    <span>Stato</span>
                    <span>Azioni</span>
                </div>

                {prenotazioni.length === 0 && (
                    <p className="booking-empty">Nessuna prenotazione trovata.</p>
                )}

                {prenotazioni.map((prenotazione) => (
                    <article className="booking-table-row" key={prenotazione.id}>
                        <div>
                            <strong>#{prenotazione.id}</strong>
                            <small>{formattaData(prenotazione.dataPrenotazione)}</small>
                        </div>
                        <div>
                            <strong>{prenotazione.nomeCliente || prenotazione.nomeUtente}</strong>
                            <small>Cliente</small>
                        </div>
                        <span className="booking-guests"><Users size={15} /> {prenotazione.numeroPersone}</span>
                        <span>Da assegnare</span>
                        <span className="booking-status">Confermata</span>
                        <button type="button" className="booking-row-action" aria-label="Azioni prenotazione">
                            <MoreHorizontal size={17} />
                        </button>
                    </article>
                ))}
            </div>
        </section>
    );
}
