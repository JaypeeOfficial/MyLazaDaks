using LAZADAKS.DATA.CORE.INTERFACES.SETUP_INTERFACE;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.SETUP_DTO;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.STORE_CONTEXT;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.DATA_ACCESS_LAYER.REPOSITORIES.SETUP_REPOSITORY
{
    public  class ItemCategoryRepository : IItemCategory
    {

        private readonly StoreContext _context;

        public ItemCategoryRepository(StoreContext context)
        {

            _context = context;
        }

        public async Task<bool> AddNewItemCategory(ItemCategory category)
        {
            await _context.AddAsync(category);

            return true;
        }

        public async Task<IReadOnlyList<ItemCategoryDto>> GetAllItemCategory()
        {
            var category = _context.ItemCategories.Select(x => new ItemCategoryDto
            {

                Id  = x.Id, 
                ItemCategoryName = x.CategoryName, 
                AddedBy = x.AddedBy,
                DateAdded = x.DateAdded.ToString("mm/dd/yyyy"),
                IsActive = x.IsActive

            });

            return await category.ToListAsync();

        }

        public async Task<ItemCategoryDto> GetAllItemCategoryById(int id)
        {
            var category = _context.ItemCategories.Select(x => new ItemCategoryDto
            {
                Id = x.Id,
                ItemCategoryName = x.CategoryName,
                AddedBy = x.AddedBy,
                DateAdded = x.DateAdded.ToString("mm/dd/yyyy"),
                IsActive = x.IsActive
            });

            return await category.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<bool> UpdateItemCategories(ItemCategory category)
        {
            var existingCategory = await _context.ItemCategories.FirstOrDefaultAsync(x => x.Id == category.Id);


            if (category == null)
                return false;


            existingCategory.CategoryName = category.CategoryName;

            return true;

        }
    }
}
