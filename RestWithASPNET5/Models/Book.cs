using RestWithASPNET5.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Models
{
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("author_id")]
        public long? AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
