using bangun.Models;
using bangun.Enums;
using System.Text.Json.Serialization;

namespace bangun.Dtos
{
    public class CreateProductDto
    {
        public string Nama_Product { get; set; } = string.Empty;
        public int Harga { get; set; }
        public SatuanEnum SatuanBarang { get; set; }
    }

    public class ProyekUpdateDto
    {
        public string? Nama { get; set; }
        public bool IsSelesai { get; set; }

        public List<ProyekProductDto>? ProyekProducts { get; set; }

    }

    public class ProyekProductDto
    {
        public int ProductId { get; set; }
        public int Jumlah { get; set; }
        public SatuanEnum SatuanBarang { get; set; }


    }
    public class ProyekCreateDto
    {
        public int Id_Proyek { get; set; }
        public string? Nama { get; set; }
        public bool IsSelesai { get; set; }
        public List<ProyekProductDetilDto>? ProyekProducts { get; set; }

    }

    public class ProyekProductDetilDto
    {
        public int ProductId { get; set; }
        public string? NamaProduk { get; set; }
        public int Jumlah { get; set; }
        public SatuanEnum SatuanBarang { get; set; }

    }

}
