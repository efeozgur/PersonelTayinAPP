using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonelTayin.Migrations
{
    /// <inheritdoc />
    public partial class GorevYeri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GorevYeri",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GorevYeri",
                table: "Personeller");
        }
    }
}
