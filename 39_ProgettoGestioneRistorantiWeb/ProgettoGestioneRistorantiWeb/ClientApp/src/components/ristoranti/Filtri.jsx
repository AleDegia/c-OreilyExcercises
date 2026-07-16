import {
  Store,
  CircleCheck,
  CirclePause,
  MapPin,
} from "lucide-react";
import BarraRicerca from "./BarraRicerca";

function Filtri() {
    return (
        <section className="filtri-ristoranti">
            <div className="itemFiltroRist">
                <BarraRicerca/>
            </div>
            <div className="itemFiltroRist">2</div>
            <div className="itemFiltroRist">3</div>
            <div className="itemFiltroRist">4</div>
            <div className="itemFiltroRist">5</div>
        </section>
    );
}

export default Filtri;