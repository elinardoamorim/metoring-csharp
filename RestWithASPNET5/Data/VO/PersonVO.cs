﻿using RestWithASPNET5.Hypermedia;
using RestWithASPNET5.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWithASPNET5.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        //[XmlElement("code")]
        //[JsonPropertyName("code")]
        public long Id { get; set; }
        //[XmlElement("name")]
        //[JsonPropertyName("name")]
        public string FirstName { get; set; }
        //[XmlElement("last_name")]
        //[JsonPropertyName("last_name")]
        public string LastName { get; set; }
        //[XmlIgnore]
        //[JsonIgnore]
        public string Address { get; set; }
        //[XmlElement("gender")]
        //[JsonPropertyName("gender")]
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
