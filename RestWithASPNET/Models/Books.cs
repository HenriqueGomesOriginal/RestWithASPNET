using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Models
{
    [Table("books")]
    public class Books
    {
        [Column("id")]
        public string Id { get; set; }
        
        [Column("author")]
        public string Author { get; set; }

        [Column("launch_date")]
        public DateTime Launch { get; set; }

        [Column("price")]
        public float Price { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}
