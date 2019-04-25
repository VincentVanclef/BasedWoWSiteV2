using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class UlongToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UnsetTimer",
                table: "Votes",
                nullable: false,
                oldClrType: typeof(ulong));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DP",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VP",
                table: "Users");

            migrationBuilder.AlterColumn<ulong>(
                name: "UnsetTimer",
                table: "Votes",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
