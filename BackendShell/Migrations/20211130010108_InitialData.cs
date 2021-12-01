using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderType = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedByUserName", "CreatedDate", "CustomerName", "OrderType" },
                values: new object[,]
                {
                    { 1, "Matt", new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kroger", 0 },
                    { 2, "Shay", new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Target", 2 },
                    { 3, "David", new DateTime(2020, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walmart", 4 },
                    { 4, "Josh", new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aldi", 1 },
                    { 5, "Alex", new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meijer", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
