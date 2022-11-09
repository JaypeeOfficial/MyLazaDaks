using LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.STORE_CONTEXT;
using LAZADAKS.DATA.ICONFIGURATION;
using LAZADAKS.DATA.JWT.AUTHENTICATION;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.SERVICES
{
    public class UserService : IUserService
    {
        private readonly StoreContext _context;
        private readonly IConfiguration _configuration;
        public UserService(StoreContext context,
                            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public AuthenticateResponse Authenticate(AuthenticationRequest request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email
                                                        && x.Password == request.Password
                                                        && x.IsActive != false);
            if (user == null)
                return null;

            var token = generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(User user)
        {
            var key = _configuration.GetValue<string>("JwtConfig:Key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {

                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("id", user.Id.ToString())

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials
               (new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }


    }
}
