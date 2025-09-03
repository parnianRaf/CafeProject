using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeFlow.AuthenticationService.Migrations
{
    /// <inheritdoc />
    public partial class bringbackRoleDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Code", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1d01aef3-7d88-8849-13dc-f4039142e807"), 2, null, "Customer", "CUSTOMER" },
                    { new Guid("af5fd740-39e4-29f6-3e39-396b339487d4"), 3, null, "Admin", "ADMIN" },
                    { new Guid("f6761cd0-a83d-3f32-ffe5-b08fa5f70fd2"), 1, null, "Barista", "BARISTA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d01aef3-7d88-8849-13dc-f4039142e807"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("af5fd740-39e4-29f6-3e39-396b339487d4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f6761cd0-a83d-3f32-ffe5-b08fa5f70fd2"));
        }
    }
}
