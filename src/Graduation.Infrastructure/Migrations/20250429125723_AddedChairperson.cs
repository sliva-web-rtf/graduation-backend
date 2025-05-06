using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedChairperson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChairpersonId",
                table: "Commissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_ChairpersonId",
                table: "Commissions",
                column: "ChairpersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commissions_Users_ChairpersonId",
                table: "Commissions",
                column: "ChairpersonId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commissions_Users_ChairpersonId",
                table: "Commissions");

            migrationBuilder.DropIndex(
                name: "IX_Commissions_ChairpersonId",
                table: "Commissions");

            migrationBuilder.DropColumn(
                name: "ChairpersonId",
                table: "Commissions");
        }
    }
}
