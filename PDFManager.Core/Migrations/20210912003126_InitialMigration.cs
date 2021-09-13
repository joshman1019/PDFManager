using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PDFManager.Core.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PDFDocuments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DocumentDescription = table.Column<string>(type: "TEXT", nullable: true),
                    DocumentAuthor = table.Column<string>(type: "TEXT", nullable: true),
                    DocumentBytes = table.Column<byte[]>(type: "BLOB", nullable: true),
                    DocumentStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    DocumentVisibility = table.Column<int>(type: "INTEGER", nullable: false),
                    Archived = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PDFDocuments", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PDFDocuments");
        }
    }
}
