using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReastEstateWebApp.Migrations
{
    /// <inheritdoc />
    public partial class changepropertyTypecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PropertyType",
                table: "PropertyStatus",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PropertyType",
                table: "PropertyStatus",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
