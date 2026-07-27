import { CheckCircle2, UtensilsCrossed } from "lucide-react";

export default function AuthLayout({ eyebrow, title, subtitle, children, footer }) {
    return (
        <main className="auth-page">
            <section className="auth-showcase" aria-label="Presentazione Risto">
                <div className="auth-brand">
                    <span className="auth-brand-icon">
                        <UtensilsCrossed size={22} aria-hidden="true" />
                    </span>
                    <div>
                        <strong>RISTO</strong>
                        <small>Gestione Ristoranti</small>
                    </div>
                </div>

                <div className="auth-showcase-content">
                    <span className="auth-showcase-kicker">Tutto sotto controllo</span>
                    <h2>Il tuo ristorante, organizzato con semplicità.</h2>
                    <p>
                        Gestisci locali, prenotazioni e attività quotidiane da un unico spazio.
                    </p>

                    <ul className="auth-benefits">
                        <li><CheckCircle2 size={18} /> Una panoramica sempre aggiornata</li>
                        <li><CheckCircle2 size={18} /> Prenotazioni rapide e ordinate</li>
                        <li><CheckCircle2 size={18} /> Tutti i tuoi ristoranti in un solo posto</li>
                    </ul>
                </div>

                <p className="auth-showcase-note">La gestione che lascia più tempo all’ospitalità.</p>
            </section>

            <section className="auth-form-side">
                <div className="auth-mobile-brand">
                    <span className="auth-brand-icon">
                        <UtensilsCrossed size={20} aria-hidden="true" />
                    </span>
                    <strong>RISTO</strong>
                </div>

                <div className="auth-card">
                    <header className="auth-card-header">
                        <span className="auth-eyebrow">{eyebrow}</span>
                        <h1>{title}</h1>
                        <p>{subtitle}</p>
                    </header>

                    {children}
                    <div className="auth-footer">{footer}</div>
                </div>
            </section>
        </main>
    );
}
