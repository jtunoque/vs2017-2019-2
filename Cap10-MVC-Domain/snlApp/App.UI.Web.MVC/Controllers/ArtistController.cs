using App.Domain;
using App.Domain.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    [Authorize]
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Artist model)
        {
            var result = artistDomain.SaveArtist(model);

            if(result)
            {
                return RedirectToAction("Buscar");
            }
            else
            {
                return View("Error");
            }            
        }

        public ActionResult Edit(int id)
        {
            var artista = artistDomain.GetArtistById(id);

            return View(artista);
        }
    }
}