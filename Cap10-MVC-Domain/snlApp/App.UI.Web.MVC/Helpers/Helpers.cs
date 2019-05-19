using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.UI.Web.MVC.Helpers
{
    public class Helpers
    {
        public static string FormatFecha(DateTime? date)
        {
            string dateString = "";
            if(date.HasValue)
            {
                dateString = date.Value.ToString("dd/MM/yyyy");
            }

            return dateString;
        }

    }
}