using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.WebAPI.Models
{
    [Table("battle")]
    public class Battle
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("start_date")]
        public DateTime DtStart { get; set; }
        [Column("final_date")]
        public DateTime DtFinal { get; set; }
        [Column("heroes_battles")]
        public List<HeroBattle> HerosBattles { get; set; }

    }
}
