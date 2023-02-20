using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental_Services.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthDetails",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InsertionDate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Password = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Role = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthDetails", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InsertionDate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    VehicleName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    VehicleNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    VehicleDescription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PricePerKm = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CustomerName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    MobileNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Source = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Destination = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    TotalDistance = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Status = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IsActive = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.BookingID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetails",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InsertionDate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    VehicleName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    VehicleNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    VehicleDescription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetails", x => x.VehicleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthDetails");

            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "VehicleDetails");
        }
    }
}
