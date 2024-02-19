using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Inspecciones.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnidadesRegistros",
                schema: "inspeccion");

            migrationBuilder.RenameColumn(
                name: "FormularioTipo",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems",
                newName: "FormularioTipoName");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdFormularioTipo",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FormulariosTipos",
                schema: "inspeccion",
                columns: table => new
                {
                    IdFormularioTipo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulariosTipos", x => x.IdFormularioTipo);
                });

            migrationBuilder.CreateTable(
                name: "InspeccionesUnidades",
                schema: "inspeccion",
                columns: table => new
                {
                    IdInspeccionUnidad = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUnidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadNumeroEconomico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUnidadTemporal = table.Column<bool>(type: "bit", nullable: false),
                    Folio = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdInspeccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspeccionIdInspeccion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspeccionFolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspeccionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInspeccionInicial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaInspeccionInicialUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaInspeccionFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaInspeccionFinalUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdRequerimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequerimientoFolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPlataforma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horometro = table.Column<int>(type: "int", nullable: false),
                    Odometro = table.Column<int>(type: "int", nullable: false),
                    Locacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaOperador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaVerificador = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_InspeccionesUnidades", x => x.IdInspeccionUnidad);
                    table.ForeignKey(
                        name: "FK_InspeccionesUnidades_Inspecciones_InspeccionIdInspeccion",
                        column: x => x.InspeccionIdInspeccion,
                        principalSchema: "inspeccion",
                        principalTable: "Inspecciones",
                        principalColumn: "IdInspeccion");
                });

            migrationBuilder.CreateTable(
                name: "InspeccionesUnidadesCategorias",
                schema: "inspeccion",
                columns: table => new
                {
                    IdInspeccionUnidadCategoria = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInspeccionUnidad = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspeccionUnidadFolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_InspeccionesUnidadesCategorias", x => x.IdInspeccionUnidadCategoria);
                    table.ForeignKey(
                        name: "FK_InspeccionesUnidadesCategorias_InspeccionesUnidades_IdInspeccionUnidad",
                        column: x => x.IdInspeccionUnidad,
                        principalSchema: "inspeccion",
                        principalTable: "InspeccionesUnidades",
                        principalColumn: "IdInspeccionUnidad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspeccionesUnidadesFicheros",
                schema: "inspeccion",
                columns: table => new
                {
                    IdInspeccionUnidadFichero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdInspeccionUnidad = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspeccionUnidadFolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_InspeccionesUnidadesFicheros", x => x.IdInspeccionUnidadFichero);
                    table.ForeignKey(
                        name: "FK_InspeccionesUnidadesFicheros_InspeccionesUnidades_IdInspeccionUnidad",
                        column: x => x.IdInspeccionUnidad,
                        principalSchema: "inspeccion",
                        principalTable: "InspeccionesUnidades",
                        principalColumn: "IdInspeccionUnidad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspeccionesUnidadesCategoriasItems",
                schema: "inspeccion",
                columns: table => new
                {
                    IdInspeccionUnidadCategoriaItem = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInspeccionUnidad = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspeccionUnidadFolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInspeccionUnidadCategoria = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspeccionUnidadCategoriaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdFormularioTipo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FormularioTipoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormularioValor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_InspeccionesUnidadesCategoriasItems", x => x.IdInspeccionUnidadCategoriaItem);
                    table.ForeignKey(
                        name: "FK_InspeccionesUnidadesCategoriasItems_FormulariosTipos_IdFormularioTipo",
                        column: x => x.IdFormularioTipo,
                        principalSchema: "inspeccion",
                        principalTable: "FormulariosTipos",
                        principalColumn: "IdFormularioTipo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspeccionesUnidadesCategoriasItems_InspeccionesUnidadesCategorias_IdInspeccionUnidadCategoria",
                        column: x => x.IdInspeccionUnidadCategoria,
                        principalSchema: "inspeccion",
                        principalTable: "InspeccionesUnidadesCategorias",
                        principalColumn: "IdInspeccionUnidadCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspeccionesUnidadesCategoriasItems_InspeccionesUnidades_IdInspeccionUnidad",
                        column: x => x.IdInspeccionUnidad,
                        principalSchema: "inspeccion",
                        principalTable: "InspeccionesUnidades",
                        principalColumn: "IdInspeccionUnidad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesCategoriasItems_IdFormularioTipo",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems",
                column: "IdFormularioTipo");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidades_Folio",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                column: "Folio",
                unique: true,
                filter: "[Folio] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidades_InspeccionIdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                column: "InspeccionIdInspeccion");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidadesCategorias_IdInspeccionUnidad",
                schema: "inspeccion",
                table: "InspeccionesUnidadesCategorias",
                column: "IdInspeccionUnidad");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidadesCategoriasItems_IdFormularioTipo",
                schema: "inspeccion",
                table: "InspeccionesUnidadesCategoriasItems",
                column: "IdFormularioTipo");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidadesCategoriasItems_IdInspeccionUnidad",
                schema: "inspeccion",
                table: "InspeccionesUnidadesCategoriasItems",
                column: "IdInspeccionUnidad");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidadesCategoriasItems_IdInspeccionUnidadCategoria",
                schema: "inspeccion",
                table: "InspeccionesUnidadesCategoriasItems",
                column: "IdInspeccionUnidadCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidadesFicheros_IdInspeccionUnidad",
                schema: "inspeccion",
                table: "InspeccionesUnidadesFicheros",
                column: "IdInspeccionUnidad");

            migrationBuilder.AddForeignKey(
                name: "FK_InspeccionesCategoriasItems_FormulariosTipos_IdFormularioTipo",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems",
                column: "IdFormularioTipo",
                principalSchema: "inspeccion",
                principalTable: "FormulariosTipos",
                principalColumn: "IdFormularioTipo",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspeccionesCategoriasItems_FormulariosTipos_IdFormularioTipo",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems");

            migrationBuilder.DropTable(
                name: "InspeccionesUnidadesCategoriasItems",
                schema: "inspeccion");

            migrationBuilder.DropTable(
                name: "InspeccionesUnidadesFicheros",
                schema: "inspeccion");

            migrationBuilder.DropTable(
                name: "FormulariosTipos",
                schema: "inspeccion");

            migrationBuilder.DropTable(
                name: "InspeccionesUnidadesCategorias",
                schema: "inspeccion");

            migrationBuilder.DropTable(
                name: "InspeccionesUnidades",
                schema: "inspeccion");

            migrationBuilder.DropIndex(
                name: "IX_InspeccionesCategoriasItems_IdFormularioTipo",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems");

            migrationBuilder.DropColumn(
                name: "IdFormularioTipo",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems");

            migrationBuilder.RenameColumn(
                name: "FormularioTipoName",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems",
                newName: "FormularioTipo");

            migrationBuilder.CreateTable(
                name: "UnidadesRegistros",
                schema: "inspeccion",
                columns: table => new
                {
                    IdUnidadRegistro = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdRequerimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroEconomico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequerimientoFolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesRegistros", x => x.IdUnidadRegistro);
                });
        }
    }
}
