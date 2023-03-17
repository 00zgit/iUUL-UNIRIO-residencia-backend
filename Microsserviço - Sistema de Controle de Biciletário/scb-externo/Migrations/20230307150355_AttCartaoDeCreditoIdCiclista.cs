using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scb_externo.Migrations
{
    /// <inheritdoc />
    public partial class AttCartaoDeCreditoIdCiclista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCiclista",
                table: "CartoesDeCredito",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCiclista",
                table: "CartoesDeCredito");
        }
    }
}
