using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class proba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c9a975a2-23e1-4e20-83f8-66352b93a3cc");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "918a3ffd-ce5f-41ea-bdff-08e2b735bc4c");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "DateOfEmployment" },
                values: new object[] { "6a618558-02b9-4246-ab7f-a65484f465a7", new DateTime(2020, 12, 18, 12, 26, 2, 45, DateTimeKind.Local).AddTicks(7192), new DateTime(2020, 12, 18, 12, 26, 2, 53, DateTimeKind.Local).AddTicks(8143) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
