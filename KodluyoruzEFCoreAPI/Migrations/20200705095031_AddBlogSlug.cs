using Microsoft.EntityFrameworkCore.Migrations;

namespace KodluyoruzEFCoreAPI.Migrations
{
    public partial class AddBlogSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "slug",
                table: "Blogs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slug",
                table: "Blogs");
        }
    }
}
