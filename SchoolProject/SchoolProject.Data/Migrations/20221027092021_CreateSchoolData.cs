using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Data.Migrations
{
    public partial class CreateSchoolData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "SchoolId", "SchoolName" },
                values: new object[] { 1, "Hogwarts" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "SchoolId",
                keyValue: 1);
        }
    }
}
