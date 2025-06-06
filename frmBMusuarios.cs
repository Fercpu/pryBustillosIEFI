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
            int DNI = Convert.ToInt32(txtDNI.Text);

            clsBasedeDatos BD = new clsBasedeDatos();
            BD.BuscarporDNI(DNI, txtUsuario , txtContraseña , cmbRol );
        }

        private void frmBMusuarios_Load(object sender, EventArgs e)
        {
            clsBasedeDatos BD = new clsBasedeDatos();
            BD.CargarCmbRol(cmbRol);
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtUsuario.Enabled = true;
            txtContraseña.Enabled = true; 
            cmbRol.Enabled = true;
            btnGuardarCambios.Visible = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(txtDNI.Text);

            clsBasedeDatos BD = new clsBasedeDatos();
            BD.EliminarUsuarioPorDNI(DNI);
            txtDNI.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(txtDNI.Text);
            string Usuario = txtUsuario.Text;
            string Contraseña = txtContraseña.Text;
            int Rol = cmbRol.SelectedIndex;

            clsBasedeDatos BD = new clsBasedeDatos();
            BD.ActualizarUsuario(DNI , Usuario , Contraseña , Rol);
            txtDNI.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // permite ingresar datos numericos
            {
                e.Handled = true; // Bloquea la tecla
            }
        }
    }
}
