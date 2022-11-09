using LAZADAKS.DATA.CORE.INTERFACES.SETUP_INTERFACE;
using LAZADAKS.DATA.CORE.INTERFACES.USER_INTERFACE;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.CUSTOMER_DTO;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.SETUP_DTO;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.STORE_CONTEXT;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.DATA_ACCESS_LAYER.REPOSITORIES.USER_REPOSITORY
{
    public  class UserRepository : IUserRepository
    {
        private readonly StoreContext _context;

        public UserRepository(StoreContext context)
        {
            _context = context;

        }

        public async Task<bool> AddNewUser(User user)
        {
            await _context.Users.AddAsync(user);

            return true;
        }

        public async Task<IReadOnlyList<UserDto>> GetAllUsers()
        {
            var user = _context.Users.Select(x => new UserDto
            {

                Id = x.Id,
                FullName = x.FullName,
                DateofBirth = x.DateOfBirth.ToString(),
                Email = x.Email,
                Password = x.Password,
                AddedBy = x.AddedBy, 
                DateAdded = x.DateAdded.ToString("MM/dd/yyyy")

            });

            return await user.ToListAsync();
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _context.Users.Remove(user);
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateUser(User user)
        {

            var exist = await _context.Users.Where(x => x.Id == user.Id)
                                        .FirstOrDefaultAsync();
            if (exist == null)
                return false;

            exist.FullName = user.FullName;
            exist.DateOfBirth = user.DateOfBirth;
            exist.Email = user.Email;
            exist.Password = user.Password;

            return true;

        }

        public async Task<UserDto> GetAllUserById(int id)
        {

            var customer = _context.Users.Select(x => new UserDto
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                Password = x.Password
            });

            return await customer.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
