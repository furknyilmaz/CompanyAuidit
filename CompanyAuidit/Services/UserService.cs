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
            var userItem =new UserItem{UserId=userId, ItemId=itemId };
            _context.UserItems.Remove(userItem);
            _context.SaveChanges();
        }

    }
}
