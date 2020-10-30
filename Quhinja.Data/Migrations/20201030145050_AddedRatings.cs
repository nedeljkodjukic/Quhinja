using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class AddedRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRatings",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "NumberOfVoters",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "UsersRatingForRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRatingForRecipes");

            migrationBuilder.AddColumn<int>(
                name: "AverageRatings",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfVoters",
                table: "Recipes",
                type: "int",
                nullable: true);
        }
    }
}
