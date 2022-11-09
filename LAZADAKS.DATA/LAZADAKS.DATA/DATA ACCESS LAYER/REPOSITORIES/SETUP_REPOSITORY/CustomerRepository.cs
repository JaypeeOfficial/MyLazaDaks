using LAZADAKS.DATA.CORE.INTERFACES.SETUP_INTERFACE;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.CUSTOMER_DTO;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.STORE_CONTEXT;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.DATA_ACCESS_LAYER.REPOSITORIES.SETUP_REPOSITORY
{
    public class CustomerRepository : ICustomer
    {
        private readonly StoreContext _context;

        public CustomerRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<CustomerDto>> GetAllCustomer()
        {
            var customer = _context.Customers.Select(x => new CustomerDto
            {

                Id = x.Id,
                CustomerName = x.CustomerName,  
                City = x.City,
                Phone = x.Phone,
                AddedBy = x.AddedBy,
                DateAdded = x.DateAdded.ToString("MM/dd/yyyy")
              
            });

            return await customer.ToListAsync();

        }
        public async Task<bool> AddNewCustomer(Customer customer)
        {

            await _context.Customers.AddAsync(customer);

            return true;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customers = await _context.Customers
                                              .FirstOrDefaultAsync(x => x.Id == id);

            if(customers != null)
            {
                _context.Customers.Remove(customers);
                return true;
            }

            return false;

        }

        public async Task<CustomerDto> GetAllCustomerById(int id)
        {
            var customer = _context.Customers.Select(x => new CustomerDto
            {
                Id = x.Id,
                CustomerName = x.CustomerName,
                City = x.City,
                Phone = x.Phone
            });

            return await customer.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var exist = await _context.Customers.Where(x => x.Id == customer.Id)
                                          .FirstOrDefaultAsync();

            if (exist == null)
                return false;

            exist.CustomerName = customer.CustomerName;
            exist.Phone = customer.Phone;
            exist.City = customer.City;

            return true;

        }
    }
}
