using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.WebAPI.Models
{
    [Table("hero")]
    public class Hero
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("identity")]
        public SecretIdentity Identity { get; set; }
        [Column("weapons")]
        public List<Weapon> Weapons { get; set; }
        [Column("heroesbattles")]
        public List<HeroBattle> HeroesBattles { get; set; }
    }
}
