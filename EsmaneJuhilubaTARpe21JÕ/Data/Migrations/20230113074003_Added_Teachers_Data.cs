using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsmaneJuhilubaTARpe21JÕ.Data.Migrations
{
    public partial class Added_Teachers_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherFirstname",
                table: "Driving_Exam",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeacherLastname",
                table: "Driving_Exam",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeachersCertificateNumber",
                table: "Driving_Exam",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherFirstname",
                table: "Driving_Exam");

            migrationBuilder.DropColumn(
                name: "TeacherLastname",
                table: "Driving_Exam");

            migrationBuilder.DropColumn(
                name: "TeachersCertificateNumber",
                table: "Driving_Exam");
        }
    }
}
