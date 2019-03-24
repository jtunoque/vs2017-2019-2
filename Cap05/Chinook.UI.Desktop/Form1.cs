using Chinook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinook.UI.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvListado.AutoGenerateColumns = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var da = new ArtistDA();
            var model = da.GetsWithParam($"{txtFiltroPorNombre.Text.Trim()}%");
            dgvListado.DataSource = model;
            dgvListado.Refresh();
        }
    }
}
