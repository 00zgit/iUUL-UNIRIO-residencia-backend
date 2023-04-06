using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace scb_externo.Migrations
{
    /// <inheritdoc />
    public partial class Integracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartoesDeCredito");

            migrationBuilder.DropColumn(
                name: "TipoStatus",
                table: "Cobrancas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoStatus",
                table: "Cobrancas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CartoesDeCredito",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cvv = table.Column<string>(type: "text", nullable: false),
                    IdCiclista = table.Column<int>(type: "integer", nullable: false),
                    NomeTitular = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    Validade = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartoesDeCredito", x => x.Id);
                });
        }
    }
}
