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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            clsBasedeDatos BD = new clsBasedeDatos();
            lblCon.Text = BD.estadoConexion;
        
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text;
                string contraseña = txtContraseña.Text;

                clsBasedeDatos BD = new clsBasedeDatos();
                BD.ValidarUsuario(usuario, contraseña);
                if (BD.estadoConexion == "Usuario EXISTE")
                {
                    int DNI = BD.DNI;
                    string rol = BD.rol;
                    this.Hide();
                    frmPrincipal frm = new frmPrincipal(DNI,usuario,rol);
                    frm.ShowDialog();
                }
                else 
                {
                    MessageBox.Show("Usuario o contraseña Incorrectos");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
    }
}
