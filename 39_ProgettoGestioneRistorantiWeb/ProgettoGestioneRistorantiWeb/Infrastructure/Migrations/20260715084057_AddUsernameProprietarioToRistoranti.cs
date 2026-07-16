using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUsernameProprietarioToRistoranti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsernameProprietario",
                table: "Ristoranti",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ristoranti_UsernameProprietario",
                table: "Ristoranti",
                column: "UsernameProprietario");

            migrationBuilder.AddForeignKey(
                name: "FK_Ristoranti_Utenti_UsernameProprietario",
                table: "Ristoranti",
                column: "UsernameProprietario",
                principalTable: "Utenti",
                principalColumn: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ristoranti_Utenti_UsernameProprietario",
                table: "Ristoranti");

            migrationBuilder.DropIndex(
                name: "IX_Ristoranti_UsernameProprietario",
                table: "Ristoranti");

            migrationBuilder.DropColumn(
                name: "UsernameProprietario",
                table: "Ristoranti");
        }
    }
}
