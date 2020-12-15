using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class seedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "DateOfEmployment", "Email", "EmailConfirmed", "FavouriteDishId", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "ProfilePictureUrl", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "7bf9e8f1-7041-4b3e-8a78-f7e45c863966", new DateTime(2020, 12, 15, 20, 21, 50, 571, DateTimeKind.Local).AddTicks(8921), new DateTime(2020, 12, 15, 20, 21, 50, 574, DateTimeKind.Local).AddTicks(2153), "srdjan.arsic@quadrixsoft.com", false, null, 1, true, null, "Srdjan", "SRDJAN.ARSIC@QUADRIXSOFT.COM", "ADM", "AQAAAAEAACcQAAAAELVcpiFzbc+pNTWWEBIXRKHvCaoWR65ihDzBGmGTwqAWU5kcy7KVDHLS+YSPTycg7w==", null, false, null, null, "5TBB7CACI3F2JOD25JGXSNQASZ2NWHRK", "Arsic", false, "adm" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "901ecd14-89e9-4543-9be3-0a641b52fd25");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "21906081-e475-4d47-96f1-0993a7e002d3");
        }
    }
}
