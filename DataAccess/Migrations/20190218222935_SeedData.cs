using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chat",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("97959327-435e-4762-8995-1367583222e6"), "SuperName" });

            migrationBuilder.InsertData(
                table: "ChatMember",
                columns: new[] { "ChatId", "UserId" },
                values: new object[,]
                {
                    { new Guid("97959327-435e-4762-8995-1367583222e6"), 1L },
                    { new Guid("97959327-435e-4762-8995-1367583222e6"), 2L },
                    { new Guid("97959327-435e-4762-8995-1367583222e6"), 3L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatMember",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { new Guid("97959327-435e-4762-8995-1367583222e6"), 1L });

            migrationBuilder.DeleteData(
                table: "ChatMember",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { new Guid("97959327-435e-4762-8995-1367583222e6"), 2L });

            migrationBuilder.DeleteData(
                table: "ChatMember",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { new Guid("97959327-435e-4762-8995-1367583222e6"), 3L });

            migrationBuilder.DeleteData(
                table: "Chat",
                keyColumn: "Id",
                keyValue: new Guid("97959327-435e-4762-8995-1367583222e6"));
        }
    }
}
