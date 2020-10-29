using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Models
{
    //FURKAN ZEREY -- Kullanıcı ile eşyayı ilişkilendirmek için kullanıldı.
    public class UserItemViewModel
    {
        public User User { get; set; }
        public List<Item> Items { get; set; }
    }
}
