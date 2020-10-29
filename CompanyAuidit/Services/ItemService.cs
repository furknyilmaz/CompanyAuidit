using CompanyAuidit.Contexts;
using CompanyAuidit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Services
{
    public class ItemService : BaseService<Item>
    {
        private readonly CompanyAuiditContext _context;
        public ItemService(CompanyAuiditContext context) : base(context)
        {
            _context = context;
        }

        public List<Item> GetItems()
        {
            var result = _context.Items.Include(x => x.ItemType).ThenInclude(x => x.Category).ToList();
            return result;
        }

    }
}
