using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class tryImage1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e67ba6ad-ae30-4aa0-971c-69ae38002f93");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "95e9868f-f4b2-49ca-8503-c4e92b97373b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "DateOfEmployment" },
                values: new object[] { "bd636fc0-b0d1-4119-a256-a0b38eba295c", new DateTime(2020, 12, 17, 2, 40, 42, 776, DateTimeKind.Local).AddTicks(3045), new DateTime(2020, 12, 17, 2, 40, 42, 786, DateTimeKind.Local).AddTicks(5057) });
        }
    }
}
