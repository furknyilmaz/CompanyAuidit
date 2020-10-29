using CompanyAuidit.Contexts;
using CompanyAuidit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Services
{
    public class UserService : BaseService<User>
    {
        private readonly CompanyAuiditContext _context;
        public UserService(CompanyAuiditContext context) : base(context)
        {
            _context = context;
        }

        public override void Delete(User user,int userId)
        {

            var items = _context.UserItems.Where(x => x.UserId == userId).ToList();
            _context.UserItems.RemoveRange(items);

            base.Delete(user,userId);
        }

        public User Items(int userId)
        {
            return _context.Users
                .Include(x => x.UserItems)
                .ThenInclude(x => x.Item)
                .ThenInclude(x => x.ItemType)
                .ThenInclude(x => x.Category)
                .FirstOrDefault(user => user.Id == userId);
        }

        public void ItemDelete(int userId, int itemId)
        {
            var userItem = new UserItem { UserId = userId, ItemId = itemId };
            _context.UserItems.Remove(userItem);
            _context.SaveChanges();
        }

        public void ItemCreate(int userId, int itemId)
        {
            var result = new UserItem { UserId = userId, ItemId = itemId };
            _context.UserItems.Add(result);
            _context.SaveChanges();
        }
    }
}
