using bangun.Enums;

namespace bangun.Dtos.ProyekDtos
{
    public class ProyekReadDto
    {
        public int Id { get; set; }
        public string Nama { get; set; } = string.Empty;
        public bool IsSelesai { get; set; }
        public List<ProyekProductDetailDto> ProyekProducts { get; set; } = new();
    }

    public class ProyekProductDetailDto
    {
        public int ProductId { get; set; }
        public string NamaProduk { get; set; } = string.Empty;
        public int Harga { get; set; }
        public int Jumlah { get; set; }
        public SatuanEnum SatuanBarang { get; set; }
    }
}
