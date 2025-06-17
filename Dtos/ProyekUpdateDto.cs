namespace bangun.Dtos.ProyekDtos
{
    public class ProyekUpdateDto
    {
        public bool IsSelesai { get; set; }
        public List<ProyekCreateProductDto> ProyekProducts { get; set; } = new();
    }
}
