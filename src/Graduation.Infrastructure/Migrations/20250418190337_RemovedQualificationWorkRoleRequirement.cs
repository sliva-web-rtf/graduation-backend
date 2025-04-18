using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedQualificationWorkRoleRequirement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorks_QualificationWorkRoles_QualificationWork~",
                table: "QualificationWorks");

            migrationBuilder.AlterColumn<Guid>(
                name: "QualificationWorkRoleId",
                table: "QualificationWorks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorks_QualificationWorkRoles_QualificationWork~",
                table: "QualificationWorks",
                column: "QualificationWorkRoleId",
                principalTable: "QualificationWorkRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorks_QualificationWorkRoles_QualificationWork~",
                table: "QualificationWorks");

            migrationBuilder.AlterColumn<Guid>(
                name: "QualificationWorkRoleId",
                table: "QualificationWorks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorks_QualificationWorkRoles_QualificationWork~",
                table: "QualificationWorks",
                column: "QualificationWorkRoleId",
                principalTable: "QualificationWorkRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
