using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWeb.Migrations
{
    public partial class Reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departament_DepartamentId",
                table: "Vendedor");

            migrationBuilder.RenameColumn(
                name: "DepartamentId",
                table: "Vendedor",
                newName: "DpId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedor_DepartamentId",
                table: "Vendedor",
                newName: "IX_Vendedor_DpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departament_DpId",
                table: "Vendedor",
                column: "DpId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departament_DpId",
                table: "Vendedor");

            migrationBuilder.RenameColumn(
                name: "DpId",
                table: "Vendedor",
                newName: "DepartamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedor_DpId",
                table: "Vendedor",
                newName: "IX_Vendedor_DepartamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departament_DepartamentId",
                table: "Vendedor",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
