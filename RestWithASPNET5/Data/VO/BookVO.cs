using RestWithASPNET5.Hypermedia;
using RestWithASPNET5.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestWithASPNET5.Data.VO
{
    public class BookVO : ISupportsHyperMedia
    {
        //[XmlElement("code")]
        //[JsonPropertyName("code")]
        public long Id { get; set; }
        //[XmlElement("title")]
        //[JsonPropertyName("title")]
        public string Title { get; set; }
        //[XmlElement("price")]
        //[JsonPropertyName("price")]
        public decimal Price { get; set; }
        //[XmlElement("launch_date")]
        //[JsonPropertyName("lauch_date")]
        public DateTime LaunchDate { get; set; }
        //[XmlElement("author")]
        //[JsonPropertyName("author")]
        public AuthorVO Author { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
