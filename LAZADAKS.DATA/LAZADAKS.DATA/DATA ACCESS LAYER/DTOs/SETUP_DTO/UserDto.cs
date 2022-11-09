using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.SETUP_DTO
{
    public  class UserDto
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public string DateofBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateAdded { get; set; }
        public string AddedBy { get; set; }

    }
}
