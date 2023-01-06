using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsmaneJuhilubaTARpe21JÕ.Data.Migrations
{
    public partial class Added_Age_So_People_Under_16_Couldnt_Register : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Driving_Exam",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Driving_Exam");
        }
    }
}
