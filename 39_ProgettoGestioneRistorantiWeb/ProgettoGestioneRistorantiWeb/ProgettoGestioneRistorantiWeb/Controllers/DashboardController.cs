using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProgettoGestioneRistorantiWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly GestioneRistorantiDbContext _context;

    public DashboardController(GestioneRistorantiDbContext context)
    {
        _context = context;
    }

    [HttpGet("stats")]
    public async Task<ActionResult<DashboardStatsResponse>> GetStats()
    {
        var username = HttpContext.Session.GetString("UserName");

        if (string.IsNullOrWhiteSpace(username))
        {
            return Unauthorized("Utente non autenticato.");
        }

        var ristorantiUtente = _context.Ristoranti
            .AsNoTracking()
            .Where(ristorante =>
                ristorante.UsernameProprietario == username);

        var prenotazioniUtente = _context.Prenotazioni
            .AsNoTracking()
            .Where(prenotazione =>
                ristorantiUtente.Any(ristorante =>
                    ristorante.Id == prenotazione.RistoranteId));

        var stats = new DashboardStatsResponse
        {
            Ristoranti = await ristorantiUtente.CountAsync(),

            Prenotazioni = await prenotazioniUtente.CountAsync(),

            Clienti = await prenotazioniUtente
                .Where(prenotazione =>
                    prenotazione.NomeCliente != "")
                .Select(prenotazione =>
                    prenotazione.NomeCliente)
                .Distinct()
                .CountAsync(),

            Tipologie = await ristorantiUtente
                .Select(ristorante =>
                    ristorante.TipologiaId)
                .Distinct()
                .CountAsync()
        };

        return Ok(stats);
    }
}

public class DashboardStatsResponse
{
    public int Ristoranti { get; set; }

    public int Prenotazioni { get; set; }

    public int Clienti { get; set; }

    public int Tipologie { get; set; }
}
