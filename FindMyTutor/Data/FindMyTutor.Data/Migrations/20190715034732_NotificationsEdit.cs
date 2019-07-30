using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMyTutor.Data.Migrations
{
    public partial class NotificationsEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Notifications");

            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "Notifications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);
        }
    }
}
