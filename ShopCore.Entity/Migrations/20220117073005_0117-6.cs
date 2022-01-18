using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopCore.Entity.Migrations
{
    public partial class _01176 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Province",
                table: "ShipAddresses",
                newName: "Provinces");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "ShipAddresses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "ShipAddresses");

            migrationBuilder.RenameColumn(
                name: "Provinces",
                table: "ShipAddresses",
                newName: "Province");
        }
    }
}
