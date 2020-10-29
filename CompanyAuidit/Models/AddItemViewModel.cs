using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyAuidit.Models
{
    public class AddItemViewModel
    {
        public Item Item { get; set; }
        public ItemType ItemType { get; set; }
        public List<Category> Categories { get; set; }
        public SelectList CategorySelectList { get; set; }
        public string CategoryId { get; set; }
    }
}
