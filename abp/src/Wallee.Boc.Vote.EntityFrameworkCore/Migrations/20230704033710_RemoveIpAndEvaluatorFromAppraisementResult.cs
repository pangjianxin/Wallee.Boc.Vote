using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.Vote.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIpAndEvaluatorFromAppraisementResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientIpAddress",
                table: "AppAppraisementResults");

            migrationBuilder.DropColumn(
                name: "Evaluator",
                table: "AppAppraisementResults");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "AppAppraisementResultScoreDetails",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "AppAppraisementResultScoreDetails");

            migrationBuilder.AddColumn<string>(
                name: "ClientIpAddress",
                table: "AppAppraisementResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Evaluator",
                table: "AppAppraisementResults",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
