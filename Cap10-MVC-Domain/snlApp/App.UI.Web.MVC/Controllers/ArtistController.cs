using App.Domain;
using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistDomain artistDomain;

        public ArtistController()
        {
            artistDomain = new ArtistDomain();
        }

        // GET: Artist
        public ActionResult Index(string artistaNombre)
        {
            artistaNombre = artistaNombre ?? "";
            var listado = artistDomain.GetArtist(artistaNombre);
            ViewBag.artistaFiltrado = artistaNombre;
            return View(listado);
        }

        public ActionResult Buscar()
        {
            return View();
        }

        public ActionResult ObtenerArtistas(string artistaNombre)
        {
            artistaNombre = artistaNombre ?? "";
            var listado = artistDomain.GetArtist(artistaNombre);
            ViewBag.artistaFiltrado = artistaNombre;

            //System.Threading.Thread.Sleep(2000);

            return PartialView(listado);
        }
    }
}