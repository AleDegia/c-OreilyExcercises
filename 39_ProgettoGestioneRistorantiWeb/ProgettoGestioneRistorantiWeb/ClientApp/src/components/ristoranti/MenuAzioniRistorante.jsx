import { useState } from "react";

function MenuAzioniRistorante({ onChiudi, ristorante, refreshRistoranti }) {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [message, setMessage] = useState(""); 

    const [form, setForm] = useState({
        ragioneSociale: ristorante.ragioneSociale,
        partitaIva: ristorante.partitaIva,
        indirizzo: ristorante.indirizzo,
        tipologiaId: ristorante.tipologiaId,
        numeroPosti: ristorante.numeroPosti,
        prezzoMedio: ristorante.prezzoMedio
    });
  
  async function eliminaRistorante() {
    try {
        const response = await fetch(
            `/api/ristoranti/${ristorante.id}`,
            {
                method: "DELETE",
                credentials: "include",
            }
        );

        if (!response.ok) {
            throw new Error("Errore durante l'eliminazione del ristorante");
        }

        onChiudi();
        await refreshRistoranti();
    } catch (error) {
        console.error(error);
    }
  }

   async function modificaRistorante() {
    setIsModalOpen(true);
    
   }

   async function handleSubmit(event)
   {
     event.preventDefault();
     try {
        const response = await fetch(
            `/api/ristoranti/${ristorante.id}`,
            {
                method: "PUT",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(
                    {...form, 
                     id:ristorante.id}          //qua lo passo solo perchè sennò non 
                )
            }
        );

        if (!response.ok) {
            throw new Error("Errore durante la modifica del ristorante");
        }

        onChiudi();
        refreshRistoranti();
    } catch (error) {
        console.error(error);
    }
   }

   const handleChange = (e) => {
        const { name, value } = e.target;               {/*e.target è l'elemento html che genera l'evento, name è nome label e valore assegnato*/}

        setForm((prevForm) => ({
            ...prevForm,
            [name]: value
        }));
    };

  return (
    <>
    <div
      className="restaurant-card_menu"
      /*onMouseLeave={onChiudi}*/
    >
      <button type="button" onClick={modificaRistorante}>
        Modifica
      </button>

      <button
        type="button"
        className="restaurant-card_delete"
        onClick={eliminaRistorante}
        onMouseLeave={onChiudi}
      >
        Elimina
      </button>
    </div>
  


{/*frontend modale*/}
{isModalOpen && (
    <div
        className="modal-overlay"
        onClick={() => setIsModalOpen(false)}
    >
        <div
            className="modal-content"
            onClick={(event) => event.stopPropagation()}
        >
            <button
                type="button"
                className="modal-close"
                onClick={() => setIsModalOpen(false)}
                aria-label="Chiudi modale"
            >
                ×
            </button>

            <h2>Modifica ristorante</h2>

            <form onSubmit={handleSubmit}>
                {/* campi del form */}
                <div className="form-group">
                    <label htmlFor="ragioneSociale">
                        Ragione sociale
                    </label>
                    <input
                        type="text"
                        id="ragioneSociale"
                        name="ragioneSociale"
                        value={form.ragioneSociale}
                        onChange={(e) =>
                            setForm({
                                ...form,
                                ragioneSociale: e.target.value
                            })
                        }
                        placeholder="Es. Osteria Centro"
                        required
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="partitaIva">
                        Partita IVA
                    </label>
                    <input
                        type="text"
                        id="partitaIva"
                        name="partitaIva"
                        value={form.partitaIva}
                        onChange={handleChange}
                        placeholder="Es. 12345678901"
                        required
                    />
                </div>

                <div className="form-group form-group-full">
                    <label htmlFor="indirizzo">
                        Indirizzo
                    </label>
                    <input
                        type="text"
                        id="indirizzo"
                        name="indirizzo"
                        value={form.indirizzo}
                        onChange={handleChange}
                        placeholder="Es. Via Roma 10, Milano"
                        required
                    />
                </div>

                <div className="form-group">
                    <label htmlFor="tipologiaId">
                        Tipologia
                    </label>
                    <select
                        id="tipologiaId"
                        name="tipologiaId"
                        value={form.tipologiaId}
                        onChange={handleChange}
                        required
                    >
                        <option value="">Seleziona una tipologia</option>
                        <option value="1">Italiano</option>
                        <option value="2">Pizzeria</option>
                        <option value="3">Sushi</option>
                        <option value="4">Fast Food</option>
                    </select>
                </div>

                <div className="form-group">
                    <label htmlFor="numeroPosti">
                        Numero posti
                    </label>
                    <input
                        type="number"
                        id="numeroPosti"
                        name="numeroPosti"
                        value={form.numeroPosti}
                        onChange={handleChange}
                        min="1"
                        placeholder="Es. 50"
                        required
                    />
                </div>

                <div className="form-group">
                    <label htmlFor="prezzoMedio">
                        Prezzo medio 
                    </label>
                    <input
                        type="number"
                        id="prezzoMedio"
                        name="prezzoMedio"
                        value={form.prezzoMedio}
                        onChange={handleChange}
                        min="0"
                        step="0.01"
                        placeholder="Es. 35"
                    />
                </div>

                <div className="form-group">
                    <label htmlFor="immagine">
                        Immagine 
                    </label>
                    <input
                        type="file"
                        accept="image/png, image/jpeg"
                        id="immagine"
                        name="immagine"
                        /*onChange={handleImageChange}*/
                    />
                </div>

                <div>
                    <button type="submit">Invio</button>
                    {  message &&
                    <p>{message}</p>
                    }
                </div>
            </form>
        </div>
    </div>
    
)}
</>
);

}
export default MenuAzioniRistorante;