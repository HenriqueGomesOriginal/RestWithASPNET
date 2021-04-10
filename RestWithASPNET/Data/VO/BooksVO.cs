using RestWithASPNET.Hypermedia;
using RestWithASPNET.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestWithASPNET.Data.VO
{
    public class BooksVO : ISupportsHyperMedia
    {
        public string Id { get; set; }
        
        public string Author { get; set; }

        public DateTime Launch { get; set; }

        public float Price { get; set; }

        public string Title { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
