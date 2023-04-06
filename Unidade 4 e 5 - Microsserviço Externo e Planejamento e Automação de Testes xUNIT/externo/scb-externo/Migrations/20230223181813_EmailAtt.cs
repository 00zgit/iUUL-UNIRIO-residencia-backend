using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace scb_externo.Migrations
{
    /// <inheritdoc />
    public partial class EmailAtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mensagem",
                table: "Emails",
                newName: "Mensagem");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Emails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Emails",
                newName: "Endereco");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Emails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Assunto",
                table: "Emails",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assunto",
                table: "Emails");

            migrationBuilder.RenameColumn(
                name: "Mensagem",
                table: "Emails",
                newName: "mensagem");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Emails",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Emails",
                newName: "email");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Emails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
