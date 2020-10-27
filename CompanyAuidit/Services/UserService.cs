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

       
    }
}
