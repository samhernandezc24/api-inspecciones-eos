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
                name: "Observaciones",
                schema: "inspeccion",
                table: "Unidades");

            migrationBuilder.AlterColumn<string>(
                name: "Capacidad",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Capacidad",
                schema: "inspeccion",
                table: "Unidades",
                type: "decimal(15,3)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                schema: "inspeccion",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
