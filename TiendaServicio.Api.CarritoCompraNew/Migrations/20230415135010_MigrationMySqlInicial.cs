using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace TiendaServicio.Api.CarritoCompraNew.Migrations
{
    public partial class MigrationMySqlInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarritoSession",
                columns: table => new
                {
                    CarritoSessionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSession", x => x.CarritoSessionId);
                });

            migrationBuilder.CreateTable(
                name: "carritoSessionDetalle",
                columns: table => new
                {
                    CarritoSessionDetalleId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    ProductoSeleccionado = table.Column<string>(nullable: true),
                    CarritoSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carritoSessionDetalle", x => x.CarritoSessionDetalleId);
                    table.ForeignKey(
                        name: "FK_carritoSessionDetalle_CarritoSession_CarritoSessionId",
                        column: x => x.CarritoSessionId,
                        principalTable: "CarritoSession",
                        principalColumn: "CarritoSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carritoSessionDetalle_CarritoSessionId",
                table: "carritoSessionDetalle",
                column: "CarritoSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carritoSessionDetalle");

            migrationBuilder.DropTable(
                name: "CarritoSession");
        }
    }
}
