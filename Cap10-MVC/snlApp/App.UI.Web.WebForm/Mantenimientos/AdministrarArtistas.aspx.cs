using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.Web.WebForm.Mantenimientos
{
    public partial class AdministrarArtistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BuscarDatos();
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void BuscarDatos()
        {
            //Invocando al método del servicio web
            var wcfClient = new MantenimientosService.MantenimientosServiceClient();
            var listado = wcfClient.GetArtistAll(txtFiltroPorNombre.Text.Trim());

            gvListado.DataSource = listado;
            gvListado.DataBind();
        }
    }
}