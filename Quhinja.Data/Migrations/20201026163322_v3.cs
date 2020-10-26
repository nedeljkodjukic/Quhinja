using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingridientInRecipes_Indgridients_IngridientId",
                table: "ingridientInRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Indgridients",
                table: "Indgridients");

            migrationBuilder.RenameTable(
                name: "Indgridients",
                newName: "Ingridients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingridients",
                table: "Ingridients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ingridientInRecipes_Ingridients_IngridientId",
                table: "ingridientInRecipes",
                column: "IngridientId",
                principalTable: "Ingridients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingridientInRecipes_Ingridients_IngridientId",
                table: "ingridientInRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingridients",
                table: "Ingridients");

            migrationBuilder.RenameTable(
                name: "Ingridients",
                newName: "Indgridients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Indgridients",
                table: "Indgridients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ingridientInRecipes_Indgridients_IngridientId",
                table: "ingridientInRecipes",
                column: "IngridientId",
                principalTable: "Indgridients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
