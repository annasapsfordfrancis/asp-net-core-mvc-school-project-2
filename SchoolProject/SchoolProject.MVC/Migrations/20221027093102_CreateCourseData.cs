using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.MVC.Migrations
{
    public partial class CreateCourseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseId", "CourseDescription", "CourseName" },
                values: new object[] { 1, "Introductory potions.", "Potions 1a" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseId", "CourseDescription", "CourseName" },
                values: new object[] { 2, "Introductory defensive magic.", "Defence Against the Dark Arts 1a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseId",
                keyValue: 2);
        }
    }
}
