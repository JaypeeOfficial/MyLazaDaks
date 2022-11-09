using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS
{
    public  class Product : BaseEntity
    {

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public ItemCategory ItemCategory { get; set; }
        public int ItemCategoryId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string AddedBy { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public string ImagePath { get; set; }

    }

    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {

            RuleFor(product => product.Id).NotNull();
            RuleFor(product => product.ProductCode).NotNull();
            RuleFor(product => product.ProductName).NotNull();
            RuleFor(product => product.ItemCategoryId).NotNull();
            RuleFor(product => product.Price).NotNull();

        }
    }



}
