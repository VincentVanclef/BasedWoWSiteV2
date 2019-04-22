using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class ExtraVoteData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "VoteSites",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Value",
                table: "VoteSites",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "VoteSites");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "VoteSites");
        }
    }
}
