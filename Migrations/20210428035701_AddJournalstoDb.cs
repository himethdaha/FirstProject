using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPage.Migrations
{
    public partial class AddJournalstoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "journal",
                columns: table => new
                {
                    EntryID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntryName = table.Column<string>(nullable: false),
                    EntryDescription = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    StarredEntry = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_journal", x => x.EntryID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "journal");
        }
    }
}
