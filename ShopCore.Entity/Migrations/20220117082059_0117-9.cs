using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopCore.Entity.Migrations
{
    public partial class _01179 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipAddresses_Users_UserId",
                table: "ShipAddresses");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User",
                table: "ShipAddresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_User",
                table: "ShipAddresses");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipAddresses_Users_UserId",
                table: "ShipAddresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
