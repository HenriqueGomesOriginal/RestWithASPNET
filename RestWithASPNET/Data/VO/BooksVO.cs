using System;

namespace RestWithASPNET.Data.VO
{
    public class BooksVO
    {
        public string Id { get; set; }
        
        public string Author { get; set; }

        public DateTime Launch { get; set; }

        public float Price { get; set; }

        public string Title { get; set; }
    }
}
