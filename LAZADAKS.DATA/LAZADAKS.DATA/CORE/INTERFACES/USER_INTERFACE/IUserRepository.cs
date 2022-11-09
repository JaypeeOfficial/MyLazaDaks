using LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.CUSTOMER_DTO;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.SETUP_DTO;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.CORE.INTERFACES.USER_INTERFACE
{
    public  interface IUserRepository
    {

        Task<bool> AddNewUser (User user);

        Task<IReadOnlyList<UserDto>> GetAllUsers();

        Task<bool> DeleteUser(int id);

        Task<bool> UpdateUser(User user);

        Task<UserDto> GetAllUserById(int id);

    }
}
