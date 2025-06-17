using bangun.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bangun.Models
{
    [Table("person")]
    public class User
    {
        [Key]
        [Column("id_person")]
        public int Id { get; set; }

        [Column("nama")]
        public string? Nama { get; set; }

        [Column("password")]
        public string? Password { get; set; }

        [Column("role")]
        public UserRole Role { get; set; } = UserRole.User;
    }

}
