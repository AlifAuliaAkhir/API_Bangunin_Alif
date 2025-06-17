using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bangun.Models
{
    [Table("proyek")]
    public class Proyek
    {
        [Key]
        [Column("id_proyek")]
        public int Id { get; set; }

        [Required]
        [Column("nama")]
        public string Nama { get; set; } = string.Empty;

        [Required]
        [Column("is_selesai")]
        public bool IsSelesai { get; set; }

        public List<ProyekProduct> ProyekProducts { get; set; } = new();
    }
}
