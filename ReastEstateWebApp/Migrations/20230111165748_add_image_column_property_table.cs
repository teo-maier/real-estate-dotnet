using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReastEstateWebApp.Migrations
{
    /// <inheritdoc />
    public partial class addimagecolumnpropertytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Agent_AgentId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Client_ClientId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Property_PropertyId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_PropertyId",
                table: "Sale");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "Sale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Sale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Sale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ImageDate",
                table: "Property",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_PropertyId",
                table: "Sale",
                column: "PropertyId",
                unique: true,
                filter: "[PropertyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Agent_AgentId",
                table: "Sale",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Client_ClientId",
                table: "Sale",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Property_PropertyId",
                table: "Sale",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Agent_AgentId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Client_ClientId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Property_PropertyId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_PropertyId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ImageDate",
                table: "Property");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_PropertyId",
                table: "Sale",
                column: "PropertyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Agent_AgentId",
                table: "Sale",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Client_ClientId",
                table: "Sale",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Property_PropertyId",
                table: "Sale",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
