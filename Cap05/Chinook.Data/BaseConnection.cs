using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Configuration;
=======
>>>>>>> 649f73f661e41431d5a0ac1513b7ed345cf432b6
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data
{
    public class BaseConnection
    {
        public string GetConection()
        {
<<<<<<< HEAD
            //string cadenaConexion 
            //    = "Server=S000-00;DataBase=ChinookSabado;User ID=sa;Password=sql;";
            string cadenaConexion = ConfigurationManager.ConnectionStrings["cnxDB"]
                                    .ConnectionString;

=======
            string cadenaConexion 
                = "Server=S000-00;DataBase=ChinookSabado;User ID=sa;Password=sql;";
>>>>>>> 649f73f661e41431d5a0ac1513b7ed345cf432b6

            return cadenaConexion;
        }
    }
}
