using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsmaneJuhilubaTARpe21JÕ.Data.Migrations
{
    public partial class scaffolded_Driving_Exam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Driving_Exam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Driving_School = table.Column<int>(type: "int", nullable: true),
                    Theory_Exam = table.Column<int>(type: "int", nullable: true),
                    Driving_Test = table.Column<int>(type: "int", nullable: true),
                    License = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driving_Exam", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Driving_Exam");
        }
    }
}
