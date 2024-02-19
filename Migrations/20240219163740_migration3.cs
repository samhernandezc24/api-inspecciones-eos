using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Inspecciones.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspeccionesUnidades_Inspecciones_InspeccionIdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropIndex(
                name: "IX_InspeccionesUnidades_InspeccionIdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropColumn(
                name: "InspeccionIdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.AlterColumn<string>(
                name: "IdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidades_IdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                column: "IdInspeccion");

            migrationBuilder.AddForeignKey(
                name: "FK_InspeccionesUnidades_Inspecciones_IdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                column: "IdInspeccion",
                principalSchema: "inspeccion",
                principalTable: "Inspecciones",
                principalColumn: "IdInspeccion",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspeccionesUnidades_Inspecciones_IdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.DropIndex(
                name: "IX_InspeccionesUnidades_IdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades");

            migrationBuilder.AlterColumn<string>(
                name: "IdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspeccionIdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionesUnidades_InspeccionIdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                column: "InspeccionIdInspeccion");

            migrationBuilder.AddForeignKey(
                name: "FK_InspeccionesUnidades_Inspecciones_InspeccionIdInspeccion",
                schema: "inspeccion",
                table: "InspeccionesUnidades",
                column: "InspeccionIdInspeccion",
                principalSchema: "inspeccion",
                principalTable: "Inspecciones",
                principalColumn: "IdInspeccion");
        }
    }
}
