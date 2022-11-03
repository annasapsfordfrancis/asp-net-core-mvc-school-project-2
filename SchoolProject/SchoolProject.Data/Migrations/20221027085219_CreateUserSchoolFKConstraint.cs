using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Data.Migrations
{
    public partial class CreateUserSchoolFKConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_SchoolId",
                table: "User",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_School_SchoolId",
                table: "User",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_School_SchoolId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_SchoolId",
                table: "User");
        }
    }
}
