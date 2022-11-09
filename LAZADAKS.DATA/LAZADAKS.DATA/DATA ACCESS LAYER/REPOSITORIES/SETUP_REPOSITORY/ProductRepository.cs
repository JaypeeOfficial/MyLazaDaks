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
 
    public class ProductRepository : IProduct
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewProduct(Product product)
        {
            await _context.Products.AddAsync(product);

            return true;
        }


        public async Task<IReadOnlyList<ProductDto>> GetAllProduct()
        {
            var products = _context.Products.Select(x => new ProductDto
            {
                Id = x.Id,
                ProductCode = x.ProductCode,
                ProductName = x.ProductName,
                ItemCategory = x.ItemCategory.CategoryName,
                Price = x.Price,
                AddedBy = x.AddedBy,
                DateAdded = x.DateAdded.ToString(),
                IsActive = x.IsActive,
                ImagePath = x.ImagePath
            });

            return await products.ToListAsync();
        }

        public async Task<ProductDto> GetAllProductById(int id)
        {
            var products = _context.Products.Select(x => new ProductDto
            {
                Id = x.Id,
                ProductCode = x.ProductCode,
                ProductName = x.ProductName,
                ItemCategory = x.ItemCategory.CategoryName,
                Price = x.Price,
                AddedBy = x.AddedBy,
                DateAdded = x.DateAdded.ToString("mm/dd/yyyy"),
                IsActive = x.IsActive,
                ImagePath = x.ImagePath
            });

            return await products.FirstOrDefaultAsync(x => x.Id == id);


        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var products =  await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

            if (products == null)
                return false;

            products.ProductName = product.ProductName;
            products.Price = product.Price;
            products.ImagePath = product.ImagePath;
            products.ItemCategoryId = product.ItemCategoryId;

            return true;
                    
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if(product != null)
            {
                _context.Products.Remove(product);
                return true;
            }

            return false;
        }


    }
}
