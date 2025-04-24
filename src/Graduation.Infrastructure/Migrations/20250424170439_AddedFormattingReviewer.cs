using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedFormattingReviewer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FormattingReviewer",
                table: "AcademicGroups",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroups_FormattingReviewer",
                table: "AcademicGroups",
                column: "FormattingReviewer");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicGroups_Users_FormattingReviewer",
                table: "AcademicGroups",
                column: "FormattingReviewer",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicGroups_Users_FormattingReviewer",
                table: "AcademicGroups");

            migrationBuilder.DropIndex(
                name: "IX_AcademicGroups_FormattingReviewer",
                table: "AcademicGroups");

            migrationBuilder.DropColumn(
                name: "FormattingReviewer",
                table: "AcademicGroups");
        }
    }
}
