using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAUAPI.Migrations
{
    public partial class Updatedusernamecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "OrderItem");

            migrationBuilder.AddColumn<string>(
                name: "BuyerName",
                table: "UserOrders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerName",
                table: "UserOrders");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
