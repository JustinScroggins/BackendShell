using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43fecca0-25d3-450d-83c4-1a240fb94669");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcdc67a5-f60c-4377-85e2-97d5ae048edc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84f541db-b2ff-49db-a09f-ff3a4d11f232", "0da5c4de-1b37-41ad-bcff-9496f24b36b0", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e5b5889-a9f4-4e0d-9c49-18852c6f2e42", "67e24ac5-e54d-4043-9d95-2b196ea64ccf", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e5b5889-a9f4-4e0d-9c49-18852c6f2e42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84f541db-b2ff-49db-a09f-ff3a4d11f232");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bcdc67a5-f60c-4377-85e2-97d5ae048edc", "a618bb59-6eed-49ec-ad5c-c9511bd9b835", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43fecca0-25d3-450d-83c4-1a240fb94669", "94c6f5cd-80e4-4305-9fa4-ecd002f8be22", "Administrator", "ADMINISTRATOR" });
        }
    }
}
