﻿using App.UI.Web.MVC.MantenimientosService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    public class TrackController : Controller
    {
        private readonly MantenimientosServiceClient mantenimientosServiceClient;

        public TrackController()
        {
            mantenimientosServiceClient = new MantenimientosServiceClient();
        }

        public ActionResult Buscar()
        {
            return View();
        }
        public ActionResult ObtenerTrack(string trackName, int genero)
        {
            trackName = String.IsNullOrWhiteSpace(trackName) ? "%" : trackName.Trim();


            var listado = mantenimientosServiceClient.TrackBuscar(trackName, genero);

            //OJO NO PONER EN PRODUCCION ESTO SOLO ES PARA RETARDAR LA CONSULTA
            // System.Threading.Thread.Sleep(2000); // dormir 2 segundis

            return PartialView(listado);
        }
    }
}