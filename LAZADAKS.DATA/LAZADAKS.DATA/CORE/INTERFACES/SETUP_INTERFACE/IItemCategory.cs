using LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.CUSTOMER_DTO;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.SETUP_DTO;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.CORE.INTERFACES.SETUP_INTERFACE
{
    public interface IItemCategory
    {

        Task<IReadOnlyList<ItemCategoryDto>> GetAllItemCategory();

        Task<ItemCategoryDto> GetAllItemCategoryById(int id);

        Task<bool> AddNewItemCategory(ItemCategory category);


        Task<bool> UpdateItemCategories(ItemCategory category);

    }
}
