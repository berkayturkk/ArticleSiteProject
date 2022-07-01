using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleSiteProject.DataAccess.Migrations
{
    public partial class mig_add_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleTitle = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ArticleContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleCategoryName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ArticleWriterName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ArticleCreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    ArticleUpdateDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
