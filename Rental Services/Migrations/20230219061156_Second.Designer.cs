// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rental_Services.Data;

namespace Rental_Services.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230219061156_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Rental_Services.Data.AuthDetails", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("InsertionDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserID");

                    b.ToTable("AuthDetails");
                });

            modelBuilder.Entity("Rental_Services.Data.BookingDetails", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Destination")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("InsertionDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IsActive")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PricePerKm")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Status")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TotalDistance")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("VehicleDescription")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.Property<string>("VehicleName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("VehicleNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("BookingID");

                    b.ToTable("BookingDetails");
                });

            modelBuilder.Entity("Rental_Services.Data.VehicleDetails", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("InsertionDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("VehicleDescription")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("VehicleName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("VehicleNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("VehicleID");

                    b.ToTable("VehicleDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
