using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAcademicPrograms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_QualificationWork_QualificationWorkId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWork_QualificationWorkRoles_QualificationWorkR~",
                table: "QualificationWork");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWork_Students_StudentId",
                table: "QualificationWork");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWork_Topics_TopicId",
                table: "QualificationWork");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWork_Users_SupervisorId",
                table: "QualificationWork");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWork_Years_Year",
                table: "QualificationWork");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorkStages_QualificationWork_QualificationWork~",
                table: "QualificationWorkStages");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicChangeRequest_QualificationWork_QualificationWorkId",
                table: "TopicChangeRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualificationWork",
                table: "QualificationWork");

            migrationBuilder.DropColumn(
                name: "Limit",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "CompanySupervisorName",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "AcademicProgram",
                table: "AcademicGroups");

            migrationBuilder.RenameTable(
                name: "QualificationWork",
                newName: "QualificationWorks");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationWork_Year",
                table: "QualificationWorks",
                newName: "IX_QualificationWorks_Year");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationWork_TopicId",
                table: "QualificationWorks",
                newName: "IX_QualificationWorks_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationWork_SupervisorId",
                table: "QualificationWorks",
                newName: "IX_QualificationWorks_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationWork_StudentId",
                table: "QualificationWorks",
                newName: "IX_QualificationWorks_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationWork_QualificationWorkRoleId",
                table: "QualificationWorks",
                newName: "IX_QualificationWorks_QualificationWorkRoleId");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Topics",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanySupervisorName",
                table: "Topics",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AcademicProgramId",
                table: "AcademicGroups",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SupervisorId",
                table: "QualificationWorks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualificationWorks",
                table: "QualificationWorks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AcademicPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicPrograms_Years_Year",
                        column: x => x.Year,
                        principalTable: "Years",
                        principalColumn: "YearName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicAcademicPrograms",
                columns: table => new
                {
                    TopicId = table.Column<Guid>(type: "uuid", nullable: false),
                    AcademicProgramId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicAcademicPrograms", x => new { x.TopicId, x.AcademicProgramId });
                    table.ForeignKey(
                        name: "FK_TopicAcademicPrograms_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicAcademicPrograms_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroups_AcademicProgramId",
                table: "AcademicGroups",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPrograms_Year",
                table: "AcademicPrograms",
                column: "Year");

            migrationBuilder.CreateIndex(
                name: "IX_TopicAcademicPrograms_AcademicProgramId",
                table: "TopicAcademicPrograms",
                column: "AcademicProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicGroups_AcademicPrograms_AcademicProgramId",
                table: "AcademicGroups",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_QualificationWorks_QualificationWorkId",
                table: "Documents",
                column: "QualificationWorkId",
                principalTable: "QualificationWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorks_QualificationWorkRoles_QualificationWork~",
                table: "QualificationWorks",
                column: "QualificationWorkRoleId",
                principalTable: "QualificationWorkRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorks_Students_StudentId",
                table: "QualificationWorks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorks_Topics_TopicId",
                table: "QualificationWorks",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorks_Users_SupervisorId",
                table: "QualificationWorks",
                column: "SupervisorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorks_Years_Year",
                table: "QualificationWorks",
                column: "Year",
                principalTable: "Years",
                principalColumn: "YearName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorkStages_QualificationWorks_QualificationWor~",
                table: "QualificationWorkStages",
                column: "QualificationWorkId",
                principalTable: "QualificationWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicChangeRequest_QualificationWorks_QualificationWorkId",
                table: "TopicChangeRequest",
                column: "QualificationWorkId",
                principalTable: "QualificationWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicGroups_AcademicPrograms_AcademicProgramId",
                table: "AcademicGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_QualificationWorks_QualificationWorkId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorks_QualificationWorkRoles_QualificationWork~",
                table: "QualificationWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorks_Students_StudentId",
                table: "QualificationWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorks_Topics_TopicId",
                table: "QualificationWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorks_Users_SupervisorId",
                table: "QualificationWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorks_Years_Year",
                table: "QualificationWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorkStages_QualificationWorks_QualificationWor~",
                table: "QualificationWorkStages");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicChangeRequest_QualificationWorks_QualificationWorkId",
                table: "TopicChangeRequest");

            migrationBuilder.DropTable(
                name: "TopicAcademicPrograms");

            migrationBuilder.DropTable(
                name: "AcademicPrograms");

            migrationBuilder.DropIndex(
                name: "IX_AcademicGroups_AcademicProgramId",
                table: "AcademicGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualificationWorks",
                table: "QualificationWorks");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CompanySupervisorName",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "AcademicProgramId",
                table: "AcademicGroups");

            migrationBuilder.RenameTable(
                name: "QualificationWorks",
                newName: "QualificationWork");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationWorks_Year",
                table: "QualificationWork",
                newName: "IX_QualificationWork_Year");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationWorks_TopicId",
                table: "QualificationWork",
                newName: "IX_QualificationWork_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationWorks_SupervisorId",
                table: "QualificationWork",
                newName: "IX_QualificationWork_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationWorks_StudentId",
                table: "QualificationWork",
                newName: "IX_QualificationWork_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationWorks_QualificationWorkRoleId",
                table: "QualificationWork",
                newName: "IX_QualificationWork_QualificationWorkRoleId");

            migrationBuilder.AddColumn<int>(
                name: "Limit",
                table: "Topics",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Request",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanySupervisorName",
                table: "Request",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcademicProgram",
                table: "AcademicGroups",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SupervisorId",
                table: "QualificationWork",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualificationWork",
                table: "QualificationWork",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_QualificationWork_QualificationWorkId",
                table: "Documents",
                column: "QualificationWorkId",
                principalTable: "QualificationWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWork_QualificationWorkRoles_QualificationWorkR~",
                table: "QualificationWork",
                column: "QualificationWorkRoleId",
                principalTable: "QualificationWorkRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWork_Students_StudentId",
                table: "QualificationWork",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWork_Topics_TopicId",
                table: "QualificationWork",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWork_Users_SupervisorId",
                table: "QualificationWork",
                column: "SupervisorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWork_Years_Year",
                table: "QualificationWork",
                column: "Year",
                principalTable: "Years",
                principalColumn: "YearName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorkStages_QualificationWork_QualificationWork~",
                table: "QualificationWorkStages",
                column: "QualificationWorkId",
                principalTable: "QualificationWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicChangeRequest_QualificationWork_QualificationWorkId",
                table: "TopicChangeRequest",
                column: "QualificationWorkId",
                principalTable: "QualificationWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
