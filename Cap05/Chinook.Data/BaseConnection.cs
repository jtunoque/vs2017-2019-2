using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data
{
    public class BaseConnection
    {
        public string GetConection()
        {
            //string cadenaConexion 
            //    = "Server=S000-00;DataBase=ChinookSabado;User ID=sa;Password=sql;";
            string cadenaConexion = ConfigurationManager.ConnectionStrings["cnxDB"]
                                    .ConnectionString;


            return cadenaConexion;
        }
    }
}
