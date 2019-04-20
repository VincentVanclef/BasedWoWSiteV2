using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class IngameAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngameAccounts",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngameAccounts", x => new { x.UserId, x.AccountId });
                    table.UniqueConstraint("AK_IngameAccounts_AccountId_UserId", x => new { x.AccountId, x.UserId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngameAccounts");
        }
    }
}
