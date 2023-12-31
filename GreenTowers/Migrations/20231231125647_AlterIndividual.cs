using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTowers.Migrations
{
    /// <inheritdoc />
    public partial class AlterIndividual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualWarnigns_Users_UserId",
                table: "IndividualWarnigns");

            migrationBuilder.DropIndex(
                name: "IX_IndividualWarnigns_UserId",
                table: "IndividualWarnigns");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "IndividualWarnigns");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "IndividualWarnigns",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualWarnigns_UserId",
                table: "IndividualWarnigns",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualWarnigns_Users_UserId",
                table: "IndividualWarnigns",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
