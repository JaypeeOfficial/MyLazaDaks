using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.SETUP_DTO
{
    public  class ProductDto
    {

        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ItemCategory { get; set; }
        public decimal Price { get; set; }
        public string AddedBy { get; set; }
        public string DateAdded { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }

    }
}
