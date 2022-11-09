using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.CUSTOMER_DTO
{
    public  class CustomerDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string DateAdded { get; set; }
        public string AddedBy { get; set; }
  

    }
}
