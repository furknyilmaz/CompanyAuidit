using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAuidit.Contexts;
using CompanyAuidit.Models;
using CompanyAuidit.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyAuidit.Controllers
{
    public class ItemController : Controller
    {
        private readonly UserItemService _userItemService;
        private readonly ItemService _itemService;
        private CategoryService _categoryService;

        public ItemController(UserItemService userItemService, ItemService itemService, CategoryService categoryService)
        {
            _userItemService = userItemService;
            _itemService = itemService;
            _categoryService = categoryService;
        }


        public IActionResult Index()
        {
            var result = _itemService.GetAll();

            return View(result);
        }

        //[HttpGet]
        //public IActionResult AddItem()
        //{
        //    return View(new Item());
        //}


        [HttpPost]
        public IActionResult AddItem(Item model)
        {
            if (ModelState.IsValid)
            {
                Item item = new Item()
                {
                    SerialNumber = model.SerialNumber,
                    Description = model.Description,
                    Cost = model.Cost,
                    ItemType = model.ItemType

                };

                _itemService.Add(item);

            }

            return RedirectToAction(nameof(AddItem));
        }

        [HttpPost]
        public IActionResult AddItem2(Item model)
        {
            if (ModelState.IsValid)
            {
                Item item = new Item()
                {
                    SerialNumber = model.SerialNumber,
                    Description = model.Description,
                    Cost = model.Cost,
                    ItemType = model.ItemType

                };

                _itemService.Add(item);

            }
            return RedirectToAction(nameof(ItemList));
        }

        public IActionResult ItemList()
        {
            var itemListViewModel = new ItemListViewModel
            {
                Items = _itemService.GetAll()
            };

            return View(itemListViewModel);
        }

        public IActionResult DeleteItem(int id)
        {
            Item item = new Item();
            _itemService.Delete(item);

            UserItem userItem = new UserItem();

            var userItems = _userItemService.GetAll().Where(x => x.ItemId == item.Id);

            _userItemService.Delete(userItem);


            return RedirectToAction(nameof(ItemList));
        }

        [HttpPost]
        public IActionResult UpdateItem(Item model)
        {
            if (ModelState.IsValid)
            {
                Item item = new Item()
                {
                    SerialNumber = model.SerialNumber,
                    Description = model.Description,
                    Cost = model.Cost,
                    ItemType = model.ItemType

                };
                TempData["ItemMessage"] = @$"Eşya {item.ItemType.Name} güncellendi";
                _itemService.Update(item);

            }
            //return View();
            return RedirectToAction(nameof(ItemList));
        }

        [HttpGet]
        public IActionResult UpdateItem(int id)
        {
            var result = _itemService.GetAll().FirstOrDefault(x => x.Id == id);
            var item = new Item();
            if (ModelState.IsValid)
            {
                item.Id = result.Id;
                item.ItemType.Name = result.ItemType.Name;
                item.Description = result.Description;
                item.Cost = result.Cost;
            }
            return View(item);
        }

    }

}