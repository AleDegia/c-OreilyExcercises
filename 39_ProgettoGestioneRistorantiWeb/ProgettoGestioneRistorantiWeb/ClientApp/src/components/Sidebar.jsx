import { useState, useEffect } from "react";

export default function Sidebar() {    
    const [activeItem, setActiveItem] = useState("Dashboard");
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

        return (
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
        )
}