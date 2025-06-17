using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bangun.Migrations
{
    /// <inheritdoc />
    public partial class TambahKolomSatuan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "satuan",
                table: "product",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "satuan",
                table: "product");
        }
    }
}
