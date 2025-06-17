using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bangun.Models
{
    [Table("proyekproduct")]
    public class ProyekProduct
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("proyek_id")]
        public int ProyekId { get; set; }
        public Proyek? Proyek { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Column("jumlah")]
        public int Jumlah { get; set; }

    }
}
