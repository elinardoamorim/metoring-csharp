using RestWithASPNET5.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Models
{
    [Table("book")]
    public class Book : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }
        [Column("author")]
        public string author { get; set; }
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
    }
}
