using System;
using System.Linq;
using Chinook.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.Data.Test
{
    [TestClass]
    public class ArtistDATest
    {
        [TestMethod]
        public void GetCount()
        {
            var da = new ArtistDA();
            var cantidad = da.GetCount();
            Assert.IsTrue(cantidad>0);
        }

        [TestMethod]
        public void GetListado()
        {
            var da = new ArtistDA();
            var listado = da.Gets();
            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void GetsWithParam()
        {
            var da = new ArtistDA();
            var listado = da.GetsWithParam("a%");
            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void GetsWithParamSP()
        {
            var da = new ArtistDA();
            var listado = da.GetsWithParamSP("a%");
            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void InsertArtist()
        {
            var da = new ArtistDA();
            var id = da.InsertArtist(new Artist() { Name="Prueba"});
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void InsertArtistTX()
        {
            var da = new ArtistDA();
            var id = da.InsertArtistTX(new Artist() { Name = "Prueba TX" });
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void InsertArtistTXDist()
        {
            var da = new ArtistDA();
            var id = da.InsertArtistTXDist(new Artist() { Name = "Prueba TX" });
            Assert.IsTrue(id > 0);
        }
    }
}
