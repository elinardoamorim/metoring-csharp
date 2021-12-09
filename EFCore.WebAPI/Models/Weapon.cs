using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.WebAPI.Models
{
    [Table("weapon")]
    public class Weapon
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("hero")]
        public Hero Hero { get; set; }
        [Column("heroid")]
        public int HeroId { get; set; }

    }
}
