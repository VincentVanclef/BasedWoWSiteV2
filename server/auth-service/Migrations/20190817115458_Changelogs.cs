using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class Changelogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangelogCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangelogCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "unstuck_locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    realmId = table.Column<sbyte>(type: "tinyint(3)", nullable: false, defaultValueSql: "0"),
                    position_x = table.Column<float>(type: "float unsigned", nullable: false, defaultValueSql: "0"),
                    position_y = table.Column<float>(type: "float unsigned", nullable: false, defaultValueSql: "0"),
                    position_z = table.Column<float>(type: "float unsigned", nullable: false, defaultValueSql: "0"),
                    map = table.Column<short>(type: "float unsigned", nullable: false, defaultValueSql: "0"),
                    name = table.Column<string>(type: "text unsigned", nullable: true, defaultValueSql: "Unknown")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unstuck_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Changelogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Realm = table.Column<byte>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CategoryId = table.Column<byte>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CategoryId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Changelogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Changelogs_ChangelogCategories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "ChangelogCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Changelogs_CategoryId1",
                table: "Changelogs",
                column: "CategoryId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Changelogs");

            migrationBuilder.DropTable(
                name: "unstuck_locations");

            migrationBuilder.DropTable(
                name: "ChangelogCategories");
        }
    }
}
