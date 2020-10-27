using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Models
{
    public class RelationListViewModel
    {
        public Item Item { get; set; }
        public User User { get; set; }
        public List<Item> Items { get; set; }
        public List<Item> ItemsList { get; set; }
        public List<User> Users { get; set; }
    }
}
