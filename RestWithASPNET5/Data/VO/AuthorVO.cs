using System.Collections.Generic;

namespace RestWithASPNET5.Data.VO
{
    public class AuthorVO
    {
        public long Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<BookAuthorVO> Books { get; set; }

    }
}
