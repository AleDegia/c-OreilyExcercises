using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prenotazioni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RistoranteId = table.Column<int>(type: "int", nullable: false),
                    NomeUtente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataRichiesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrenotazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroPersone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazioni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ristoranti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipologiaId = table.Column<int>(type: "int", nullable: false),
                    RagioneSociale = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PartitaIva = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroPosti = table.Column<int>(type: "int", nullable: false),
                    PrezzoMedio = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ristoranti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipologie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipologie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsAdministrator = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.UserName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prenotazioni");

            migrationBuilder.DropTable(
                name: "Ristoranti");

            migrationBuilder.DropTable(
                name: "Tipologie");

            migrationBuilder.DropTable(
                name: "Utenti");
        }
    }
}
