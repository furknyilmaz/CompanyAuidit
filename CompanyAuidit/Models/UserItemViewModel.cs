﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Models
{
    public class UserItemViewModel
    {
        public User User { get; set; }
        public List<Item> Items { get; set; }
    }
}
