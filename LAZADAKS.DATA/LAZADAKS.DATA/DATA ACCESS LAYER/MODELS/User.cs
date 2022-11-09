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
    public class User : BaseEntity
    {

        public string FullName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;

        [Column(TypeName = "Date")]
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string AddedBy { get; set; }
    }

    public class UserValidator : AbstractValidator<User>
    {       
        public UserValidator()
        {
            RuleFor(user => user.Id).NotNull();
            RuleFor(user => user.Email).NotEqual(user => user.Password);
            RuleFor(user => user.Password).NotNull();
            RuleFor(user => user.DateOfBirth).NotEqual(DateTime.Now);
        }

    }

}
