using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bangun.Migrations
{
    /// <inheritdoc />
    public partial class AddSatuanToProduc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "satuan",
                table: "product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "satuan",
                table: "product",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
