using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedComissionStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorkStages_Commissions_CommissionId",
                table: "QualificationWorkStages");

            migrationBuilder.RenameColumn(
                name: "Topic",
                table: "QualificationWorks",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "QualificationWorkStages",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "CommissionId",
                table: "QualificationWorkStages",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<bool>(
                name: "IsInvited",
                table: "CommissionExperts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CommissionStudents",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CommissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    StageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionStudents", x => new { x.UserId, x.CommissionId, x.StageId });
                    table.ForeignKey(
                        name: "FK_CommissionStudents_Commissions_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommissionStudents_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommissionStudents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommissionStudents_CommissionId",
                table: "CommissionStudents",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionStudents_StageId",
                table: "CommissionStudents",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorkStages_Commissions_CommissionId",
                table: "QualificationWorkStages",
                column: "CommissionId",
                principalTable: "Commissions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorkStages_Commissions_CommissionId",
                table: "QualificationWorkStages");

            migrationBuilder.DropTable(
                name: "CommissionStudents");

            migrationBuilder.DropColumn(
                name: "IsInvited",
                table: "CommissionExperts");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "QualificationWorks",
                newName: "Topic");

            migrationBuilder.AlterColumn<int>(
                name: "Result",
                table: "QualificationWorkStages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CommissionId",
                table: "QualificationWorkStages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorkStages_Commissions_CommissionId",
                table: "QualificationWorkStages",
                column: "CommissionId",
                principalTable: "Commissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
