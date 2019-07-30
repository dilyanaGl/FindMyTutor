using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMyTutor.Data.Migrations
{
    public partial class PriceNonMandatory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Offers",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Offers",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
