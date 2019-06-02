using App.Domain;
using App.Domain.Interfaces;
using App.Entities.Base;
using App.UI.Web.MVC.Models;
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
        private readonly IAlbumDomain albumDomain;
        private readonly IMediosDomain mediosDomain;
        private readonly IPlaylistDomain playlistDomain;

        public TrackController()
        {
            trackDomain = new TrackDomain();
            genreDomain = new GenreDomain();
            albumDomain = new AlbumDomain();
            mediosDomain = new MediosDomain();
            playlistDomain = new PlaylistDomain();
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

        public ActionResult Nuevo()
        {
            ViewBag.Albums = albumDomain.GetAlbum("");
            ViewBag.Generos = genreDomain.GetAll("");
            ViewBag.MediaTypes = mediosDomain.GetAll("");
            ViewBag.PlayList = playlistDomain.GetAll("");

            return View();
        }

        [HttpPost]
        public ActionResult Guardar(TrackModel model)
        {
            var track = new Track();
            track.Name = model.Nombre;
            track.AlbumId = model.Album;
            track.MediaTypeId = model.Medio;
            track.GenreId = model.Generos;
            track.Composer = model.Compositor;
            track.Milliseconds = model.Tiempo;
            track.Bytes = model.Peso;
            track.UnitPrice = model.Precio;

            if (model.PlayList != null)
            {
                track.Playlist = new List<Playlist>();

                foreach(var playListId in model.PlayList)
                {
                    track.Playlist.Add(
                        new Playlist() {PlaylistId= playListId }
                        );
                }
            }

            var result = trackDomain.Guardar(track);
            var confirmModel = new ConfirmModel();

            if (result)
            {
                confirmModel.Message = "La información del track se han registrado correctamente";
            }
            else
            {
                confirmModel.Message = "La información del track no se pudo registrar";
            }

            confirmModel.RedirectUrl = "/Track/Buscar";
            return View("Confirm", confirmModel);
        }
    }
}