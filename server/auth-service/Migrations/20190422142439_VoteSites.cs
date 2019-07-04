using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class VoteSites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Site = table.Column<byte>(nullable: false),
                    UnsetDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => new { x.UserId, x.Site });
                    table.UniqueConstraint("AK_Votes_Site_UserId", x => new { x.Site, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "VoteSites",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    UnsetTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteSites", o => new { o.UserId, o.Site, o.UnsetTimer });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "VoteSites");
        }
    }
}
