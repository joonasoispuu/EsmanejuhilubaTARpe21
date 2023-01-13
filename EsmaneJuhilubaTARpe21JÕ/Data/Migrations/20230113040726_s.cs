using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsmaneJuhilubaTARpe21JÕ.Data.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Driving_Test_Date",
                table: "Driving_Exam",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Driving_Test_Driving_Hours",
                table: "Driving_Exam",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Driving_Exam",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Driving_Test_Date",
                table: "Driving_Exam");

            migrationBuilder.DropColumn(
                name: "Driving_Test_Driving_Hours",
                table: "Driving_Exam");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Driving_Exam");
        }
    }
}
