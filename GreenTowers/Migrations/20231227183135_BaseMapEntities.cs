using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GreenTowers.Migrations
{
    /// <inheritdoc />
    public partial class BaseMapEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warnigns");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Visitors",
                newName: "VisitDate");

            migrationBuilder.AddColumn<int>(
                name: "FloorId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommonAreaId",
                table: "Schedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CommonAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlobalWarnigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalWarnigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualWarnigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualWarnigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualWarnigns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FloorId",
                table: "Users",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CommonAreaId",
                table: "Schedules",
                column: "CommonAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualWarnigns_UserId",
                table: "IndividualWarnigns",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_CommonAreas_CommonAreaId",
                table: "Schedules",
                column: "CommonAreaId",
                principalTable: "CommonAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Floor_FloorId",
                table: "Users",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_CommonAreas_CommonAreaId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Floor_FloorId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CommonAreas");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "GlobalWarnigns");

            migrationBuilder.DropTable(
                name: "IndividualWarnigns");

            migrationBuilder.DropIndex(
                name: "IX_Users_FloorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_CommonAreaId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "FloorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CommonAreaId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "VisitDate",
                table: "Visitors",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Visitors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "Users",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Warnigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warnigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warnigns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warnigns_UserId",
                table: "Warnigns",
                column: "UserId");
        }
    }
}
