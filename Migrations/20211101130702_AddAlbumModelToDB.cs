using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2_Images.Migrations
{
    public partial class AddAlbumModelToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbumID",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlbumID",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uploader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrantedAcessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Album_User_GrantedAcessId",
                        column: x => x.GrantedAcessId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageUser",
                columns: table => new
                {
                    CollectionID = table.Column<int>(type: "int", nullable: false),
                    GrantedAccessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUser", x => new { x.CollectionID, x.GrantedAccessId });
                    table.ForeignKey(
                        name: "FK_ImageUser_Image_CollectionID",
                        column: x => x.CollectionID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageUser_User_GrantedAccessId",
                        column: x => x.GrantedAccessId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_AlbumID",
                table: "User",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_AlbumID",
                table: "Image",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Album_GrantedAcessId",
                table: "Album",
                column: "GrantedAcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUser_GrantedAccessId",
                table: "ImageUser",
                column: "GrantedAccessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Album_AlbumID",
                table: "Image",
                column: "AlbumID",
                principalTable: "Album",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Album_AlbumID",
                table: "User",
                column: "AlbumID",
                principalTable: "Album",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Album_AlbumID",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Album_AlbumID",
                table: "User");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "ImageUser");

            migrationBuilder.DropIndex(
                name: "IX_User_AlbumID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Image_AlbumID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "AlbumID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AlbumID",
                table: "Image");
        }
    }
}
