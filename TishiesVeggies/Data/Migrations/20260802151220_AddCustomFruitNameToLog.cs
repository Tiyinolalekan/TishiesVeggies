using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TishiesVeggies.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomFruitNameToLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomFruitName",
                table: "Logs",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomFruitName",
                table: "Logs");
        }
    }
}
