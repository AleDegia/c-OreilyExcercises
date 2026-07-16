import { Search } from "lucide-react";

function BarraRicerca() {
    return (
        <div className="search-ristorante">
            <Search className="search-icon" size={18} />

            <input 
                type="search"
                placeholder="Cerca ristorante..."
                aria-label="Cerca ristorante"
            />
        </div>
    );
}

export default BarraRicerca;