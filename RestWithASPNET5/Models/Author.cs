using RestWithASPNET5.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Models
{
    [Table("authors")]
    public class Author : BaseEntity
    {
        [Column("cpf")]
        public string CPF { get; set; }
        [Column("first_name")]
        public string Name { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        public List<Book> Books { get; set; }
    }
}
