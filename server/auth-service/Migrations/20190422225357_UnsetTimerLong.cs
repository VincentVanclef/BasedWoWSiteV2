using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class UnsetTimerLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnsetDate",
                table: "Votes");

            migrationBuilder.AddColumn<ulong>(
                name: "UnsetTimer",
                table: "Votes",
                nullable: false,
                defaultValue: 0ul);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnsetTimer",
                table: "Votes");

            migrationBuilder.AddColumn<DateTime>(
                name: "UnsetDate",
                table: "Votes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
