using RestWithASPNET.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Models
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("last")]
        public string LastName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("gender")]
        public string Gender { get; set; }
    }
}
