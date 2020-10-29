using System;
using System.Linq;
using CompanyAuidit.Helpers;
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
        private readonly CategoryService _categoryService;
        private readonly DropdownHelper _dropdownHelper;


        public ItemController(UserItemService userItemService, ItemService itemService, CategoryService categoryService, DropdownHelper dropdownHelper)
        {
            _userItemService = userItemService;
            _itemService = itemService;
            _categoryService = categoryService;
            _dropdownHelper = dropdownHelper;
        }

        [HttpGet]
        public IActionResult AddItem()
        {
          
            return View();
        }


        [HttpPost]
        public IActionResult AddItem(AddItemViewModel model, bool @return)
        {
            if (ModelState.IsValid)
            {

                _dropdownHelper.CategoryDropdown();
                Item item = new Item()
                {
                    SerialNumber = model.SerialNumber,
                    Description = model.Description,
                    Cost = model.Cost,
                    ItemType = new ItemType
                    {
                        Name = model.Name,
                        CategoryId = model.CategoryId
                    }
                };

                _itemService.Add(item);

            }
            else
            {


                return View(model);
            }

            if (@return)
                return RedirectToAction(nameof(ItemList));
            return View();
        }



        public IActionResult ItemList()
        {
            var itemListViewModel = new ItemListViewModel
            {
                Items = _itemService.GetAll()
            };

            var item = _itemService.GetItemType();
            return View(itemListViewModel);
        }

        //public IActionResult DeleteItem(int id)
        //{
        //    Item item = new Item();
        //    _itemService.Delete(item);

        //    UserItem userItem = new UserItem();

        //    var userItems = _userItemService.GetAll().Where(x => x.ItemId == item.Id);

        //    _userItemService.Delete(userItem);


        //    return RedirectToAction(nameof(ItemList));
        //}

        [HttpPost]
        public IActionResult UpdateItem(Item model)
        {
            if (ModelState.IsValid)
            {
                _dropdownHelper.CategoryDropdown();
                Item item = new Item()
                {
                    SerialNumber = model.SerialNumber,
                    Description = model.Description,
                    Cost = model.Cost,
                    ItemType = new ItemType
                    {
                        Name = model.ItemType.Name,
                        CategoryId = model.ItemType.CategoryId
                    }
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
                if (result != null)
                {
                    item.Id = result.Id;
                    item.ItemType.Name = result.ItemType.Name;
                    item.Description = result.Description;
                    item.Cost = result.Cost;
                }
            }
            return View(item);
        }

        public IActionResult ItemCreate(int userId, int itemId)
        {
            _itemService.UserCreate(userId, itemId);
            return RedirectToAction("ItemList");
        }
    }

}