const tavoli = [
    { nome: "T1", posti: 2, stato: "free" },
    { nome: "T2", posti: 2, stato: "busy" },
    { nome: "T3", posti: 4, stato: "busy" },
    { nome: "T4", posti: 4, stato: "free" },
    { nome: "T5", posti: 4, stato: "busy" },
    { nome: "T6", posti: 4, stato: "busy" },
    { nome: "T7", posti: 2, stato: "waiting" },
    { nome: "T8", posti: 6, stato: "busy" },
    { nome: "T9", posti: 2, stato: "free" },
    { nome: "T10", posti: 4, stato: "disabled" },
    { nome: "T11", posti: 2, stato: "free" },
    { nome: "T12", posti: 6, stato: "disabled" }
];

export default function PanoramicaTavoli() {
    return (
        <aside className="booking-tables-panel">
            <div className="booking-panel-title">
                <h2>Panoramica tavoli</h2>
                <strong>44 posti totali</strong>
            </div>

            <div className="booking-table-stats">
                <span><strong>12</strong><small>Tavoli</small></span>
                <span><strong>44</strong><small>Posti totali</small></span>
                <span><strong>28</strong><small>Occupati</small></span>
                <span><strong>63%</strong><small>Occupazione</small></span>
            </div>

            <div className="booking-room-tabs">
                <button type="button" className="active">Interno</button>
                <button type="button">Terrazza</button>
                <button type="button">Privé</button>
            </div>

            <div className="booking-tables-grid">
                {tavoli.map((tavolo) => (
                    <button type="button" className={tavolo.stato} key={tavolo.nome}>
                        <strong>{tavolo.nome}</strong>
                        <small>{tavolo.posti} posti</small>
                    </button>
                ))}
            </div>
        </aside>
    );
}
