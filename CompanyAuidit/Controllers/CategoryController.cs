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
            var categoryList = _categoryService.GetCategories();
            var categoryToAdd = categoryList.Find(x => x.Name == category.Name);

            if (categoryToAdd != null)
            {
                TempData.Add("message", category.Name + " kategorisi zaten mevcut!");
                return RedirectToAction("ItemList", "Item");
            }
            else
            {
                _categoryService.Add(category);
                TempData.Add("message", category.Name + " kategorisi eklendi.");

            }
            return RedirectToAction("ItemList", "Item");
        }
    }
}
