using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.WebAPI.Models
{
    [Table("herobattle")]
    public class HeroBattle
    {
        [Column("heroid")]
        public int HeroId { get; set; }
        [Column("hero")]
        public Hero Hero { get; set; }
        [Column("battleid")]
        public int BattleId { get; set; }
        [Column("battle")]
        public Battle Battle { get; set; }
    }
}
