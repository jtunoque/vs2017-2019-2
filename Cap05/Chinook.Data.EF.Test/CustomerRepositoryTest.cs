using System;
using Chinook.Data.EF.Repositories;
using Chinook.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.Data.EF.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {

        [TestMethod]
        public void Update()
        {
            var rep = new CustomerRepository();
            var entity = rep.Get(1);
            entity.FirstName = "Jose Manuel";
            rep.Update(entity);

            var entityActualizada = rep.Get(1);
            var result = entityActualizada.FirstName == "Jose Manuel";

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateAddress()
        {
            var rep = new CustomerRepository();
            var result = rep.UpdateAddress(
                new Customer()
                {
                    CustomerId=1,
                    Address="AV Costanera 985",
                    Phone="992794569"
                }
                );

            Assert.IsTrue(result);
        }
    }
}
