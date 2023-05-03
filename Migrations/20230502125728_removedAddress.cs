using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_API.Migrations
{
    public partial class removedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_about_addresses_addressId",
                table: "about");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropIndex(
                name: "IX_about_addressId",
                table: "about");

            migrationBuilder.RenameColumn(
                name: "addressId",
                table: "about",
                newName: "aboutId");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "about",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "about",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "about",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "about",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_about_aboutId",
                table: "about",
                column: "aboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_about_about_aboutId",
                table: "about",
                column: "aboutId",
                principalTable: "about",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_about_about_aboutId",
                table: "about");

            migrationBuilder.DropIndex(
                name: "IX_about_aboutId",
                table: "about");

            migrationBuilder.DropColumn(
                name: "City",
                table: "about");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "about");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "about");

            migrationBuilder.DropColumn(
                name: "State",
                table: "about");

            migrationBuilder.RenameColumn(
                name: "aboutId",
                table: "about",
                newName: "addressId");

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_about_addressId",
                table: "about",
                column: "addressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_about_addresses_addressId",
                table: "about",
                column: "addressId",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
