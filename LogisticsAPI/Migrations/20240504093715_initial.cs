using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VesselName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdviceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceRequestTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TugPickUpLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TugLetGoLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PilotCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VesselId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VesselName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Callsign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrossTonnage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LengthOverall = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Beam = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Draft = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vessels");
        }
    }
}
