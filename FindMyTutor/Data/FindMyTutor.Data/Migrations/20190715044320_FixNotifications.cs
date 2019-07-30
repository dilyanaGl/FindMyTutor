using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMyTutor.Data.Migrations
{
    public partial class FixNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "MessageType",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResourceId",
                table: "Notifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Notifications",
                nullable: true);
        }
    }
}
