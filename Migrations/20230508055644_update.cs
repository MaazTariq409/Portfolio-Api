using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_API.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "educations");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "user",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Institute",
                table: "educations",
                newName: "institute");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "educations",
                newName: "grade");

            migrationBuilder.RenameColumn(
                name: "DegreeName",
                table: "educations",
                newName: "degreeName");

            migrationBuilder.RenameColumn(
                name: "DegreeLevel",
                table: "educations",
                newName: "degreeLevel");

            migrationBuilder.RenameColumn(
                name: "Achievement",
                table: "educations",
                newName: "achievement");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "educations",
                newName: "passingYear");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "about",
                newName: "ProfileUrl");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "about",
                newName: "PhoneNo");

            migrationBuilder.RenameColumn(
                name: "Git",
                table: "about",
                newName: "Github");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "about",
                newName: "Dob");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "user",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "user",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "user",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "institute",
                table: "educations",
                newName: "Institute");

            migrationBuilder.RenameColumn(
                name: "grade",
                table: "educations",
                newName: "Grade");

            migrationBuilder.RenameColumn(
                name: "degreeName",
                table: "educations",
                newName: "DegreeName");

            migrationBuilder.RenameColumn(
                name: "degreeLevel",
                table: "educations",
                newName: "DegreeLevel");

            migrationBuilder.RenameColumn(
                name: "achievement",
                table: "educations",
                newName: "Achievement");

            migrationBuilder.RenameColumn(
                name: "passingYear",
                table: "educations",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "ProfileUrl",
                table: "about",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "about",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "Github",
                table: "about",
                newName: "Git");

            migrationBuilder.RenameColumn(
                name: "Dob",
                table: "about",
                newName: "Age");

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                table: "educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
