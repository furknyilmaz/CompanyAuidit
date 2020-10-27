using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAuidit.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAuidit.Controllers
{
    public class RelationController : Controller
    {
        private readonly UserItemService _userItem;
        public RelationController(UserItemService userItem)
        {
            _userItem = userItem;
        }

        public IActionResult Index(int userId)
        {
            return View(_userItem.GetUserItemList(userId));
        }
    }
}
