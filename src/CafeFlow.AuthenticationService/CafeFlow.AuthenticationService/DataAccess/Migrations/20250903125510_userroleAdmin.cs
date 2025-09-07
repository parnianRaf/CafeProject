using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeFlow.AuthenticationService.Migrations
{
    /// <inheritdoc />
    public partial class userroleAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("af5fd740-39e4-29f6-3e39-396b339487d4"), new Guid("954f01de-d4d7-7e89-3c58-8fcb5af4aa51") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("af5fd740-39e4-29f6-3e39-396b339487d4"), new Guid("954f01de-d4d7-7e89-3c58-8fcb5af4aa51") });
        }
    }
}
