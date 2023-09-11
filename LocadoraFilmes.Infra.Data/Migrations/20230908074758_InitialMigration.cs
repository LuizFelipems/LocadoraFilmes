using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocadoraFilmes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CpfCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeneroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filme_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocacaoFilme",
                columns: table => new
                {
                    LocacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoFilme", x => new { x.LocacaoId, x.FilmeId });
                    table.ForeignKey(
                        name: "FK_LocacaoFilme_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocacaoFilme_Locacao_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "Locacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "Id", "Ativo", "DataCriacao", "Nome" },
                values: new object[,]
                {
                    { new Guid("4e378b57-3f46-4552-8442-4dc4ff06bfb2"), true, new DateTime(2023, 9, 8, 4, 47, 58, 395, DateTimeKind.Local).AddTicks(5977), "Aventura" },
                    { new Guid("64437865-abc3-4566-a7c0-a6d8a38fdf1d"), true, new DateTime(2023, 9, 8, 4, 47, 58, 395, DateTimeKind.Local).AddTicks(5984), "Terror" },
                    { new Guid("8514a6c6-c958-4dd7-950b-ce058b921225"), true, new DateTime(2023, 9, 8, 4, 47, 58, 395, DateTimeKind.Local).AddTicks(5982), "Comédia" },
                    { new Guid("d9b1e988-7366-41e5-a845-3fef66acf0b2"), true, new DateTime(2023, 9, 8, 4, 47, 58, 395, DateTimeKind.Local).AddTicks(5959), "Ação" },
                    { new Guid("fcb9988e-a87f-42e2-a7ea-f8b37dc4e65a"), true, new DateTime(2023, 9, 8, 4, 47, 58, 395, DateTimeKind.Local).AddTicks(5979), "Drama" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Login", "Nome", "Password", "Role" },
                values: new object[] { new Guid("8eb11624-86a4-4c5c-9490-960e846c6d24"), "root", "Usuário Master", "123", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Filme_GeneroId",
                table: "Filme",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoFilme_FilmeId",
                table: "LocacaoFilme",
                column: "FilmeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocacaoFilme");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Locacao");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
