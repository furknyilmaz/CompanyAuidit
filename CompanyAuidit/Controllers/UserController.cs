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
        private readonly UserService _context;

        public UserController(UserService context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SaveUser()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult SaveUser(User model)
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

                _context.Add(user);
            }

            return RedirectToAction(nameof(SaveUser));

        }

        [HttpPost]
        public IActionResult SaveUser2(User model)
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

                _context.Add(user);
            }
            return RedirectToAction(nameof(UserList));
        }

        public IActionResult UserList()
        {
            var result = _context.GetAll();
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
                _context.Update(user);
            }

            return RedirectToAction(nameof(UserList));
        }

        [HttpGet]
        public IActionResult UserUpdate(int id)
        {
            var result = _context.GetAll().FirstOrDefault(x => x.Id == id);

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
    }
}
