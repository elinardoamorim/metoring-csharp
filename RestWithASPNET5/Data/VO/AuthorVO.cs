using RestWithASPNET5.Hypermedia;
using RestWithASPNET5.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWithASPNET5.Data.VO
{
    public class AuthorVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
