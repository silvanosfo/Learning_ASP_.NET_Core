using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P3CoreSilvano.Migrations
{
    public partial class primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TFuncionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFunc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFuncionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TReuniaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TReuniaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TReuniaos_TClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TReuniaos_TFuncionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TFuncionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TReuniaos_ClienteId",
                table: "TReuniaos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TReuniaos_FuncionarioId",
                table: "TReuniaos",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TReuniaos");

            migrationBuilder.DropTable(
                name: "TClientes");

            migrationBuilder.DropTable(
                name: "TFuncionarios");
        }
    }
}
