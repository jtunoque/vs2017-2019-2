using System;
using System.Collections.Generic;
using App.Data.DataAccess;
using App.Data.Repository.Interface;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace App.Data.Repository.Test
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        [TestMethod]
        public void Count()
        {
            var _context = new DBDataModel();
            IArtistRepository rep = new ArtistRepository(_context);
            var count = rep.Count();

            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void CountUW()
        {
            var count = 0;
            using (var unitOfWork = new AppUnitOfWork())
            {
                count = unitOfWork.ArtistRepository.Count();
            }
            Assert.IsTrue(count > 0);
        }


        [TestMethod]
        public void Insert()
        {
            int result = 0;
            using (var unitOfWork = new AppUnitOfWork())
            {
                var entity = new Artist();
                entity.Name = "Artist-" + Guid.NewGuid();
                unitOfWork.ArtistRepository.Add(entity);
                result = unitOfWork.Complete();
            }
            Assert.IsTrue(result>0);
        }

        [TestMethod]
        public void Update()
        {
            int result = 0;
            using (var unitOfWork = new AppUnitOfWork())
            {
                var entity = new Artist();
                entity.ArtistId = 289;
                entity.Name = "Artist-" + Guid.NewGuid();
                unitOfWork.ArtistRepository.Update(entity);
                result = unitOfWork.Complete();
            }
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Delete()
        {
            int result = 0;
            using (var unitOfWork = new AppUnitOfWork())
            {
                var entity = new Artist();
                entity.ArtistId = 289;
                unitOfWork.ArtistRepository.Remove(entity);
                result = unitOfWork.Complete();
            }
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Get()
        {
            Artist result = null;
            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.ArtistRepository.GetById<int>(1);
            }
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAll()
        {
            List<Artist> result = null;
            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.ArtistRepository.GetAll
                    (item=>item.Name.StartsWith("b") && item.ArtistId>=13,
                   item=>item.OrderBy(itemOrder=>itemOrder.Name),
                   null,"Album"
                    );

                //item => new Artist() { ArtistId = item.ArtistId, Name = item.Name }
            }
            Assert.IsNotNull(result);
        }
    }
}
