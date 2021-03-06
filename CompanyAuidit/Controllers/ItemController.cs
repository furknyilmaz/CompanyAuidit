﻿using System;
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
        private readonly UserService _userService;

        public ItemController(UserItemService userItemService, ItemService itemService, CategoryService categoryService, DropdownHelper dropdownHelper, UserService userService)
        {
            _userItemService = userItemService;
            _itemService = itemService;
            _categoryService = categoryService;
            _dropdownHelper = dropdownHelper;
            _userService = userService;
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
                Items = _itemService.GetAll().OrderByDescending(item => item.Id).ToList(),
                User = _userService.GetAll()
        };

            var items = _itemService.GetItemType();
            var userItems = _userItemService.GetUserItems();
            return View(itemListViewModel);
        }

        public IActionResult DeleteItem(int id)
        {
            var selectedItem = _itemService.GetAll().FirstOrDefault(x => x.Id == id);
            var selectedItemWithType = _itemService.GetItemType().FirstOrDefault(x => x.Id == id);
            _itemService.Delete(selectedItemWithType, id);
            //var userItem = _userItemService.GetAll().FirstOrDefault(x => x.ItemId == id);
            //_userItemService.Delete(userItem,id);
            return RedirectToAction(nameof(ItemList));
        }
        [HttpPost]
        public IActionResult UpdateItem(UpdateItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                _dropdownHelper.CategoryDropdown();
                Item item = new Item()
                {
                    SerialNumber = model.SerialNumber,
                    Description = model.Description,
                    Cost = model.Cost,
                    Id = model.Id,
                    ItemType = new ItemType
                    {
                        Name = model.Name,
                        CategoryId = model.CategoryId
                    }
                };
                TempData["ItemMessage"] = @$"Eşya {item.ItemType.Name} güncellendi";
                _itemService.Update(item);
            }
            return RedirectToAction(nameof(ItemList));
        }
        [HttpGet]
        public IActionResult UpdateItem(int id)
        {
            var selectedItem = _itemService.GetAll().FirstOrDefault(x => x.Id == id);
            //_dropdownHelper.CategoryDropdown();
            var selectedItemWithType = _itemService.GetItemType().FirstOrDefault(x => x.Id == id);
            var item = new UpdateItemViewModel()
            {
                Description = selectedItemWithType.Description,
                Cost = selectedItemWithType.Cost,
                SerialNumber = selectedItemWithType.SerialNumber,
                Name = selectedItemWithType.ItemType.Name,
                CategoryId = selectedItemWithType.ItemType.CategoryId,
                Id = id
            };
            return View(item);
        }



        public IActionResult UserCreate(int userId, int itemId)
        {
            int durum = _userItemService.GetAll().Count(x => x.ItemId == itemId);
            if (durum < 1)
            {
                _itemService.UserCreate(userId, itemId);
                TempData["ItemCreateMessage"] = "Eşya, kişiye başarı ile eklendi.";
            }
            else
            {
                TempData["ItemCreateMessage"] = "Eklemeye çalıştığınız eşya zaten zimmetli!";
            }
            return RedirectToAction("ItemList");
        }
    }
}