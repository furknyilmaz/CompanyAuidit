using System;
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
        private ItemTypeService _itemTypeService;


        public DropdownHelper(UserItemService userItemService, ItemService itemService, CategoryService categoryService, ItemTypeService itemTypeService)
        {
            _userItemService = userItemService;
            _itemService = itemService;
            _categoryService = categoryService;
            _itemTypeService = itemTypeService;
        }
        public  SelectList CategoryDropdown()
        {
            var categories = _categoryService.GetCategories();
            var categoryList = categories.Select(r => new { r.Id, r.Name }).ToList();
            var hede = new SelectList(categoryList, "Id", "Name");
            return hede;
        }


    }


}
