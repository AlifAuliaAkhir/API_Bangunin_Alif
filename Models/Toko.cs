using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bangun.Models
{
    [Table("toko")]
    public class Toko
    {
        [Key]
        [Column("id_toko")]
        public int IdToko { get; set; }

        [Required]
        [Column("nama_toko")]
        public string? NamaToko { get; set; }

        [Required]
        [Column("latitude")]
        public double Latitude { get; set; }

        [Required]
        [Column("longitude")]
        public double Longitude { get; set; }
    }
}
