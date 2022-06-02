using Microsoft.EntityFrameworkCore.Migrations;

namespace AmericaHospital.DAL.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "FirstName", "JobCategoryId", "LastName" },
                values: new object[] { 1, "Rodrigo", 0, "Fuentes" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "FirstName", "JobCategoryId", "LastName" },
                values: new object[] { 2, "Erwin", 0, "Fuentes" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "FirstName", "JobCategoryId", "LastName" },
                values: new object[] { 3, "Pedro", 0, "Fuentes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
