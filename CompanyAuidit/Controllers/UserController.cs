using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CompanyAuidit.Contexts;
using CompanyAuidit.Models;
using CompanyAuidit.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAuidit.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly ItemService _itemService;
        private readonly UserItemService _userItemService;

        public UserController(UserService userService, ItemService itemService, UserItemService userItemService)
        {
            _userService = userService;
            _itemService = itemService;
            _userItemService = userItemService;
        }

        [HttpGet]
        public IActionResult SaveUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveUser(User model,bool @return)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Department = model.Department,
                    Mission = model.Mission
                };

                _userService.Add(user);
            }

            if (@return)
                return RedirectToAction(nameof(UserList));
            return View();

        }

        public IActionResult UserList()
        {
            var result = _userService.GetAll();
            return View(result);
        }
        
        [HttpPost]
        public IActionResult UserUpdate(User model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Department = model.Department,
                    Mission = model.Mission

                };
                TempData["UserMessage"] = @$"Kullanıcı {user.FirstName} {user.LastName} güncellendi";
                _userService.Update(user);
            }

            return RedirectToAction(nameof(UserList));
        }

        //FURKAN ZEREY -- Silme işlemine müdahale edildi.
        public IActionResult Delete(int userId)
        {
            var user = new User { Id = userId };
            _userService.Delete(user,userId);

            return RedirectToAction(nameof(UserList));
        }

        [HttpGet]
        public IActionResult UserUpdate(int id)
        {
            var result = _userService.GetAll().FirstOrDefault(x => x.Id == id);

            var user = new User();

            if (ModelState.IsValid)
            {
                user.Id = result.Id;
                user.FirstName = result.FirstName;
                user.LastName = result.LastName;
                user.Department = result.Department;
                user.Mission = result.Mission;
            }
            return View(user);
        }




        // FURKAN ZEREY -- Kullanıcı ile eşya arasındaki ilişkiyi listeleme.
        public IActionResult Items(int userId)
        {
            var model = new UserItemViewModel
            {
                User = _userService.Items(userId),
                Items = _itemService.GetItems()
            };

            return View(model);
        }


        // FURKAN ZEREY -- Kullanıcı üzerindeki eşyaların ilişkisini kesme.
        public IActionResult ItemDelete(int userId, int itemId)
        {
            _userService.ItemDelete(userId, itemId);

            return RedirectToAction("Items",new {userId});
        }


        // FURKAN ZEREY -- Kullanıcı üzerine eşya ekleme.
        public IActionResult ItemCreate(int userId, int itemId)
        {
            int durum = _userItemService.GetAll().Count(x => x.ItemId == itemId);
            if (durum<1)
            {
                _userService.ItemCreate(userId, itemId);
                TempData["ItemCreateMessage"] = "Eşya başarı ile eklendi.";
            }
            else
            {
                TempData["ItemCreateMessage"] = "Eklemeye çalıştığınız eşya zaten zimmetli!";
            }
            return RedirectToAction("Items", new { userId });
        }

    }
}
