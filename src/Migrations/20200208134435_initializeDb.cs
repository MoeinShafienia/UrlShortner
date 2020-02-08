using Microsoft.EntityFrameworkCore.Migrations;

namespace src.Migrations
{
    public partial class initializeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "urls",
                columns: table => new
                {
                    ShortUrl = table.Column<string>(nullable: false),
                    LongUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urls", x => x.ShortUrl);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "urls");
        }
    }
}
