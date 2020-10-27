using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Models
{
    public class ItemType:BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
