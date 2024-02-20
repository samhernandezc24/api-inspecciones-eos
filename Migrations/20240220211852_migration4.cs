using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Inspecciones.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Marca",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                newName: "UserInspeccionInicialName");

            migrationBuilder.AddColumn<string>(
                name: "AnioEquipo",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BaseName",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Capacidad",
                schema: "inspeccion",
                table: "Unidades",
                type: "decimal(15,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Horometro",
                schema: "inspeccion",
                table: "Unidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdBase",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUnidadMarca",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUnidadPlacaTipo",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroSerie",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Odometro",
                schema: "inspeccion",
                table: "Unidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnidadMarcaName",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnidadPlacaTipoName",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Capacidad",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "decimal(15,3)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AnioEquipo",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdInspeccionUnidadEstatus",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUnidadMarca",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUnidadPlacaTipo",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUserInspeccionFinal",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUserInspeccionInicial",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspeccionUnidadEstatusName",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnidadMarcaName",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnidadPlacaTipoName",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserInspeccionFinalName",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidades_IdInspeccionUnidadEstatus",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                column: "IdInspeccionUnidadEstatus");

            migrationBuilder.AddForeignKey(
                name: "FK_InspeccionesUnidades_InspeccionesUnidadesEstatus_IdInspeccionUnidadEstatus",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                column: "IdInspeccionUnidadEstatus",
                principalSchema: "inspeccion",
                principalTable: "InspeccionesUnidadesEstatus",
                principalColumn: "IdInspeccionUnidadEstatus",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspeccionesUnidades_InspeccionesUnidadesEstatus_IdInspeccionUnidadEstatus",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropTable(
                name: "InspeccionesUnidadesEstatus",
                schema: "inspeccion");

            migrationBuilder.DropIndex(
                name: "IX_InspeccionesUnidades_IdInspeccionUnidadEstatus",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropColumn(
                name: "AnioEquipo",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "BaseName",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "Capacidad",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "Horometro",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "IdBase",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "IdUnidadMarca",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "IdUnidadPlacaTipo",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "Modelo",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "NumeroSerie",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "Odometro",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "Placa",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "UnidadMarcaName",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "UnidadPlacaTipoName",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "AnioEquipo",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropColumn(
                name: "IdInspeccionUnidadEstatus",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropColumn(
                name: "IdUnidadMarca",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropColumn(
                name: "IdUnidadPlacaTipo",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropColumn(
                name: "IdUserInspeccionFinal",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropColumn(
                name: "IdUserInspeccionInicial",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropColumn(
                name: "InspeccionUnidadEstatusName",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropColumn(
                name: "Placa",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropColumn(
                name: "UnidadMarcaName",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropColumn(
                name: "UnidadPlacaTipoName",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropColumn(
                name: "UserInspeccionFinalName",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.RenameColumn(
                name: "UserInspeccionInicialName",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                newName: "Marca");

            migrationBuilder.AlterColumn<int>(
                name: "Capacidad",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,3)");
        }
    }
}
