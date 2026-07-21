import { Search } from "lucide-react";

//passo la funzione setRicerca per prendere i valori che digito nella barra di ricerca e portarli a  const [ricerca, setRicerca] = useState("");  del comp. ristoranti
//React memorizza il nuovo valore e programma un nuovo render del componente che possiede quello stato, cioè Ristoranti.
function BarraRicerca({ricerca, setRicerca}) {
    return (
        <div className="search-ristorante">
            <Search className="search-icon" size={18} />

            <input 
                type="search"
                placeholder="Cerca ristorante..."
                aria-label="Cerca ristorante"
                onChange={(e) => setRicerca(e.target.value)}
            />  
        </div>
    );
}

export default BarraRicerca;