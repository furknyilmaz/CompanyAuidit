using CompanyAuidit.Contexts;
using CompanyAuidit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Services
{
    public class UserItemService : BaseService<UserItem>
    {
        private readonly CompanyAuiditContext _context;

        public UserItemService(CompanyAuiditContext context) : base(context)
        {
            _context = context;
        }

        public RelationListViewModel GetUserItemList(int userId)
        {
            var items = (from user in _context.Users
                               where user.Id == userId
                               join useritem in _context.UserItems on user.Id equals useritem.UserId
                               join item in _context.Items on useritem.ItemId equals item.Id
                               join itemtype in _context.ItemTypes on item.ItemTypeId equals itemtype.Id
                               join category in _context.Categories on itemtype.CategoryId equals category.Id
                               select item)
                                          .ToList();

            var userr = _context.Users.FirstOrDefault(x => x.Id == userId);

            var itemlist = _context.Items.ToList();

            var model = new RelationListViewModel
            {
                Items = items,
                User = userr,
                ItemsList = itemlist
            };

            return model;
        }
    }
}
