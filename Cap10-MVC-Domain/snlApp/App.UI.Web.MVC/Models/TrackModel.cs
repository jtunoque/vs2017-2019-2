using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.UI.Web.MVC.Models
{
    public class TrackModel
    {
        public string Nombre { get; set; }
        public int Album { get; set; }
        public int Medio { get; set; }
        public int Generos { get; set; }
        public string Compositor { get; set; }
        public int Tiempo { get; set; }
        public int Peso { get; set; }
        public decimal Precio { get; set; }
        public List<int> PlayList { get; set; }

    }
}