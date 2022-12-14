using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS
{
    public  class Customer : BaseEntity
    {
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public bool IsActive{ get; set; } = true;

        [Column(TypeName = "Date")]
        public DateTime DateAdded { get; set; } = DateTime.Now; 
        public string AddedBy { get; set; }
    }

    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {

            RuleFor(customer => customer.CustomerName).NotNull();
            RuleFor(customer => customer.City).NotNull();
            RuleFor(customer => customer.Phone).NotNull();
 
        }

    }

}


