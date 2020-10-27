using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Models
{
    public class UserItem
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public User User { get; set; }
        public Item Item { get; set; }
    }
}
