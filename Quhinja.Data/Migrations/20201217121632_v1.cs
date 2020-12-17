using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "dd9f7033-b4f1-47be-a2df-3fc619f7056f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "25ee817f-8ba8-4e91-a6f2-00dee719b090");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "DateOfEmployment" },
                values: new object[] { "8b83440c-1df2-4f5e-92ac-ea2af15f6d63", new DateTime(2020, 12, 17, 2, 46, 32, 438, DateTimeKind.Local).AddTicks(4768), new DateTime(2020, 12, 17, 2, 46, 32, 447, DateTimeKind.Local).AddTicks(9023) });
        }
    }
}
