namespace pryBustillosIEFI
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracioóToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.auditoriaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Usuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.Fecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.RolTSSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tareasToolStripMenuItem,
            this.administracioóToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tareasToolStripMenuItem
            // 
            this.tareasToolStripMenuItem.Name = "tareasToolStripMenuItem";
            this.tareasToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.tareasToolStripMenuItem.Text = "Tareas";
            // 
            // administracioóToolStripMenuItem
            // 
            this.administracioóToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosTSMI,
            this.auditoriaTSMI});
            this.administracioóToolStripMenuItem.Name = "administracioóToolStripMenuItem";
            this.administracioóToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administracioóToolStripMenuItem.Text = "Administración";
            this.administracioóToolStripMenuItem.Click += new System.EventHandler(this.administracioóToolStripMenuItem_Click);
            // 
            // usuariosTSMI
            // 
            this.usuariosTSMI.Name = "usuariosTSMI";
            this.usuariosTSMI.Size = new System.Drawing.Size(180, 22);
            this.usuariosTSMI.Text = "Usuarios";
            this.usuariosTSMI.Visible = false;
            this.usuariosTSMI.Click += new System.EventHandler(this.usuariosTSMI_Click);
            // 
            // auditoriaTSMI
            // 
            this.auditoriaTSMI.Name = "auditoriaTSMI";
            this.auditoriaTSMI.Size = new System.Drawing.Size(180, 22);
            this.auditoriaTSMI.Text = "Auditoria";
            this.auditoriaTSMI.Visible = false;
            this.auditoriaTSMI.Click += new System.EventHandler(this.auditoriaToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Usuario,
            this.Fecha,
            this.RolTSSL});
            this.statusStrip1.Location = new System.Drawing.Point(0, 295);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(616, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // Usuario
            // 
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(47, 17);
            this.Usuario.Text = "Usuario";
            this.Usuario.Click += new System.EventHandler(this.Usuario_Click);
            // 
            // Fecha
            // 
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(38, 17);
            this.Fecha.Text = "Fecha";
            // 
            // RolTSSL
            // 
            this.RolTSSL.Name = "RolTSSL";
            this.RolTSSL.Size = new System.Drawing.Size(118, 17);
            this.RolTSSL.Text = "toolStripStatusLabel1";
            this.RolTSSL.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 317);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tareasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracioóToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosTSMI;
        private System.Windows.Forms.ToolStripMenuItem auditoriaTSMI;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Usuario;
        private System.Windows.Forms.ToolStripStatusLabel Fecha;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel RolTSSL;
    }
}