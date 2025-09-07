using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeFlow.AuthenticationService.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoleAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d01aef3-7d88-8849-13dc-f4039142e807"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f6761cd0-a83d-3f32-ffe5-b08fa5f70fd2"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("954f01de-d4d7-7e89-3c58-8fcb5af4aa51"),
                columns: new[] { "Email", "NormalizedUserName" },
                values: new object[] { "rafieparnian@gmail.com", "PARNIAN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Code", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1d01aef3-7d88-8849-13dc-f4039142e807"), 2, null, "Customer", null },
                    { new Guid("f6761cd0-a83d-3f32-ffe5-b08fa5f70fd2"), 1, null, "Barista", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("954f01de-d4d7-7e89-3c58-8fcb5af4aa51"),
                columns: new[] { "Email", "NormalizedUserName" },
                values: new object[] { null, null });
        }
    }
}
