using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "changelog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    realm = table.Column<sbyte>(type: "tinyint(3)", nullable: false, defaultValueSql: "0"),
                    title = table.Column<string>(type: "text", nullable: true, defaultValueSql: "0"),
                    content = table.Column<string>(type: "text", nullable: true, defaultValueSql: "0"),
                    category = table.Column<sbyte>(type: "tinyint(3)", nullable: false, defaultValueSql: "0"),
                    date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_changelog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "changelog_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "text", nullable: true, defaultValueSql: "title"),
                    color = table.Column<string>(type: "text", nullable: true, defaultValueSql: "ffffff")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_changelog_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    author = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(type: "text", nullable: true, defaultValueSql: "title"),
                    content = table.Column<string>(type: "text", nullable: true, defaultValueSql: "title"),
                    image = table.Column<string>(type: "text", nullable: true, defaultValueSql: "https://avatarfiles.alphacoders.com/151/151182.jpg"),
                    date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 255, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shoutbox",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user = table.Column<Guid>(nullable: false),
                    message = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoutbox", x => x.id);
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
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 255, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 255, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 16, nullable: true),
                    Lastname = table.Column<string>(maxLength: 16, nullable: true),
                    Online = table.Column<byte>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    TotalVotes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Site = table.Column<byte>(nullable: false),
                    UnsetTimer = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => new { x.UserId, x.Site, x.UnsetTimer });
                    table.UniqueConstraint("AK_Votes_Site_UnsetTimer_UserId", x => new { x.Site, x.UnsetTimer, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "VoteSites",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Value = table.Column<byte>(nullable: false),
                    UnsetTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteSites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "news_comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<Guid>(nullable: false),
                    newsId = table.Column<int>(type: "int(10) unsigned", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true, defaultValueSql: "no comment"),
                    date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    lastEdited = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_news_comments_news_newsId",
                        column: x => x.newsId,
                        principalTable: "news",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 255, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 255, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(maxLength: 255, nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_news_comments_newsId",
                table: "news_comments",
                column: "newsId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "changelog");

            migrationBuilder.DropTable(
                name: "changelog_categories");

            migrationBuilder.DropTable(
                name: "news_comments");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "shoutbox");

            migrationBuilder.DropTable(
                name: "unstuck_locations");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "VoteSites");

            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
