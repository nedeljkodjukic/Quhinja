using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class AddedSelectedRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRatingForRecipes");

            migrationBuilder.AddColumn<int>(
                name: "selectedRecipe",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersRatingForDishes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    DishId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRatingForDishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersRatingForDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersRatingForDishes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRatingForDishes_DishId",
                table: "UsersRatingForDishes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRatingForDishes_UserId",
                table: "UsersRatingForDishes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRatingForDishes");

            migrationBuilder.DropColumn(
                name: "selectedRecipe",
                table: "Dishes");

            migrationBuilder.CreateTable(
                name: "UsersRatingForRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRatingForRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersRatingForRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersRatingForRecipes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRatingForRecipes_RecipeId",
                table: "UsersRatingForRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRatingForRecipes_UserId",
                table: "UsersRatingForRecipes",
                column: "UserId");
        }
    }
}
