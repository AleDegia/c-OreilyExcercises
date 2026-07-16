import { useState, useEffect } from "react";
import HomeHeader from "../components/Homepage/HomeHeader";
import StatsGrid from "../components/Homepage/StatsGrid";
import SituazioneRisoranti from "../components/Homepage/SituazioneRistoranti"

export default function HomePage() {
    const [activeItem, setActiveItem] = useState("Dashboard");
    const [bookingRange, setBookingRange] = useState("7g");

    const menuItems = [
        { label: "Dashboard", icon: "home", badge: null },
        { label: "Ristoranti", icon: "restaurant", badge: null },
        { label: "Prenotazioni", icon: "calendar", badge: "8" },
        { label: "Clienti", icon: "users", badge: null },
        { label: "Tipologie", icon: "tag", badge: null }
    ];

    const adminItems = [
        { label: "Utenti", icon: "users" },
        { label: "Impostazioni", icon: "settings" }
    ];

    const stats = [
        { label: "Ristoranti", value: "12", trend: "+2 questo mese" },
        { label: "Prenotazioni", value: "48", trend: "8 oggi" },
        { label: "Clienti", value: "326", trend: "+18%" },
        { label: "Tipologie", value: "7", trend: "Catalogo attivo" }
    ];

    const bookingTrendData = {
        "1g": [
            { label: "10", value: 2 },
            { label: "12:00", value: 3 },
            { label: "14:00", value: 5 },
            { label: "16:00", value: 4 },
            { label: "18:00", value: 9 },
            { label: "20:00", value: 14 },
            { label: "22:00", value: 11 }
        ],
        "7g": [
            { label: "Lun", value: 18 },
            { label: "Mar", value: 24 },
            { label: "Mer", value: 20 },
            { label: "Gio", value: 31 },
            { label: "Ven", value: 38 },
            { label: "Sab", value: 46 },
            { label: "Dom", value: 34 }
        ],
        "30g": [
            { label: "1-4", value: 82 },
            { label: "5-8", value: 96 },
            { label: "9-12", value: 118 },
            { label: "13-16", value: 134 },
            { label: "17-20", value: 121 },
            { label: "21-24", value: 146 },
            { label: "25-30", value: 128 }
        ]
    };

    const trendData = bookingTrendData[bookingRange];
    const maxTrendValue = Math.max(...trendData.map((item) => item.value));
    const totalBookings = trendData.reduce((total, item) => total + item.value, 0);

    const orders = [
        { table: "Tavolo 5", detail: "2 x Margherita, 1 x Carbonara", minutes: "10 min" },
        { table: "Tavolo 8", detail: "1 x Tagliata, 2 x Vino Rosso", minutes: "15 min" },
        { table: "Tavolo 12", detail: "2 x Risotto ai Funghi", minutes: "18 min" },
        { table: "Tavolo 3", detail: "1 x Pizza Diavola, 1 x Birra", minutes: "8 min" }
    ];

    const [restaurantSummaries, setRestaurantSummaries] = useState([]);
    /*const restaurantSummaries = [
        { name: "La Terrazza", address: "Centro, Via Roma 15", bookings: 18, clients: 124, occupancy: 80 },
        { name: "Sapore Vivo", address: "Lungomare, Via Marina 8", bookings: 12, clients: 87, occupancy: 65 },
        { name: "Osteria Centro", address: "Centro, Via Verdi 23", bookings: 9, clients: 65, occupancy: 60 },
        { name: "Bistrot del Mare", address: "Porto, Via Porto 3", bookings: 5, clients: 50, occupancy: 45 }
    ];*/

    useEffect(() => {

        async function getRistoranti() {
            try {
                const response = await fetch(
                    "/api/ristoranti/miei",
                    {
                        credentials: "include"
                    }
                );

                if (!response.ok) {
                    throw new Error("Errore nel caricamento dei ristoranti");
                }

                const data = await response.json();

                console.log(data);

                setRestaurantSummaries(data);
            }
            catch (error) {
                console.error(error);
            }
        }
        getRistoranti();
    }, []);
  

    function SidebarIcon({ name }) {
        const commonProps = {       //props comuni a tutti gli svg per dare stessa dimensione e stile
            width: "18",
            height: "18",
            viewBox: "0 0 24 24",
            fill: "none",
            stroke: "currentColor",
            strokeWidth: "2",
            strokeLinecap: "round",
            strokeLinejoin: "round",
            "aria-hidden": "true"
        };

        const icons = {
            home: (
                <svg {...commonProps}>
                    <path d="M3 11.5L12 4l9 7.5" />
                    <path d="M5.5 10.5V20h13v-9.5" />
                    <path d="M9.5 20v-5h5v5" />
                </svg>
            ),
            restaurant: (
                <svg {...commonProps}>
                    <path d="M4 5h16" />
                    <path d="M6 9h12" />
                    <path d="M7 9v10" />
                    <path d="M17 9v10" />
                    <path d="M7 14h10" />
                </svg>
            ),
            calendar: (
                <svg {...commonProps}>
                    <path d="M7 3v4" />
                    <path d="M17 3v4" />
                    <path d="M4 8h16" />
                    <rect x="4" y="5" width="16" height="16" rx="2" />
                </svg>
            ),
            users: (
                <svg {...commonProps}>
                    <path d="M16 21v-2a4 4 0 0 0-4-4H7a4 4 0 0 0-4 4v2" />
                    <circle cx="9.5" cy="7" r="4" />
                    <path d="M22 21v-2a4 4 0 0 0-3-3.87" />
                    <path d="M16 3.13a4 4 0 0 1 0 7.75" />
                </svg>
            ),
            tag: (
                <svg {...commonProps}>
                    <path d="M20.5 13.5l-7 7a2 2 0 0 1-2.8 0l-7.2-7.2V4h9.3l7.7 7.7a2 2 0 0 1 0 2.8z" />
                    <circle cx="8" cy="8" r="1.5" />
                </svg>
            ),
            settings: (
                <svg {...commonProps}>
                    <circle cx="12" cy="12" r="3" />
                    <path d="M19.4 15a1.7 1.7 0 0 0 .34 1.87l.06.06a2 2 0 1 1-2.83 2.83l-.06-.06A1.7 1.7 0 0 0 15 19.4a1.7 1.7 0 0 0-1 .6V20a2 2 0 1 1-4 0v-.1a1.7 1.7 0 0 0-1-.6 1.7 1.7 0 0 0-1.87.34l-.06.06a2 2 0 1 1-2.83-2.83l.06-.06A1.7 1.7 0 0 0 4.6 15a1.7 1.7 0 0 0-.6-1H4a2 2 0 1 1 0-4h.1a1.7 1.7 0 0 0 .6-1 1.7 1.7 0 0 0-.34-1.87l-.06-.06a2 2 0 1 1 2.83-2.83l.06.06A1.7 1.7 0 0 0 9 4.6a1.7 1.7 0 0 0 1-.6V4a2 2 0 1 1 4 0v.1a1.7 1.7 0 0 0 1 .6 1.7 1.7 0 0 0 1.87-.34l.06-.06a2 2 0 1 1 2.83 2.83l-.06.06A1.7 1.7 0 0 0 19.4 9a1.7 1.7 0 0 0 .6 1h.1a2 2 0 1 1 0 4H20a1.7 1.7 0 0 0-.6 1z" />
                </svg>
            )
        };

        return icons[name] ?? null;
    }

    //render di tutta la pagina completa con sidebar, header, statistiche e riepilogo ristoranti
    return (
        <div className="home-container">
            {/* Sidebar navigation */}
            <aside className="sidebar">
                <div className="sidebar-logo">
                    <span className="sidebar-logo-icon">R</span>
                    <div>
                        <strong>RISTO</strong>
                        <small>Gestione Ristorantis</small>
                    </div>
                </div>

                <nav className="sidebar-nav" aria-label="Menu principale">
                    <span className="sidebar-section-title">Menu</span>
                    {menuItems.map((item) => (
                        <a
                            className={activeItem === item.label ? "active" : ""}
                            href="#"
                            key={item.label}
                            onClick={(event) => {
                                event.preventDefault();
                                setActiveItem(item.label);                    //do valore di item.label a activeItem, e React facendo nuovo render poi mi mette className "active" li
                            }}
                        >
                            <span className="sidebar-item-icon"><SidebarIcon name={item.icon} /></span>
                            <span>{item.label}</span>
                            {item.badge && <span className="sidebar-badge">{item.badge}</span>}
                        </a>
                    ))}
                </nav>

                <nav className="sidebar-nav sidebar-admin" aria-label="Amministrazione">
                    <span className="sidebar-section-title">Amministrazione</span>
                    {adminItems.map((item) => (
                        <a href="#" key={item.label} onClick={(event) => event.preventDefault()}>
                            <span className="sidebar-item-icon"><SidebarIcon name={item.icon} /></span>
                            <span>{item.label}</span>
                        </a>
                    ))}
                </nav>

                <div className="sidebar-footer">
                    <button type="button" className="support-button">
                        <span className="sidebar-item-icon">?</span>
                        Supporto
                    </button>

                    <button type="button" className="logout-button">Logout</button>
                </div>
            </aside>
            
            {/* Main content area */}
            <main className="home-page">
                <HomeHeader />
                <StatsGrid stats={stats} />

                <section className="restaurant-dashboard">
                    <article className="home-panel booking-trend-panel">
                        <div className="section-heading">
                            <div>
                                <h2>Andamento prenotazioni</h2>
                                <span className="chart-summary">{totalBookings} prenotazioni nel periodo</span>
                            </div>

                            <select
                                className="range-select"
                                value={bookingRange}
                                onChange={(event) => setBookingRange(event.target.value)}
                            >
                                <option value="1g">1g</option>
                                <option value="7g">7g</option>
                                <option value="30g">30g</option>
                            </select>
                        </div>

                        <div className="booking-chart" aria-label="Grafico andamento prenotazioni">
                            {trendData.map((item) => (
                                <div className="booking-chart-column" key={item.label}>
                                    <span>{item.value}</span>
                                    <div>
                                        <b style={{ height: `${Math.max((item.value / maxTrendValue) * 100, 8)}%` }}></b>
                                    </div>
                                    <small>{item.label}</small>
                                </div>
                            ))}
                        </div>
                    </article>

                    {/*SituazioneRistoranti*/}
                    <SituazioneRisoranti restaurantSummaries = {restaurantSummaries}/>

                </section>
            </main>
        </div>
    );
}
