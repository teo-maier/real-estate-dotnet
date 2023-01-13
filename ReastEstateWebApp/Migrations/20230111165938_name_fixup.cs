using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReastEstateWebApp.Migrations
{
    /// <inheritdoc />
    public partial class namefixup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageDate",
                table: "Property",
                newName: "ImageData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageData",
                table: "Property",
                newName: "ImageDate");
        }
    }
}
