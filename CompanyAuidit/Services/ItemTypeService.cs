using CompanyAuidit.Contexts;
using CompanyAuidit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Services
{
    public class ItemTypeService : BaseService<ItemType>
    {
        private readonly CompanyAuiditContext _context;
        public ItemTypeService(CompanyAuiditContext context) : base(context)
        {
            _context = context;
        }

    }
}
