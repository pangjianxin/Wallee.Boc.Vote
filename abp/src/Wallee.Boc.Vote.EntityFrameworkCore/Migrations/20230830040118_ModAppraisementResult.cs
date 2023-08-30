using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.Vote.Migrations
{
    /// <inheritdoc />
    public partial class ModAppraisementResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "AppAppraisementResultScoreDetails",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "AppAppraisementResultScoreDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AppAppraisementResultScoreDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "AppAppraisementResultScoreDetails",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);
        }
    }
}
