using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTowers.Migrations
{
    /// <inheritdoc />
    public partial class AlterScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Schedules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Canceled",
                table: "Schedules",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Canceled",
                table: "Schedules");
        }
    }
}
