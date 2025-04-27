using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamedFormattingReviewer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicGroups_Users_FormattingReviewer",
                table: "AcademicGroups");

            migrationBuilder.RenameColumn(
                name: "FormattingReviewer",
                table: "AcademicGroups",
                newName: "FormattingReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicGroups_FormattingReviewer",
                table: "AcademicGroups",
                newName: "IX_AcademicGroups_FormattingReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicGroups_Users_FormattingReviewerId",
                table: "AcademicGroups",
                column: "FormattingReviewerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicGroups_Users_FormattingReviewerId",
                table: "AcademicGroups");

            migrationBuilder.RenameColumn(
                name: "FormattingReviewerId",
                table: "AcademicGroups",
                newName: "FormattingReviewer");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicGroups_FormattingReviewerId",
                table: "AcademicGroups",
                newName: "IX_AcademicGroups_FormattingReviewer");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicGroups_Users_FormattingReviewer",
                table: "AcademicGroups",
                column: "FormattingReviewer",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
