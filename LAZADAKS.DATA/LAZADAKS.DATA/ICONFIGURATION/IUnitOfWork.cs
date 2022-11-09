using LAZADAKS.DATA.CORE.INTERFACES.SETUP_INTERFACE;
using LAZADAKS.DATA.CORE.INTERFACES.USER_INTERFACE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.ICONFIGURATION
{
    public interface IUnitOfWork
    {

        IUserRepository Users { get; }

        ICustomer Customers { get; }

        IItemCategory Categories { get; }

        IProduct Products { get; }

        Task CompleteAsync();


    }
}
