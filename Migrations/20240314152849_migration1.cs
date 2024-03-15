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
            migrationBuilder.AddColumn<int>(
                name: "Orden",
                schema: "inspeccion",
                table: "CategoriasItems",
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
                table: "CategoriasItems");
        }
    }
}
