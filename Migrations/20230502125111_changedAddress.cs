using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_API.Migrations
{
    public partial class changedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_about_User_UserID",
                table: "about");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_User_UserID",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_User_UserID",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_about_addressId",
                table: "about");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Education");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "user");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_about_addressId",
                table: "about",
                column: "addressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_about_user_UserID",
                table: "about",
                column: "UserID",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_user_UserID",
                table: "Education",
                column: "UserID",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_user_UserID",
                table: "Skills",
                column: "UserID",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_about_user_UserID",
                table: "about");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_user_UserID",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_user_UserID",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_about_addressId",
                table: "about");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Education");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "User");

            migrationBuilder.AddColumn<double>(
                name: "Duration",
                table: "Education",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_about_addressId",
                table: "about",
                column: "addressId");

            migrationBuilder.AddForeignKey(
                name: "FK_about_User_UserID",
                table: "about",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_User_UserID",
                table: "Education",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_User_UserID",
                table: "Skills",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
