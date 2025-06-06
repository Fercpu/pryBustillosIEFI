using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryBustillosIEFI
{
    public partial class frmPrincipal : Form
    {
        int Usu;
        string NU;
        string rol;
        public frmPrincipal(int DNI, string Usuario , string Rol)
        {

            InitializeComponent();
            Usu = DNI;
            NU = Usuario;
            rol = Rol;
        }
       
        private void administracioóToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (rol == "Administrador") 
            {
                usuariosTSMI.Visible = true; // 
                auditoriaTSMI.Visible = true;
            }
            else 
            {
                auditoriaTSMI.Visible = true;

            }
            Usuario.Text = "Usuario: " +  NU;
            Fecha.Text = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
            RolTSSL.Text = rol;
        }

        private void auditoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuditoria fg = new frmAuditoria();
            this.Hide();
            fg.ShowDialog();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsBasedeDatos clase = new clsBasedeDatos();
            clase.Auditoria(Usu,"Finalizo Sesion");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Fecha.Text = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void usuariosTSMI_Click(object sender, EventArgs e)
        {
            frmUsuarios lo = new frmUsuarios();
            this.Hide();
            lo.ShowDialog();
        }

        private void Usuario_Click(object sender, EventArgs e)
        {

        }
    }
}
