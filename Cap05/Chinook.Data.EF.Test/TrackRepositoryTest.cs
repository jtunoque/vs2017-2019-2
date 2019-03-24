using System;
using System.Linq;
using Chinook.Data.EF.Repositories;
using Chinook.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.Data.EF.Test
{
    [TestClass]
    public class TrackRepositoryTest
    {
       
        [TestMethod]
        public void GetAll()
        {
            var repository = new TrackRepository();
            var listado = repository.GetAll("");

            Assert.IsTrue(listado.Count() > 0);
        }

        
    }
}
