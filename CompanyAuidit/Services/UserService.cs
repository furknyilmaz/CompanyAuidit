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
    }
}
