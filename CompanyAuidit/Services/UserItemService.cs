using CompanyAuidit.Contexts;
using CompanyAuidit.Models;
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
    }
}
