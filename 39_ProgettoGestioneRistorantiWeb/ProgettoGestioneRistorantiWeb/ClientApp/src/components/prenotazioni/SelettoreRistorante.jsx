import { Check, Grid2X2, Users } from "lucide-react";

export default function SelettoreRistorante({
    ristoranti,
    ristoranteId,
    onSeleziona
}) {
    return (
        <section className="booking-section">
            <h2>1. Scegli il ristorante</h2>

            <div className="booking-restaurants">
                {ristoranti.slice(0, 5).map((ristorante) => {
                    const selezionato = ristorante.id === ristoranteId;

                    return (
                        <button
                            type="button"
                            key={ristorante.id}
                            className={`booking-restaurant-card ${selezionato ? "selected" : ""}`}
                            onClick={() => onSeleziona(ristorante.id)}
                        >
                            {ristorante.immagine ? (
                                <img
                                    src={`data:image/jpeg;base64,${ristorante.immagine}`}
                                    alt={ristorante.ragioneSociale}
                                />
                            ) : (
                                <span className="booking-restaurant-placeholder">R</span>
                            )}

                            <span className="booking-restaurant-info">
                                <strong>{ristorante.ragioneSociale}</strong>
                                <small>{ristorante.indirizzo}</small>
                                <small><Users size={13} /> {ristorante.numeroPosti} posti</small>
                            </span>

                            {selezionato && <Check className="booking-selected-icon" size={16} />}
                        </button>
                    );
                })}

                <button type="button" className="booking-show-all">
                    <Grid2X2 size={22} />
                    <strong>Vedi tutti</strong>
                </button>
            </div>
        </section>
    );
}
