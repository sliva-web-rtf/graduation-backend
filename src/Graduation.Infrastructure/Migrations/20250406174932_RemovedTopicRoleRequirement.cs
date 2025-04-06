using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTopicRoleRequirement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleTopics_QualificationWorkRoles_QualificationWorkRole~",
                table: "UserRoleTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoleTopics",
                table: "UserRoleTopics");

            migrationBuilder.AlterColumn<Guid>(
                name: "QualificationWorkRoleId",
                table: "UserRoleTopics",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoleTopics",
                table: "UserRoleTopics",
                columns: new[] { "UserId", "TopicId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleTopics_QualificationWorkRoles_QualificationWorkRole~",
                table: "UserRoleTopics",
                column: "QualificationWorkRoleId",
                principalTable: "QualificationWorkRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleTopics_QualificationWorkRoles_QualificationWorkRole~",
                table: "UserRoleTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoleTopics",
                table: "UserRoleTopics");

            migrationBuilder.AlterColumn<Guid>(
                name: "QualificationWorkRoleId",
                table: "UserRoleTopics",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoleTopics",
                table: "UserRoleTopics",
                columns: new[] { "UserId", "TopicId", "QualificationWorkRoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleTopics_QualificationWorkRoles_QualificationWorkRole~",
                table: "UserRoleTopics",
                column: "QualificationWorkRoleId",
                principalTable: "QualificationWorkRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
