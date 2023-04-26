using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Rental_Table_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalEndTime",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "RentalStartTime",
                table: "Rentals",
                newName: "RentalStartDate");

            migrationBuilder.RenameColumn(
                name: "RentalDay",
                table: "Rentals",
                newName: "RentedForDays");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalEndDate",
                table: "Rentals",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId",
                descending: new bool[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Cars_CarId",
                table: "Rentals",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Cars_CarId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentalEndDate",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "RentedForDays",
                table: "Rentals",
                newName: "RentalDay");

            migrationBuilder.RenameColumn(
                name: "RentalStartDate",
                table: "Rentals",
                newName: "RentalStartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalEndTime",
                table: "Rentals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
