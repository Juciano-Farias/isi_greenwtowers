using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTowers.Migrations
{
    /// <inheritdoc />
    public partial class AlterVisitorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Users_UserId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_UserId",
                table: "Visitors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Visitors_UserId",
                table: "Visitors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Users_UserId",
                table: "Visitors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
