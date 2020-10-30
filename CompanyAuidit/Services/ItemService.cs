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

        
        public void UserCreate(int userId, int itemId)
        {
            var result = new UserItem { UserId = userId, ItemId = itemId };
            _context.UserItems.Add(result);
            _context.SaveChanges();
        }

        public List<Item> GetItemType()
        {
            return _context.Items.Include(x => x.ItemType).ToList();
        }

    }
}
