using Microsoft.EntityFrameworkCore.Migrations;

namespace PDFManager.Core.Migrations
{
    public partial class DocumentIdentificationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentificationString",
                table: "PDFDocuments",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentificationString",
                table: "PDFDocuments");
        }
    }
}
