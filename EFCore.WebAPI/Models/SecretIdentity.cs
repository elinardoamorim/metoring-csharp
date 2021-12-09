using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.WebAPI.Models
{
    [Table("secretidentity")]
    public class SecretIdentity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("namreal")]
        public int NameReal { get; set; }
        [Column("heroid")]
        public int HeroId { get; set; }
        [Column("hero")]
        public Hero Hero { get; set; }
    }
}
