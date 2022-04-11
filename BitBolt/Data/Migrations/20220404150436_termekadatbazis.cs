using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitBolt.Data.Migrations
{
    public partial class termekadatbazis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Termekek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Megnevezés = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gyáró = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Típus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeszerzésiÁr = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termekek", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Termekek");
        }
    }
}
