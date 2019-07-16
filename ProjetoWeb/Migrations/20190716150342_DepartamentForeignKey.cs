using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWeb.Migrations
{
    public partial class DepartamentForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departament_DpId",
                table: "Vendedor");

            migrationBuilder.DropIndex(
                name: "IX_Vendedor_DpId",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "DpId",
                table: "Vendedor");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentId",
                table: "Vendedor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_DepartamentId",
                table: "Vendedor",
                column: "DepartamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departament_DepartamentId",
                table: "Vendedor",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departament_DepartamentId",
                table: "Vendedor");

            migrationBuilder.DropIndex(
                name: "IX_Vendedor_DepartamentId",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "DepartamentId",
                table: "Vendedor");

            migrationBuilder.AddColumn<int>(
                name: "DpId",
                table: "Vendedor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_DpId",
                table: "Vendedor",
                column: "DpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departament_DpId",
                table: "Vendedor",
                column: "DpId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
