using Microsoft.EntityFrameworkCore.Migrations;

namespace WalkingTracker.Data.Migrations
{
    public partial class RemoveCalcFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistCount",
                table: "Tracking");

            migrationBuilder.DropColumn(
                name: "DistTotal",
                table: "Tracking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistCount",
                table: "Tracking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DistTotal",
                table: "Tracking",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
