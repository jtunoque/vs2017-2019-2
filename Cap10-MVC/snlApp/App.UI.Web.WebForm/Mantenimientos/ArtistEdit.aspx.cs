using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.Web.WebForm.Mantenimientos
{
    public partial class ArtistEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetArtist();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var client = new MantenimientosService
                       .MantenimientosServiceClient();

            var artist = new Artist();
            artist.Name = txtName.Text;
            artist.ArtistId = Convert.ToInt32(Request.QueryString["id"]);

            if(client.SaveArtist(artist))
            {
                Response.Redirect("AdministrarArtistas.aspx");
            }
        }

        private void GetArtist()
        {
            //En modo edición
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                var client = new MantenimientosService
                            .MantenimientosServiceClient();
                var artist = client.GetArtist(id);

                ////Asignando los valores a los controles
                txtName.Text = artist.Name;
            }

        }
    }
}