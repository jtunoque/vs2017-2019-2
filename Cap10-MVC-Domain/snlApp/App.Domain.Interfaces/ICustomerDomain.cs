using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ICustomerDomain
    {
        IEnumerable<Customer> Get(string nombre);

        Customer GetById(int id);

        bool Save(Customer entity);

        bool Delete(int id);

    }
}
