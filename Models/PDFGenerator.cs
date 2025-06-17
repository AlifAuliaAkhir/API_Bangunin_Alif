using bangun.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace bangun.Helpers
{
    public static class PDFGenerator
    {
        public static byte[] Generate(Proyek proyek)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    page.Header()
                        .Text($"Laporan Proyek: {proyek.Nama}")
                        .FontSize(20)
                        .Bold();

                    page.Content().Column(column =>
                    {
                        column.Spacing(10);

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3); // Nama
                                columns.RelativeColumn();  // Satuan
                                columns.RelativeColumn();  // Harga
                                columns.RelativeColumn();  // Jumlah
                                columns.RelativeColumn();  // Subtotal
                            });

                            // Header
                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("Nama Produk");
                                header.Cell().Element(CellStyle).Text("Satuan Barang");
                                header.Cell().Element(CellStyle).Text("Harga");
                                header.Cell().Element(CellStyle).Text("Jumlah");
                                header.Cell().Element(CellStyle).Text("Subtotal");

                                static IContainer CellStyle(IContainer container) =>
                                    container
                                        .DefaultTextStyle(x => x.SemiBold())
                                        .Padding(5)
                                        .Background(Colors.Grey.Lighten2);
                            });

                            // Data + Total
                            int totalHarga = 0;

                            foreach (var item in proyek.ProyekProducts)
                            {
                                var harga = item.Product?.Harga ?? 0;
                                var jumlah = item.Jumlah;
                                var subtotal = harga * jumlah;
                                totalHarga += subtotal;

                                table.Cell().Padding(5).Text(item.Product?.Nama_Product ?? "-");
                                table.Cell().Padding(5).Text(item.Product?.SatuanBarang?.ToString() ?? "-");
                                table.Cell().Padding(5).Text($"Rp{harga:N0}");
                                table.Cell().Padding(5).Text(jumlah.ToString());
                                table.Cell().Padding(5).Text($"Rp{subtotal:N0}");
                            }

                            // Baris total
                            table.Cell().ColumnSpan(4).PaddingTop(10).AlignRight().Text("Total Harga:").SemiBold();
                            table.Cell().PaddingTop(10).Text($"Rp{totalHarga:N0}").SemiBold();
                        });
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text($"Tanggal Cetak: {DateTime.Now:dd-MM-yyyy}");
                });
            }).GeneratePdf();
        }
    }
}
