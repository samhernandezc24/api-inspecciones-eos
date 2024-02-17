using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Inspecciones.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnidadesRegistros",
                schema: "inspeccion",
                columns: table => new
                {
                    IdUnidadRegistro = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroEconomico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdRequerimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequerimientoFolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesRegistros", x => x.IdUnidadRegistro);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnidadesRegistros",
                schema: "inspeccion");
        }
    }
}
