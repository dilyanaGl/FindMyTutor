using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMyTutor.Data.Migrations
{
    public partial class RedoneOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Offers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Offers");
        }
    }
}
