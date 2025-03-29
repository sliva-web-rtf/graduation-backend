using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TopicRequestedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Begins",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "Ends",
                table: "Stages");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Begin",
                table: "Stages",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "End",
                table: "Stages",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "TopicRequestedRoles",
                columns: table => new
                {
                    TopicId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Limit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicRequestedRoles", x => new { x.TopicId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_TopicRequestedRoles_QualificationWorkRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "QualificationWorkRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicRequestedRoles_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicRequestedRoles_RoleId",
                table: "TopicRequestedRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicRequestedRoles");

            migrationBuilder.DropColumn(
                name: "Begin",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Stages");

            migrationBuilder.AddColumn<DateTime>(
                name: "Begins",
                table: "Stages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Ends",
                table: "Stages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
