using bangun.Enums;

namespace bangun.Dtos.ProyekDtos
{
    public class ProyekCreateDto
    {
        public string Nama { get; set; } = string.Empty;
        public bool IsSelesai { get; set; }
        public List<ProyekCreateProductDto> ProyekProducts { get; set; } = new();
    }

    public class ProyekCreateProductDto
    {
        public int ProductId { get; set; }
        public int Jumlah { get; set; }

    }
}
