using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsmaneJuhilubaTARpe21JÕ.Data.Migrations
{
    public partial class bruh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Driving_Exam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Driving_Exam",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
