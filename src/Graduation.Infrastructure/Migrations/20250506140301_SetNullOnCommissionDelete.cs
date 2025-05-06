using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetNullOnCommissionDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicGroups_Commissions_CommissionId",
                table: "AcademicGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorkStages_Commissions_CommissionId",
                table: "QualificationWorkStages");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicGroups_Commissions_CommissionId",
                table: "AcademicGroups",
                column: "CommissionId",
                principalTable: "Commissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorkStages_Commissions_CommissionId",
                table: "QualificationWorkStages",
                column: "CommissionId",
                principalTable: "Commissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicGroups_Commissions_CommissionId",
                table: "AcademicGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationWorkStages_Commissions_CommissionId",
                table: "QualificationWorkStages");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicGroups_Commissions_CommissionId",
                table: "AcademicGroups",
                column: "CommissionId",
                principalTable: "Commissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationWorkStages_Commissions_CommissionId",
                table: "QualificationWorkStages",
                column: "CommissionId",
                principalTable: "Commissions",
                principalColumn: "Id");
        }
    }
}
