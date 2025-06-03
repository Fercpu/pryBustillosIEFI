using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryBustillosIEFI
{
    public partial class frmBMusuarios : Form
    {
        public frmBMusuarios()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void frmBMusuarios_Load(object sender, EventArgs e)
        {
            clsBasedeDatos BD = new clsBasedeDatos();
            BD.CargarCmbRol(cmbRol);
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
