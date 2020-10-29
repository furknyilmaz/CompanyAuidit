using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Models
{
    public class ItemListViewModel
    {
        public List<Item> Items { get; set; }
        public Category Category { get; set; }

        //FURKAN ZEREY -- User'a ulaşmak için eklendi
        public List<User> User { get; set; }
    }
}
