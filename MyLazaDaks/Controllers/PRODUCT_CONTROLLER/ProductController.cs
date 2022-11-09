using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyLazaDaks.Controllers.PRODUCT_CONTROLLER
{

    public class ProductController : BaseApiController
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        [HttpPost]
        [Route("AddNewProduct")] 
        public async Task<ActionResult> CreateNewProduct(Product product)
        {

            await _unitOfWork.Products.AddNewProduct(product);
            await _unitOfWork.CompleteAsync();

            return Ok(product);

        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAllProduct();

            return Ok(products);

        }



        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {

            var validate = await _unitOfWork.Products.UpdateProduct(product);

            if (validate == false)
            {
                return BadRequest("Update failed!");
            }
            await _unitOfWork.CompleteAsync();

            return Ok("Successfully updated!");

        }

        [HttpGet]
        [Route("GetProductId")]
        public async Task<IActionResult> GetProductId([FromQuery] int id)
        {
            var products = await _unitOfWork.Products.GetAllProductById(id);

            return Ok(products);

        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {


            var validate = await _unitOfWork.Products.DeleteProduct(id);

            if (validate == false)
            {
                return BadRequest("Delete failed!");
            }
            await _unitOfWork.CompleteAsync();

            return Ok("Successfully deleted!");

        }



    }
}
