using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreWebApi_v5.Migrations
{
    public partial class AddedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf3ba4bb-6d54-45ff-b692-85610c79ccf1", "db9d9139-3b66-4800-8100-29956bc845d1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7b76407-c291-4f4e-9d89-e00f9f4f855c", "6b567e30-2ac3-462d-b89f-cbb3fb37c865", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf3ba4bb-6d54-45ff-b692-85610c79ccf1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7b76407-c291-4f4e-9d89-e00f9f4f855c");
        }
    }
}
