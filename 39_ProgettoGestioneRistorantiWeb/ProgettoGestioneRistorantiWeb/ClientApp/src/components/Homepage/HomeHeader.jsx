function HomeHeader() {
    return (
        <header className="home-header">
            <div>
                <p className="home-kicker">Area gestionale</p>
                <h1>Gestione Ristoranti</h1>
                <p className="home-subtitle">
                    Monitora ristoranti, prenotazioni e clienti da un unico pannello operativo.
                </p>
            </div>
            <div className="home-profile" aria-label="Profilo utente">
                <span className="home-avatar">AD</span>
                <div>
                    <strong>Admin</strong>
                    <span>Sessione attiva</span>
                </div>
            </div>
        </header>
    );
}

export default HomeHeader;
