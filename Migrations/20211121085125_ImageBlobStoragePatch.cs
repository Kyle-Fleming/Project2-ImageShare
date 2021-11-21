using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2_Images.Migrations
{
    public partial class ImageBlobStoragePatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvertisementAsset",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Image");

            migrationBuilder.AddColumn<byte[]>(
                name: "AdvertisementAsset",
                table: "Image",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
