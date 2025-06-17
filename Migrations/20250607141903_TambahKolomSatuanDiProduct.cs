using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bangun.Migrations
{
    /// <inheritdoc />
    public partial class TambahKolomSatuanDiProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyekProducts_Products_ProductId",
                table: "ProyekProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyekProducts_Proyeks_ProyekId",
                table: "ProyekProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proyeks",
                table: "Proyeks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProyekProducts",
                table: "ProyekProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Proyeks",
                newName: "proyek");

            migrationBuilder.RenameTable(
                name: "ProyekProducts",
                newName: "proyekproduct");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "product");

            migrationBuilder.RenameColumn(
                name: "Nama",
                table: "proyek",
                newName: "nama");

            migrationBuilder.RenameColumn(
                name: "Id_Proyek",
                table: "proyek",
                newName: "id_proyek");

            migrationBuilder.RenameColumn(
                name: "IsSelesai",
                table: "proyek",
                newName: "is_selesai");

            migrationBuilder.RenameColumn(
                name: "Jumlah",
                table: "proyekproduct",
                newName: "jumlah");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "proyekproduct",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProyekId",
                table: "proyekproduct",
                newName: "proyek_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "proyekproduct",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProyekProducts_ProyekId",
                table: "proyekproduct",
                newName: "IX_proyekproduct_proyek_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProyekProducts_ProductId",
                table: "proyekproduct",
                newName: "IX_proyekproduct_product_id");

            migrationBuilder.RenameColumn(
                name: "Nama_Product",
                table: "product",
                newName: "nama_product");

            migrationBuilder.RenameColumn(
                name: "Harga",
                table: "product",
                newName: "harga");

            migrationBuilder.RenameColumn(
                name: "Id_Product",
                table: "product",
                newName: "id_product");

            migrationBuilder.AddColumn<string>(
                name: "satuan",
                table: "product",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_proyek",
                table: "proyek",
                column: "id_proyek");

            migrationBuilder.AddPrimaryKey(
                name: "PK_proyekproduct",
                table: "proyekproduct",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "id_product");

            migrationBuilder.AddForeignKey(
                name: "FK_proyekproduct_product_product_id",
                table: "proyekproduct",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id_product",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_proyekproduct_proyek_proyek_id",
                table: "proyekproduct",
                column: "proyek_id",
                principalTable: "proyek",
                principalColumn: "id_proyek",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_proyekproduct_product_product_id",
                table: "proyekproduct");

            migrationBuilder.DropForeignKey(
                name: "FK_proyekproduct_proyek_proyek_id",
                table: "proyekproduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_proyekproduct",
                table: "proyekproduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_proyek",
                table: "proyek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropColumn(
                name: "satuan",
                table: "product");

            migrationBuilder.RenameTable(
                name: "proyekproduct",
                newName: "ProyekProducts");

            migrationBuilder.RenameTable(
                name: "proyek",
                newName: "Proyeks");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "jumlah",
                table: "ProyekProducts",
                newName: "Jumlah");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProyekProducts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "proyek_id",
                table: "ProyekProducts",
                newName: "ProyekId");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "ProyekProducts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_proyekproduct_proyek_id",
                table: "ProyekProducts",
                newName: "IX_ProyekProducts_ProyekId");

            migrationBuilder.RenameIndex(
                name: "IX_proyekproduct_product_id",
                table: "ProyekProducts",
                newName: "IX_ProyekProducts_ProductId");

            migrationBuilder.RenameColumn(
                name: "nama",
                table: "Proyeks",
                newName: "Nama");

            migrationBuilder.RenameColumn(
                name: "id_proyek",
                table: "Proyeks",
                newName: "Id_Proyek");

            migrationBuilder.RenameColumn(
                name: "is_selesai",
                table: "Proyeks",
                newName: "IsSelesai");

            migrationBuilder.RenameColumn(
                name: "nama_product",
                table: "Products",
                newName: "Nama_Product");

            migrationBuilder.RenameColumn(
                name: "harga",
                table: "Products",
                newName: "Harga");

            migrationBuilder.RenameColumn(
                name: "id_product",
                table: "Products",
                newName: "Id_Product");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProyekProducts",
                table: "ProyekProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proyeks",
                table: "Proyeks",
                column: "Id_Proyek");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id_Product");

            migrationBuilder.AddForeignKey(
                name: "FK_ProyekProducts_Products_ProductId",
                table: "ProyekProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id_Product",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyekProducts_Proyeks_ProyekId",
                table: "ProyekProducts",
                column: "ProyekId",
                principalTable: "Proyeks",
                principalColumn: "Id_Proyek",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
