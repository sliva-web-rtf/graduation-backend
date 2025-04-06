using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedQualificationWorkStudentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QualificationWorks_StudentId",
                table: "QualificationWorks");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Stages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationWorks_StudentId",
                table: "QualificationWorks",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QualificationWorks_StudentId",
                table: "QualificationWorks");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Stages");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationWorks_StudentId",
                table: "QualificationWorks",
                column: "StudentId");
        }
    }
}
