using LAZADAKS.DATA.CORE.INTERFACES.SETUP_INTERFACE;
using LAZADAKS.DATA.CORE.INTERFACES.USER_INTERFACE;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.REPOSITORIES.SETUP_REPOSITORY;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.REPOSITORIES.USER_REPOSITORY;
using LAZADAKS.DATA.DATA_ACCESS_LAYER.STORE_CONTEXT;
using LAZADAKS.DATA.ICONFIGURATION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.DATA_ACCESS_LAYER
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly StoreContext _context;
        public IUserRepository Users { get; private set; }

        public ICustomer Customers { get; private set; }

        public IItemCategory Categories { get; private set; }

        public IProduct Products { get; private set; }

        public UnitOfWork(StoreContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Customers =  new CustomerRepository(_context);
            Categories = new ItemCategoryRepository(_context);
            Products = new ProductRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
