import { CalendarCheck, CalendarDays, Clock3, UserRoundX } from "lucide-react";

export default function RiepilogoPrenotazioni({ prenotazioni }) {
    const totalePersone = prenotazioni.reduce(
        (totale, prenotazione) => totale + prenotazione.numeroPersone,
        0
    );

    const dati = [
        { label: "Prenotazioni", value: prenotazioni.length, icon: CalendarCheck, color: "blue" },
        { label: "Coperti previsti", value: totalePersone, icon: CalendarDays, color: "violet" },
        { label: "Questa settimana", value: prenotazioni.length, icon: CalendarCheck, color: "green" },
        { label: "In attesa", value: 0, icon: Clock3, color: "orange" },
        { label: "No-show", value: 0, icon: UserRoundX, color: "red" }
    ];

    return (
        <section className="booking-summary">
            {dati.map(({ label, value, icon: Icon, color }) => (
                <article key={label}>
                    <span className={`booking-summary-icon ${color}`}><Icon size={18} /></span>
                    <div>
                        <strong>{value}</strong>
                        <small>{label}</small>
                    </div>
                </article>
            ))}
        </section>
    );
}
