import { useState, useEffect } from "react";
import HomeHeader from "../components/Homepage/HomeHeader";
import StatsGrid from "../components/Homepage/StatsGrid";
import SituazioneRisoranti from "../components/Homepage/SituazioneRistoranti"
import Sidebar from "../components/Sidebar";

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

    const [dashboardStats, setDashboardStats] = useState({
      ristoranti: 0,
      prenotazioni: 0,
      clienti: 0,
      tipologie: 0
  });

  const stats = [
      {
          label: "Ristoranti",
          value: dashboardStats.ristoranti,
          trend: "Totale registrati"
      },
      {
          label: "Prenotazioni",
          value: dashboardStats.prenotazioni,
          trend: "Totale prenotazioni"
      },
      {
          label: "Clienti",
          value: dashboardStats.clienti,
          trend: "Clienti distinti"
      },
      {
          label: "Tipologie",
          value: dashboardStats.tipologie,
          trend: "Tipologie utilizzate"
      }
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

    async function caricaStatistiche() {
        try {
            const response = await fetch(
                "/api/dashboard/stats",
                {
                    credentials: "include"
                }
            );

            if (!response.ok) {
                throw new Error(
                    "Errore durante il caricamento delle statistiche"
                );
            }

            const dati = await response.json();

            setDashboardStats(dati);
        } catch (error) {
            console.error(error);
        }
    }

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
                caricaStatistiche();
            }
            catch (error) {
                console.error(error);
            }
        }
        getRistoranti();
    }, []);
  
  

    //render di tutta la pagina completa con sidebar, header, statistiche e riepilogo ristoranti
    return (
        <div className="home-container">
            
            <Sidebar/>
            
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
