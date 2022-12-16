using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesNGoods.Server.Migrations
{
    public partial class AddedDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "Type", "UpdatedBy" },
                values: new object[] { 1, "System", new DateTime(2022, 12, 16, 18, 48, 59, 49, DateTimeKind.Local).AddTicks(684), new DateTime(2022, 12, 16, 18, 48, 59, 49, DateTimeKind.Local).AddTicks(8239), "Headphones", "Electronics", "System" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
