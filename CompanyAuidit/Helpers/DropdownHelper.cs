﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAuidit.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyAuidit.Helpers
{
    public  class DropdownHelper
    {
        private readonly UserItemService _userItemService;
        private readonly ItemService _itemService;
        private readonly CategoryService _categoryService;


        public DropdownHelper(UserItemService userItemService, ItemService itemService, CategoryService categoryService)
        {
            _userItemService = userItemService;
            _itemService = itemService;
            _categoryService = categoryService;
        }
        public  SelectList CategoryDropdown()
        {
            var categories = _itemService.GetCategory();
            var categoryList = categories.Select(r => new { r.Id, r.Name }).ToList();
            var hede = new SelectList(categoryList, "Id", "Name");
            return hede;
        }
    }
}
