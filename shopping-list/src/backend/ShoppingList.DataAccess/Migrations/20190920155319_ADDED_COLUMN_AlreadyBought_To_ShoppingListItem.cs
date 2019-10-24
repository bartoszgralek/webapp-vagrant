using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.DataAccess.Migrations
{
    public partial class ADDED_COLUMN_AlreadyBought_To_ShoppingListItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AlreadyBought",
                table: "ShoppingListItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlreadyBought",
                table: "ShoppingListItems");
        }
    }
}
