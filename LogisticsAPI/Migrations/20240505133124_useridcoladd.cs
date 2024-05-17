using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsAPI.Migrations
{
    /// <inheritdoc />
    public partial class useridcoladd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "JobDetails",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "JobDetails");
        }
    }
}
