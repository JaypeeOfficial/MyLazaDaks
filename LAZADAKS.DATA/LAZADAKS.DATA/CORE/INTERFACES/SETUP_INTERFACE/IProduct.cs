using LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.SETUP_DTO;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.CORE.INTERFACES.SETUP_INTERFACE
{
    public interface IProduct
    {

        Task<IReadOnlyList<ProductDto>> GetAllProduct();

        Task<ProductDto> GetAllProductById(int id);

        Task<bool> AddNewProduct(Product product);


        Task<bool> UpdateProduct(Product product);

        Task<bool> DeleteProduct(int id);
    }
}
