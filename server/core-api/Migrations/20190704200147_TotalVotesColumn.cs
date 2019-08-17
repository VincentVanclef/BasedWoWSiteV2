using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class TotalVotesColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TotalVotes",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "TotalVotes",
               table: "Users");
        }
    }
}
