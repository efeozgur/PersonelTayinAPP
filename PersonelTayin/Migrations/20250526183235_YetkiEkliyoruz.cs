using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonelTayin.Migrations
{
    /// <inheritdoc />
    public partial class YetkiEkliyoruz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Yetki",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Yetki",
                table: "Personeller");
        }
    }
}
