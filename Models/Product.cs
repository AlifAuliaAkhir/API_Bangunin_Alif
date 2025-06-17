using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bangun.Enums;


namespace bangun.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("id_product")]
        public int Id_Product { get; set; }

        [Required]
        [Column("nama_product")]
        public string Nama_Product { get; set; } = string.Empty;

        [Required]
        [Column("harga")]
        public int Harga { get; set; }

        [Required]
        [Column("satuanbarang")]
        public string? SatuanBarang { get; set; }


        public List<ProyekProduct> ProyekProducts { get; set; } = new();
    }
}
