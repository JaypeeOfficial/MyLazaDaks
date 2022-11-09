using LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.JWT.AUTHENTICATION
{
    public  class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FullName = user.FullName;
            Email = user.Email;
            Password = user.Password;
            Token = token;
        }

    }
}
