

function StatsGrid({ stats }) {
    return (
        <section className="stats-grid-ristoranti" aria-label="Riepilogo">
            {stats.map((stat) => (
                <article className="stat-card-ristoranti" key={stat.label}>
                    <div className={`stat-icon ${stat.color}`}>
                        {stat.icon}
                    </div>
                    <div>
                        <span>{stat.label}</span>
                        <p><strong>{stat.value}</strong></p>
                    </div>
                </article>
            ))}
        </section>
    );
}

export default StatsGrid;