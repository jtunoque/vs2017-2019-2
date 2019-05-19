using App.Domain;
using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    [Authorize]
    public class TrackController : Controller
    {
        private readonly ITrackDomain trackDomain;
        private readonly IGenreDomain genreDomain;

        public TrackController()
        {
            trackDomain = new TrackDomain();
            genreDomain = new GenreDomain();
        }

        public ActionResult Buscar()
        {
            ViewBag.Generos = genreDomain.GetAll("");
            return View();
        }
        public ActionResult ObtenerTrack(string trackName, int genero)
        {
            trackName = String.IsNullOrWhiteSpace(trackName) ? "%" : $"%{trackName.Trim()}%";


            var listado = trackDomain.Buscar(trackName, genero);

            //OJO NO PONER EN PRODUCCION ESTO SOLO ES PARA RETARDAR LA CONSULTA
            // System.Threading.Thread.Sleep(2000); // dormir 2 segundis

            return PartialView(listado);
        }
    }
}