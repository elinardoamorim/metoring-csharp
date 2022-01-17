using System;

namespace RestWithASPNET5.Data.VO
{
    public class BookAuthorVO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
