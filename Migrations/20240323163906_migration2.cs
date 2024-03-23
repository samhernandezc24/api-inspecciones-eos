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
            migrationBuilder.DropColumn(
                name: "Descripcion",
                schema: "inspeccion",
                table: "CategoriasItems");

            migrationBuilder.AddColumn<int>(
                name: "Orden",
                schema: "inspeccion",
                table: "InspeccionesTipos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Orden",
                schema: "inspeccion",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orden",
                schema: "inspeccion",
                table: "InspeccionesTipos");

            migrationBuilder.DropColumn(
                name: "Orden",
                schema: "inspeccion",
                table: "Categorias");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                schema: "inspeccion",
                table: "CategoriasItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
