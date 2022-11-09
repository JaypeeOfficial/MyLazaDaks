using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyLazaDaks.Controllers.ITEMCATEGORY_CONTROLLER
{

    public class ItemCategoryController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemCategoryController(IUnitOfWork unitofwork)
        {

            _unitOfWork = unitofwork;

        }

        [HttpPost]
        [Route("AddNewItemCategory")]
        public async Task<IActionResult> CreateNewCategory(ItemCategory category)
        {

            await _unitOfWork.Categories.AddNewItemCategory(category);
            await _unitOfWork.CompleteAsync();

            return Ok(category);

        }

        [HttpGet]
        [Route("GetAllItemCategory")]
        public async Task<IActionResult> GetAllItemCategory()
        {
            var categories = await _unitOfWork.Categories.GetAllItemCategory();

            return Ok(categories);

        }


        [HttpPut]
        [Route("UpdateCategories")]
        public async Task<IActionResult> UpdateCategories([FromBody] ItemCategory category)
        {

            var validate = await _unitOfWork.Categories.UpdateItemCategories(category);

            if (validate == false)
            {
                return BadRequest("Update failed!");
            }
            await _unitOfWork.CompleteAsync();

            return Ok("Successfully updated!");

        }

        [HttpGet]
        [Route("GetCategoriesById")]
        public async Task<IActionResult> GetCategoriesById([FromQuery] int id)
        {
            var categories = await _unitOfWork.Categories.GetAllItemCategoryById(id);

            return Ok(categories);

        }




    }
}
