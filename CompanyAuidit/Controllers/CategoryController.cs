using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAuidit.Models;
using CompanyAuidit.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAuidit.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryService.Add(category);
            return RedirectToAction("ItemList", "Item");
        }
    }
}
