using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Inspecciones.Migrations
{
    /// <inheritdoc />
    public partial class migration0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "inspeccion");

            migrationBuilder.CreateTable(
                name: "Inspecciones",
                schema: "inspeccion",
                columns: table => new
                {
                    IdInspeccion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Folio = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Inspecciones", x => x.IdInspeccion);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                schema: "inspeccion",
                columns: table => new
                {
                    IdUnidad = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroEconomico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUnidadTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadTipoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Unidades", x => x.IdUnidad);
                });

            migrationBuilder.CreateTable(
                name: "InspeccionesCategorias",
                schema: "inspeccion",
                columns: table => new
                {
                    IdInspeccionCategoria = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInspeccion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspeccionFolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspeccionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_InspeccionesCategorias", x => x.IdInspeccionCategoria);
                    table.ForeignKey(
                        name: "FK_InspeccionesCategorias_Inspecciones_IdInspeccion",
                        column: x => x.IdInspeccion,
                        principalSchema: "inspeccion",
                        principalTable: "Inspecciones",
                        principalColumn: "IdInspeccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspeccionesCategoriasItems",
                schema: "inspeccion",
                columns: table => new
                {
                    IdInspeccionCategoriaItem = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormularioTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormularioValor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInspeccion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspeccionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInspeccionCategoria = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspeccionCategoriaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_InspeccionesCategoriasItems", x => x.IdInspeccionCategoriaItem);
                    table.ForeignKey(
                        name: "FK_InspeccionesCategoriasItems_InspeccionesCategorias_IdInspeccionCategoria",
                        column: x => x.IdInspeccionCategoria,
                        principalSchema: "inspeccion",
                        principalTable: "InspeccionesCategorias",
                        principalColumn: "IdInspeccionCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspeccionesCategoriasItems_Inspecciones_IdInspeccion",
                        column: x => x.IdInspeccion,
                        principalSchema: "inspeccion",
                        principalTable: "Inspecciones",
                        principalColumn: "IdInspeccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_Folio",
                schema: "inspeccion",
                table: "Inspecciones",
                column: "Folio",
                unique: true,
                filter: "[Folio] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesCategorias_IdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesCategorias",
                column: "IdInspeccion");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesCategoriasItems_IdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems",
                column: "IdInspeccion");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesCategoriasItems_IdInspeccionCategoria",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems",
                column: "IdInspeccionCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspeccionesCategoriasItems",
                schema: "inspeccion");

            migrationBuilder.DropTable(
                name: "Unidades",
                schema: "inspeccion");

            migrationBuilder.DropTable(
                name: "InspeccionesCategorias",
                schema: "inspeccion");

            migrationBuilder.DropTable(
                name: "Inspecciones",
                schema: "inspeccion");
        }
    }
}
