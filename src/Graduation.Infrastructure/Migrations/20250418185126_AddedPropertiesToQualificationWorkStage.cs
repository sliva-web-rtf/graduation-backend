using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertiesToQualificationWorkStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "QualificationWorkStages",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "QualificationWorkStages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanySupervisorName",
                table: "QualificationWorkStages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "QualificationWorkStages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "QualificationWorkRoleId",
                table: "QualificationWorkStages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupervisorId",
                table: "QualificationWorkStages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Time",
                table: "QualificationWorkStages",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId",
                table: "QualificationWorkStages",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualificationWorkStages_QualificationWorkRoleId",
                table: "QualificationWorkStages",
                column: "QualificationWorkRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationWorkStages_SupervisorId",
                table: "QualificationWorkStages",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationWorkStages_TopicId",
                table: "QualificationWorkStages",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorkStages_QualificationWorkRoles_Qualificatio~",
                table: "QualificationWorkStages",
                column: "QualificationWorkRoleId",
                principalTable: "QualificationWorkRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorkStages_Topics_TopicId",
                table: "QualificationWorkStages",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorkStages_Users_SupervisorId",
                table: "QualificationWorkStages",
                column: "SupervisorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorkStages_QualificationWorkRoles_Qualificatio~",
                table: "QualificationWorkStages");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorkStages_Topics_TopicId",
                table: "QualificationWorkStages");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorkStages_Users_SupervisorId",
                table: "QualificationWorkStages");

            migrationBuilder.DropIndex(
                name: "IX_QualificationWorkStages_QualificationWorkRoleId",
                table: "QualificationWorkStages");

            migrationBuilder.DropIndex(
                name: "IX_QualificationWorkStages_SupervisorId",
                table: "QualificationWorkStages");

            migrationBuilder.DropIndex(
                name: "IX_QualificationWorkStages_TopicId",
                table: "QualificationWorkStages");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "QualificationWorkStages");

            migrationBuilder.DropColumn(
                name: "CompanySupervisorName",
                table: "QualificationWorkStages");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "QualificationWorkStages");

            migrationBuilder.DropColumn(
                name: "QualificationWorkRoleId",
                table: "QualificationWorkStages");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "QualificationWorkStages");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "QualificationWorkStages");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "QualificationWorkStages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "QualificationWorkStages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }
    }
}
