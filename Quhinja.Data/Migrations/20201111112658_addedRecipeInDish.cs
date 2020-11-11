using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class addedRecipeInDish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "selectedRecipe",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "selectedRecipeId",
                table: "Dishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "selectedRecipeId1",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_selectedRecipeId1",
                table: "Dishes",
                column: "selectedRecipeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Recipes_selectedRecipeId1",
                table: "Dishes",
                column: "selectedRecipeId1",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Recipes_selectedRecipeId1",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_selectedRecipeId1",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "selectedRecipeId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "selectedRecipeId1",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "selectedRecipe",
                table: "Dishes",
                type: "int",
                nullable: true);
        }
    }
}
