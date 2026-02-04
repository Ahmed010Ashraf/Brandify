using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace presistance.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsInProjectRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "projectRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "projectRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectDetails",
                table: "projectRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "projectRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "projectRequests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "projectRequests");

            migrationBuilder.DropColumn(
                name: "ProjectDetails",
                table: "projectRequests");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "projectRequests");
        }
    }
}
