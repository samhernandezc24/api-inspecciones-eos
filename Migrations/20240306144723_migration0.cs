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
                name: "InspeccionesUnidadesEstatus",
                schema: "inspeccion",
                columns: table => new
                {
                    IdInspeccionUnidadEstatus = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspeccionesUnidadesEstatus", x => x.IdInspeccionUnidadEstatus);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                schema: "inspeccion",
                columns: table => new
                {
                    IdUnidad = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroEconomico = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUnidadTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadTipoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUnidadMarca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadMarcaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUnidadPlacaTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadPlacaTipoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnioEquipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacidad = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Odometro = table.Column<int>(type: "int", nullable: false),
                    Horometro = table.Column<int>(type: "int", nullable: false),
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
                name: "InspeccionesUnidades",
                schema: "inspeccion",
                columns: table => new
                {
                    IdInspeccionUnidad = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Folio = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdInspeccionUnidadEstatus = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspeccionUnidadEstatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUnidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadNumeroEconomico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUnidadTemporal = table.Column<bool>(type: "bit", nullable: false),
                    IdUnidadMarca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadMarcaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInspeccion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspeccionFolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspeccionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInspeccionInicial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaInspeccionInicialUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserInspeccionInicial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserInspeccionInicialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInspeccionFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaInspeccionFinalUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserInspeccionFinal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserInspeccionFinalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdRequerimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequerimientoFolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUnidadPlacaTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadPlacaTipoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnioEquipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacidad = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Odometro = table.Column<int>(type: "int", nullable: false),
                    Horometro = table.Column<int>(type: "int", nullable: false),
                    TipoPlataforma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_InspeccionesUnidades_InspeccionesUnidadesEstatus_IdInspeccionUnidadEstatus",
                        column: x => x.IdInspeccionUnidadEstatus,
                        principalSchema: "inspeccion",
                        principalTable: "InspeccionesUnidadesEstatus",
                        principalColumn: "IdInspeccionUnidadEstatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspeccionesUnidades_Inspecciones_IdInspeccion",
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
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInspeccion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspeccionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInspeccionCategoria = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspeccionCategoriaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdFormularioTipo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FormularioTipoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormularioValor = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_InspeccionesCategoriasItems_FormulariosTipos_IdFormularioTipo",
                        column: x => x.IdFormularioTipo,
                        principalSchema: "inspeccion",
                        principalTable: "FormulariosTipos",
                        principalColumn: "IdFormularioTipo",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_InspeccionesCategoriasItems_IdFormularioTipo",
                schema: "inspeccion",
                table: "InspeccionesCategoriasItems",
                column: "IdFormularioTipo");

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

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidades_Folio",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                column: "Folio",
                unique: true,
                filter: "[Folio] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidades_IdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                column: "IdInspeccion");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidades_IdInspeccionUnidadEstatus",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                column: "IdInspeccionUnidadEstatus");

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

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_NumeroEconomico",
                schema: "inspeccion",
                table: "Unidades",
                column: "NumeroEconomico",
                unique: true,
                filter: "[NumeroEconomico] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspeccionesCategoriasItems",
                schema: "inspeccion");

            migrationBuilder.DropTable(
                name: "InspeccionesUnidadesCategoriasItems",
                schema: "inspeccion");

            migrationBuilder.DropTable(
                name: "InspeccionesUnidadesFicheros",
                schema: "inspeccion");

            migrationBuilder.DropTable(
                name: "Unidades",
                schema: "inspeccion");

            migrationBuilder.DropTable(
                name: "InspeccionesCategorias",
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

            migrationBuilder.DropTable(
                name: "InspeccionesUnidadesEstatus",
                schema: "inspeccion");

            migrationBuilder.DropTable(
                name: "Inspecciones",
                schema: "inspeccion");
        }
    }
}
