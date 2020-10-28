using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class ChangedBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Dishes_DishId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DishId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "FavouriteDishId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FavouriteDishId",
                table: "Users",
                column: "FavouriteDishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Dishes_FavouriteDishId",
                table: "Users",
                column: "FavouriteDishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Dishes_FavouriteDishId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FavouriteDishId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FavouriteDishId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "DishId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DishId",
                table: "Users",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Dishes_DishId",
                table: "Users",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
