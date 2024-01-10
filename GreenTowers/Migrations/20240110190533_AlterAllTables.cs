using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTowers.Migrations
{
    /// <inheritdoc />
    public partial class AlterAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Regas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_UserId",
                table: "Visitors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CommonAreaId",
                table: "Schedules",
                column: "CommonAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Regas_UserId",
                table: "Regas",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Regas_Users_UserId",
                table: "Regas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_CommonAreas_CommonAreaId",
                table: "Schedules",
                column: "CommonAreaId",
                principalTable: "CommonAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_UserId",
                table: "Schedules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Users_UserId",
                table: "Visitors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualWarnigns_Users_UserId",
                table: "IndividualWarnigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Regas_Users_UserId",
                table: "Regas");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_CommonAreas_CommonAreaId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_UserId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Users_UserId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_UserId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_CommonAreaId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Regas_UserId",
                table: "Regas");

            migrationBuilder.DropIndex(
                name: "IX_IndividualWarnigns_UserId",
                table: "IndividualWarnigns");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Regas");
        }
    }
}
