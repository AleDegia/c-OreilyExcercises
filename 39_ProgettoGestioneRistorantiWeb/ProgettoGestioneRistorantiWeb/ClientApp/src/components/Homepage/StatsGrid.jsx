function StatsGrid({ stats }) {
    return (
        <section className="stats-grid" aria-label="Riepilogo">
            {stats.map((stat) => (
                <article className="stat-card" key={stat.label}>
                    <span>{stat.label}</span>
                    <strong>{stat.value}</strong>
                    <small>{stat.trend}</small>
                </article>
            ))}
        </section>
    );
}

export default StatsGrid;