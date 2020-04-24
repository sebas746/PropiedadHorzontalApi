using Microsoft.EntityFrameworkCore.Migrations;

namespace PropiedadHorizontal.Data.Migrations
{
    public partial class identityMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bdaec55-4528-4aaf-bb34-9428600591d5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a30ffc68-44e8-4267-bfc3-4ca711b60b1f", "7c6ff4ec-5135-4f56-9257-064830184593", "consumer", "CONSUMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a30ffc68-44e8-4267-bfc3-4ca711b60b1f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5bdaec55-4528-4aaf-bb34-9428600591d5", "da007516-c5cf-42c5-a2e5-ee405ab0f248", "consumer", "CONSUMER" });
        }
    }
}
