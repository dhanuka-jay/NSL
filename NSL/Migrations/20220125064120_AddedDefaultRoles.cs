using Microsoft.EntityFrameworkCore.Migrations;

namespace NSL.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66d7e306-a3c3-446f-a700-7d96a1c025d3", "b027f7b3-807a-448e-9911-c1d555befded", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01512db9-6041-4bbf-ac87-56ffa403c82e", "c3b51efc-3eb3-4752-99a6-e4b93a454240", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01512db9-6041-4bbf-ac87-56ffa403c82e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66d7e306-a3c3-446f-a700-7d96a1c025d3");
        }
    }
}
