using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopCore.Entity.Migrations
{
    public partial class _2201131 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Goods");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Goods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoodsImg",
                table: "Goods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SKU",
                columns: table => new
                {
                    SKUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsId = table.Column<int>(type: "int", nullable: false),
                    TasteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKU", x => x.SKUID);
                });

            migrationBuilder.CreateTable(
                name: "Tastes",
                columns: table => new
                {
                    TasteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TasteName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tastes", x => x.TasteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SKU");

            migrationBuilder.DropTable(
                name: "Tastes");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "GoodsImg",
                table: "Goods");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Goods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
