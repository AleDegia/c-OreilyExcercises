import { useState } from "react";

export default function NuovaPrenotazione({
    ristoranteId,
    data,
    onDataChange,
    onCreata
}) {
    const [orario, setOrario] = useState("13:00");
    const [numeroPersone, setNumeroPersone] = useState(2);
    const [nomeCliente, setNomeCliente] = useState("");
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [message, setMessage] = useState("");
    const [invio, setInvio] = useState(false);

    function apriModale() {
        setMessage("");

        if (!ristoranteId) {
            setMessage("Seleziona prima un ristorante");
            return;
        }

        const oggi = new Date();
        const dataSelezionata = new Date(`${data}T${orario}:00`);
        if (dataSelezionata < oggi) {
        setMessage("Non è possibile prenotare per una data passata");
        return;
        }

        setIsModalOpen(true);
    }

    async function handleSubmit(event) {
        event.preventDefault();
        setMessage("");
        setInvio(true);
        
        try {
            const response = await fetch("/api/prenotazioni", {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    ristoranteId,
                    nomeCliente,
                    dataPrenotazione: `${data}T${orario}:00`,
                    numeroPersone: Number(numeroPersone)
                })
            });

            if (!response.ok) {
                const dettaglio = await response.text();
                console.error(dettaglio);
                setMessage("Errore durante la registrazione della prenotazione");
                return;
            }

            const prenotazioneCreata = await response.json();
            onCreata(prenotazioneCreata);
            setMessage("Prenotazione registrata correttamente");
            setNomeCliente("");
        } catch (error) {
            console.error(error);
            setMessage("Server non raggiungibile");
        } finally {
            setInvio(false);
        }
    }

    return (
        <>
            <aside className="booking-new-panel">
                <h2>Nuova prenotazione</h2>

                <label>
                    Data
                    <input
                        type="date"
                        value={data}
                        onChange={(event) => onDataChange(event.target.value)}
                    />
                </label>

                <fieldset>
                    <legend>Orario</legend>
                    <div className="booking-times">
                        {["12:00", "12:30", "13:00", "13:30", "14:00"].map((ora) => (
                            <button
                                type="button"
                                className={ora === orario ? "active" : ""}
                                key={ora}
                                onClick={() => setOrario(ora)}
                            >
                                {ora}
                            </button>
                        ))}
                    </div>
                </fieldset>

                <label>
                    Coperti
                    <input
                        type="number"
                        min="1"
                        value={numeroPersone}
                        onChange={(event) => setNumeroPersone(event.target.value)}
                    />
                </label>

                {message && !isModalOpen && <p className="booking-form-message">{message}</p>}

                <button type="button" className="booking-continue" onClick={apriModale}>
                    Continua →
                </button>
            </aside>

            {isModalOpen && (
                <div className="modal-overlay" onMouseDown={() => setIsModalOpen(false)}>
                    <div
                        className="modal-content booking-modal"
                        role="dialog"
                        aria-modal="true"
                        aria-labelledby="booking-modal-title"
                        onMouseDown={(event) => event.stopPropagation()}
                    >
                        <button
                            type="button"
                            className="modal-close booking-modal-close"
                            aria-label="Chiudi"
                            onClick={() => setIsModalOpen(false)}
                        >
                            ×
                        </button>

                        <h2 id="booking-modal-title">Conferma prenotazione</h2>
                        <p className="booking-modal-subtitle">
                            Inserisci il nome del cliente e controlla i dati selezionati.
                        </p>

                        <div className="booking-modal-summary">
                            <span><small>Data</small><strong>{data}</strong></span>
                            <span><small>Orario</small><strong>{orario}</strong></span>
                            <span><small>Coperti</small><strong>{numeroPersone}</strong></span>
                        </div>

                        <form className="booking-modal-form" onSubmit={handleSubmit}>
                            <label className="form-group">
                                Nome cliente
                                <input
                                    type="text"
                                    value={nomeCliente}
                                    onChange={(event) => setNomeCliente(event.target.value)}
                                    placeholder="Es. Mario Rossi"
                                    required
                                />
                            </label>

                            {message && (
                                <p className={`booking-form-message ${message.includes("correttamente") ? "success" : "error"}`}>
                                    {message}
                                </p>
                            )}

                            <div className="booking-modal-actions">
                                <button
                                    type="button"
                                    className="booking-modal-cancel"
                                    onClick={() => setIsModalOpen(false)}
                                >
                                    Annulla
                                </button>

                                <button type="submit" className="booking-modal-confirm" disabled={invio}>
                                    {invio ? "Registrazione..." : "Conferma prenotazione"}
                                </button>
                            </div>
                        </form>
                    </div>
                </div>
            )}
        </>
    );
}
