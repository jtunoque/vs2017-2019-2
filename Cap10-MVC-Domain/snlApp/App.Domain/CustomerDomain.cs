using App.Data.Repository;
using App.Domain.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class CustomerDomain : ICustomerDomain
    {
        public bool Delete(int id)
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.CustomerRepository.Remove(new Customer() {CustomerId=id });

            }

        }

        public IEnumerable<Customer> Get(string nombre)
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.CustomerRepository.GetAll(
                    x=>String.Concat(x.FirstName," ",x.LastName).Contains(nombre)                    
                    );
            }

        }

        public Customer GetById(int id)
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.CustomerRepository.GetById<int>(id);
            }
        }

        public bool Save(Customer entity)
        {
            bool result = false;

            try
            {
                using (var uw = new AppUnitOfWork())
                {
                    //Nuevo registro
                    if (entity.CustomerId == 0)
                    {
                        uw.CustomerRepository.Add(entity);
                    }
                    else
                    {
                        uw.CustomerRepository.Update(entity);
                    }

                    uw.Complete();
                }

                result = true;
            }
            catch(Exception ex)
            {

            }


            return result;
        }
    }
}
