using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCommissionStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommissionStudents_Users_UserId",
                table: "CommissionStudents");

            migrationBuilder.AddForeignKey(
                name: "FK_CommissionStudents_Students_UserId",
                table: "CommissionStudents",
                column: "UserId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommissionStudents_Students_UserId",
                table: "CommissionStudents");

            migrationBuilder.AddForeignKey(
                name: "FK_CommissionStudents_Users_UserId",
                table: "CommissionStudents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
