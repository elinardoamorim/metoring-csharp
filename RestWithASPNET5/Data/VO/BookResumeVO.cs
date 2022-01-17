using System;

namespace RestWithASPNET5.Data.VO
{
    public class BookResumeVO
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
        public BaseIdVO Author { get; set; }
    }
}
