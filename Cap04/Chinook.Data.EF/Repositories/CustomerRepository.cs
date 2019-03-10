using Chinook.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data.EF.Repositories
{
    public class CustomerRepository
    {
        private readonly AppDataModel _context;

        public CustomerRepository()
        {
            _context = new AppDataModel();
        }

        public int Count()
        {
            return _context.Customer.Count();
        }

        public Customer Get(int id)
        {
            return _context.Customer.Find(id);
        }


        public IEnumerable<Customer> GetAll(string fullName)
        {
            return _context.Customer
                    .Where(a=>string.Concat(a.FirstName," ",a.LastName).Contains(fullName))
                    .OrderBy(o=>o.LastName).ThenByDescending(o=>o.FirstName)
                    .ToList();
        }

        public int Insert(Customer entity)
        {
            //Se agrega la información al contexto de EF
            _context.Customer.Add(entity);
            //Confiema la trasacción
            _context.SaveChanges();

            return entity.CustomerId;
        }

        public bool Update(Customer entity)
        {
            //Atachando en memoría el objeto que
            //se quiere atualizar
            _context.Customer.Attach(entity);
            //Cambiando el estado de
            //Unchanged a Modified
            _context.Entry(entity).State = 
                EntityState.Modified;

            //Confirmando la operación
            var result = _context.SaveChanges();

            return result > 0;

        }

        public bool Delete(Customer entity)
        {
            //Atachando en memoría el objeto que
            //se quiere atualizar
            _context.Customer.Attach(entity);

            //Cambiando el estado de
            //Unchanged a Deleted
            _context.Customer.Remove(entity);
            //Confirmando la operación
            var result = _context.SaveChanges();

            return result > 0;

        }


    }
}
