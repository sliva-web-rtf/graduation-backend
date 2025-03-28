using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StudentAcademicGroupNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicGroups_AcademicGroupId",
                table: "Students");

            migrationBuilder.AlterColumn<Guid>(
                name: "AcademicGroupId",
                table: "Students",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AcademicGroups_AcademicGroupId",
                table: "Students",
                column: "AcademicGroupId",
                principalTable: "AcademicGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicGroups_AcademicGroupId",
                table: "Students");

            migrationBuilder.AlterColumn<Guid>(
                name: "AcademicGroupId",
                table: "Students",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AcademicGroups_AcademicGroupId",
                table: "Students",
                column: "AcademicGroupId",
                principalTable: "AcademicGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
