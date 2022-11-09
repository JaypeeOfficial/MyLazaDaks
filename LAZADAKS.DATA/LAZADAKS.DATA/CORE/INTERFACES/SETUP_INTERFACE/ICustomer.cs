using LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.CUSTOMER_DTO;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.CORE.INTERFACES.SETUP_INTERFACE
{
    public  interface ICustomer
    {

        Task<IReadOnlyList<CustomerDto>> GetAllCustomer();

        Task<CustomerDto> GetAllCustomerById(int id);

        Task<bool> AddNewCustomer(Customer customer);


        Task<bool> UpdateCustomer(Customer customer);

        Task<bool> DeleteCustomer(int id);



    }
}
