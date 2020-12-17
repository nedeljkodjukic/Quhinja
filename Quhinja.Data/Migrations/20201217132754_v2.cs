using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Dishes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a8af8355-1742-41fd-90d8-77b2bc343106");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d0dd054d-7abb-4aab-97b7-e53cf2af9fdd");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "DateOfEmployment" },
                values: new object[] { "8f64bb9e-bb65-4eda-8140-813e9e062ea2", new DateTime(2020, 12, 17, 14, 27, 53, 181, DateTimeKind.Local).AddTicks(1065), new DateTime(2020, 12, 17, 14, 27, 53, 191, DateTimeKind.Local).AddTicks(2547) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Dishes");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "46a9da7e-60a7-4398-8767-fd80020bfd62");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "26906e5e-e222-4fb4-88d5-b283d59aecf3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "DateOfEmployment" },
                values: new object[] { "d2108993-86d9-4e42-b9ec-4ff0820276aa", new DateTime(2020, 12, 17, 13, 16, 31, 364, DateTimeKind.Local).AddTicks(9344), new DateTime(2020, 12, 17, 13, 16, 31, 372, DateTimeKind.Local).AddTicks(5106) });
        }
    }
}
