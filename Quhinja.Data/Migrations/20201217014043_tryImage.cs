using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class tryImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Users",
                nullable: true);
        }
          

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "50c0258b-1ba2-494a-b32b-17633c3725c8");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ad6bb403-395f-4ad2-af1c-1bb0deafc16a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "DateOfEmployment" },
                values: new object[] { "7bf9e8f1-7041-4b3e-8a78-f7e45c863966", new DateTime(2020, 12, 15, 20, 21, 50, 571, DateTimeKind.Local).AddTicks(8921), new DateTime(2020, 12, 15, 20, 21, 50, 574, DateTimeKind.Local).AddTicks(2153) });
        }
    }
}
