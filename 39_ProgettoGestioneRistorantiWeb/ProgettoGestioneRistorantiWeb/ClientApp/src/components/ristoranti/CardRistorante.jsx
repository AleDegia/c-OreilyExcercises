function CardRistorante({ ristorante }) {
  return (
    <article className="restaurant-card">
      <img
        className="restaurant-card__image"
        alt={ristorante.name}
      />

      <div className="restaurant-card__identity">
        <div className="restaurant-card__heading">
          <h2>{ristorante.ragioneSociale}</h2>

          <span
            className={`status-badge status-badge--${ristorante.status}`}
          >
            {ristorante.status === "active"
              ? "Attivo"
              : "Inattivo"}
          </span>
        </div>

        <span className="restaurant-type">
        </span>
      </div>
    </article>
  );
}

export default CardRistorante;