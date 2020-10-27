using CompanyAuidit.Contexts;
using CompanyAuidit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Services
{
    public class CategoryService : BaseService<Category>
    {
        private readonly CompanyAuiditContext _context;
        public CategoryService(CompanyAuiditContext context) : base(context)
        {
            _context = context;
        }

    }
}
