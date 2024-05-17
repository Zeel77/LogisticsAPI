using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CraftName",
                table: "JobDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobStatus",
                table: "JobDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CraftName",
                table: "JobDetails");

            migrationBuilder.DropColumn(
                name: "JobStatus",
                table: "JobDetails");
        }
    }
}
