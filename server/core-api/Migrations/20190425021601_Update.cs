using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DP",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VP",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "Online",
                table: "Users",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Online",
                table: "Users");

            migrationBuilder.AddColumn<short>(
                name: "DP",
                table: "Users",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "VP",
                table: "Users",
                nullable: false,
                defaultValue: (short)0);

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
    }
}
