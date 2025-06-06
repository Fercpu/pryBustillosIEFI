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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            clsBasedeDatos BD = new clsBasedeDatos();
            BD.RecorrerUsuarios(dgvLista);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmBMusuarios BM = new frmBMusuarios();
            this.Hide();
            BM.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string Usuarios = txtNombre.Text;
            clsBasedeDatos BD = new clsBasedeDatos();
            BD.BuscarUsuarios(Usuarios, dgvLista);
            btnListadoCompleto.Visible = true;
        }

        private void btnListadoCompleto_Click(object sender, EventArgs e)
        {
            frmUsuarios_Load(sender , e); // Listado completo
            btnListadoCompleto.Visible = false; 

        }

        private void btnAgregarUs_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }
    }
}
