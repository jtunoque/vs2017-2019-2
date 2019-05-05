using App.UI.Web.MVC.MantenimientosService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    public class ArtistController : Controller
    {
        private readonly MantenimientosServiceClient mantenimientosServiceClient;

        public ArtistController()
        {
            mantenimientosServiceClient = new MantenimientosServiceClient();
        }

        // GET: Artist
        public ActionResult Index(string artistaNombre)
        {
            artistaNombre = artistaNombre ?? "";
            var listado = mantenimientosServiceClient.GetArtistAll(artistaNombre);
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
            var listado = mantenimientosServiceClient.GetArtistAll(artistaNombre);
            ViewBag.artistaFiltrado = artistaNombre;

            //System.Threading.Thread.Sleep(2000);

            return PartialView(listado);
        }
    }
}