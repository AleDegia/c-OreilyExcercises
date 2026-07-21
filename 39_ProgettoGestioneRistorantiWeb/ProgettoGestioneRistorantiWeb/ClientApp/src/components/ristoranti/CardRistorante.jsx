import { ChevronRight, Euro, MapPin, MoreVertical, Phone, Users } from "lucide-react";
import { useEffect, useRef, useState } from "react";
import MenuAzioniRistorante from "./MenuAzioniRistorante";

function CardRistorante({ ristorante, refreshRistoranti }) {
  const attivo = ristorante.attivo !== false;
  const [menuAperto, setMenuAperto] = useState(false);
  const menuRef = useRef(null);                                                         //riferimento a un div

  useEffect(() => {
    function chiudiMenuAlClickEsterno(event) {
      if (menuRef.current && !menuRef.current.contains(event.target)) {                 //event.target è l'elemento su cui clicco (verifica se ho cliccato fuori dal div)
        setMenuAperto(false);
      }
    }

    document.addEventListener("mousedown", chiudiMenuAlClickEsterno);                   //Aggiungo un ascoltatore di eventi all' intera pagina html.

    return () => {
      document.removeEventListener("mousedown", chiudiMenuAlClickEsterno);
    };
  }, []);

  return (
    <article className="restaurant-card">
      {ristorante.immagine ? (
        <img
          className="restaurant-card_image"
          src={`data:image/jpeg;base64,${ristorante.immagine}`}
          alt={ristorante.ragioneSociale}
        />
      ) : (
        <div className="restaurant-card_image restaurant-card_image--empty">
          Nessuna foto
        </div>
      )}

      <div className="restaurant-card_identity">
        <div className="restaurant-card_heading">
          <h2>{ristorante.ragioneSociale}</h2>
          <span className={`status-badge status-badge--${attivo ? "active" : "inactive"}`}>
            {attivo ? "Attivo" : "Inattivo"}
          </span>
        </div>

        <span className="restaurant-type">
          Tipologia {ristorante.tipologiaId}
        </span>
      </div>

      <div className="restaurant-card_details">
        <span><MapPin size={16} /> {ristorante.indirizzo}, {ristorante.citta || "Città non indicata"}</span>
        <span><Phone size={16} /> {ristorante.telefono || "Telefono non indicato"}</span>
      </div>

      <div className="restaurant-card_numbers">
        <span><Users size={16} /> {ristorante.numeroPosti} posti</span>
        <span><Euro size={16} /> {ristorante.prezzoMedio}</span>
        <small>Prezzo medio</small>
      </div>

      <div className="restaurant-card_actions" ref={menuRef}>           
        <button type="button" className="restaurant-card_details-button">
          Vedi dettagli <ChevronRight size={16} />
        </button>
        <button
          type="button"
          className="restaurant-card_more"
          aria-label="Altre azioni"
          aria-expanded={menuAperto}
          onClick={() => setMenuAperto((aperto) => !aperto)}            //aperto rappresenta il corrente stato di menuAperto
        >   
          <MoreVertical size={18} />
        </button>

        {menuAperto && (
            <MenuAzioniRistorante
                onChiudi={() => setMenuAperto(false)} ristorante={ristorante} refreshRistoranti={refreshRistoranti}
            />
        )}
      </div>
    </article>
  );
}

export default CardRistorante;
