using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroJugadores.Migrations
{
    /// <inheritdoc />
    public partial class Cuarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    MovimientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidaId = table.Column<int>(type: "int", nullable: false),
                    JugadorId = table.Column<int>(type: "int", nullable: false),
                    PosicionFila = table.Column<int>(type: "int", nullable: false),
                    PosicionColumna = table.Column<int>(type: "int", nullable: false),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartidasPartidaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.MovimientoId);
                    table.ForeignKey(
                        name: "FK_Movimientos_Jugadores_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimientos_Partidas_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partidas",
                        principalColumn: "PartidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimientos_Partidas_PartidasPartidaId",
                        column: x => x.PartidasPartidaId,
                        principalTable: "Partidas",
                        principalColumn: "PartidaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_JugadorId",
                table: "Movimientos",
                column: "JugadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_PartidaId",
                table: "Movimientos",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_PartidasPartidaId",
                table: "Movimientos",
                column: "PartidasPartidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");
        }
    }
}
