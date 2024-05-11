using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressionsForEF.Migrations
{
    /// <inheritdoc />
    public partial class AddCashColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cash",
                table: "Users",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cash",
                table: "Users");
        }
    }
}
