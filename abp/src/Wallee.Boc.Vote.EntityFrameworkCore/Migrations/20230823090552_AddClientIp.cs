using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.Vote.Migrations
{
    /// <inheritdoc />
    public partial class AddClientIp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientIp",
                table: "AppAppraisementResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RuleName",
                table: "AppAppraisementResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientIp",
                table: "AppAppraisementResults");

            migrationBuilder.DropColumn(
                name: "RuleName",
                table: "AppAppraisementResults");
        }
    }
}
