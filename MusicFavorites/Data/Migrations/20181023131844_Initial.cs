using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicFavorites.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FavoriteAlbum",
                columns: table => new
                {
                    FavoriteAlbumId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlbumURL = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    ApplicationUserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteAlbum", x => x.FavoriteAlbumId);
                    table.ForeignKey(
                        name: "FK_FavoriteAlbum_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteArtist",
                columns: table => new
                {
                    FavoriteArtistId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtistURL = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    ApplicationUserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteArtist", x => x.FavoriteArtistId);
                    table.ForeignKey(
                        name: "FK_FavoriteArtist_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteSong",
                columns: table => new
                {
                    FavoriteSongId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SongURL = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    ApplicationUserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteSong", x => x.FavoriteSongId);
                    table.ForeignKey(
                        name: "FK_FavoriteSong_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteAlbum_ApplicationUserId1",
                table: "FavoriteAlbum",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteArtist_ApplicationUserId1",
                table: "FavoriteArtist",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteSong_ApplicationUserId1",
                table: "FavoriteSong",
                column: "ApplicationUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteAlbum");

            migrationBuilder.DropTable(
                name: "FavoriteArtist");

            migrationBuilder.DropTable(
                name: "FavoriteSong");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "AspNetUsers");
        }
    }
}
