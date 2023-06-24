using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.Vote.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEhrFromCandidateOrg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuperiorEhr",
                table: "AppCandidateOrgUnits");

            migrationBuilder.AddColumn<Guid>(
                name: "Superior",
                table: "AppCandidateOrgUnits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppEvaluationContents_Name",
                table: "AppEvaluationContents",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppEvaluationContents_Name",
                table: "AppEvaluationContents");

            migrationBuilder.DropColumn(
                name: "Superior",
                table: "AppCandidateOrgUnits");

            migrationBuilder.AddColumn<string>(
                name: "SuperiorEhr",
                table: "AppCandidateOrgUnits",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
