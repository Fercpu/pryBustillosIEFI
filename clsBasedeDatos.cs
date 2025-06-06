using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pryBustillosIEFI
{
    internal class clsBasedeDatos
    {
        OleDbConnection conexionBD;
        OleDbCommand comandoBD;
        OleDbDataReader lectorBD;

        OleDbDataAdapter adaptadorBD;
        DataSet objDS;

        string rutaArchivo;
        public string estadoConexion;
        public int DNI;
        public string rol;
        public clsBasedeDatos()
        { 
            try
            {
                rutaArchivo = Application.StartupPath + @"..\..\..\Recursos\\BaseIEFI1.accdb";

                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaArchivo;
                conexionBD.Open();

                objDS = new DataSet();
                
                estadoConexion = "Conectado";
            }
            catch (Exception error)
            {
                estadoConexion = error.Message;
            }
        }
        public void ValidarUsuario(string nombreUser, string passUser)
        {
            try
            {
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Usuarios";

                lectorBD = comandoBD.ExecuteReader();

                if (lectorBD.HasRows)
                {
                    while (lectorBD.Read())
                    {
                        if (lectorBD["Usuario"].ToString() == nombreUser && lectorBD["Contraseña"].ToString() == passUser)
                        {
                            int IdRol = Convert.ToInt32(lectorBD["Rol"]);
                            rol = ObtenerRol(IdRol);
                            estadoConexion = "Usuario EXISTE";
                            DNI = Convert.ToInt32(lectorBD["DNI"]);
                            Auditoria(DNI,"Inicio de Sesion");
                             
                        }
                    }
                }

            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }
        }
        public void Auditoria(int Usuario , string Accion)
        {
            try
            {
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Auditorias";

                adaptadorBD = new OleDbDataAdapter(comandoBD);

                adaptadorBD.Fill(objDS, "Auditorias");

                DataTable objTabla = objDS.Tables["Auditorias"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Usuario"] = Usuario;
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Accion"] = Accion;

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(objDS, "Auditorias");

              
            }
            catch (Exception error)
            {

                MessageBox.Show(error.ToString());
            }

        }
        public String ObtenerRol(int IdRol)
        {
            try
            {
                OleDbCommand comandoBDrol;
                OleDbDataReader lectorBDrol; //
                comandoBDrol = new OleDbCommand();

                comandoBDrol.Connection = conexionBD;
                comandoBDrol.CommandType = System.Data.CommandType.TableDirect;
                comandoBDrol.CommandText = "Roles";

                lectorBDrol = comandoBDrol.ExecuteReader();

                if (lectorBDrol.HasRows)
                {
                    while (lectorBDrol.Read())
                    {
                        if (Convert.ToInt32(lectorBDrol["Id"]) == IdRol)
                        {
                            string Rol= lectorBDrol["Rol"].ToString();

                            return Rol;
                        }

                    }
                    
                }
                return null;
            }
            catch (Exception error)
            {

                MessageBox.Show(error.ToString());
                return null;
            }

        }
        public void RecorrerAuditorias(DataGridView grilla)
        {
            try
            {
                grilla.Rows.Clear();
                grilla.Columns.Clear();
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Auditorias";

                grilla.Columns.Add("ID", "ID");
                grilla.Columns.Add("Usuario", "Usuario");
                grilla.Columns.Add("FechaHora", "FechaHora");
                grilla.Columns.Add("Accion", "Accion");

                lectorBD = comandoBD.ExecuteReader();

                if (lectorBD.HasRows)
                {
                    while (lectorBD.Read())
                    {
                        int DNI = Convert.ToInt32(lectorBD["Usuario"].ToString());
                        string Usuario = ObtenerUsuarios(DNI);
                        grilla.Rows.Add(lectorBD["Id"].ToString(), Usuario, lectorBD["FechaHora"].ToString(), lectorBD["Accion"].ToString());
                    }
                }

            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }
        }
        public String ObtenerUsuarios(int DNI)
        {
            try
            {
                OleDbCommand comandoBDus;
                OleDbDataReader lectorBDus;
                comandoBDus = new OleDbCommand();

                comandoBDus.Connection = conexionBD;
                comandoBDus.CommandType = System.Data.CommandType.TableDirect;
                comandoBDus.CommandText = "Usuarios";

                lectorBDus = comandoBDus.ExecuteReader();

                if (lectorBDus.HasRows)
                {
                    while (lectorBDus.Read())
                    {
                        if (Convert.ToInt32(lectorBDus["DNI"]) == DNI)
                        {
                            string Usuario = lectorBDus["Usuario"].ToString();
                            
                            return Usuario;
                        }

                    }

                }
                return null;
            }
            catch (Exception error)
            {

                MessageBox.Show(error.ToString());
                return null;
            }

        }
        public void RecorrerUsuarios(DataGridView grilla)
        {
            try
            {
                grilla.Rows.Clear();
                grilla.Columns.Clear();
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Usuarios";

                grilla.Columns.Add("DNI", "DNI");
                grilla.Columns.Add("Usuario", "Usuario");
                grilla.Columns.Add("Rol", "Rol");
               

                lectorBD = comandoBD.ExecuteReader();

                if (lectorBD.HasRows)
                {
                    while (lectorBD.Read())
                    {
                        //int Rol = Convert.ToInt32(lectorBD["Rol"]);
                        string Rol = ObtenerRol(Convert.ToInt32(lectorBD["Rol"]));// lo primero que hace
                        grilla.Rows.Add(lectorBD["DNI"].ToString(), lectorBD["Usuario"].ToString(), Rol);
                    }
                }

            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }
        }
        public void BuscarUsuarios(string txtUsuario , DataGridView grilla) 
        {
            try
            {
                grilla.Rows.Clear();
                grilla.Columns.Clear();
                comandoBD = new OleDbCommand();
                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = CommandType.Text;
                comandoBD.CommandText = "SELECT * FROM Usuarios WHERE Usuario LIKE @Usuario";// a que tabla apunta
                comandoBD.Parameters.AddWithValue("@Usuario", "%" + txtUsuario + "%");// valor que yo quiero


                grilla.Columns.Add("DNI", "DNI");
                grilla.Columns.Add("Usuario", "Usuario");
                grilla.Columns.Add("Rol", "Rol");


                lectorBD = comandoBD.ExecuteReader();

                if (lectorBD.HasRows)
                {
                    while (lectorBD.Read())
                    {
                        //int Rol = Convert.ToInt32(lectorBD["Rol"]);
                        string Rol = ObtenerRol(Convert.ToInt32(lectorBD["Rol"])); // metodo devuelve string
                        grilla.Rows.Add(lectorBD["DNI"].ToString(), lectorBD["Usuario"].ToString(), Rol);
                    }
                }
            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }
        }
        public void BuscarUsDNI(string txtUsuario)
        {
            try
            {
                
                comandoBD = new OleDbCommand();
                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = CommandType.Text;
                comandoBD.CommandText = "SELECT * FROM Usuarios WHERE Usuario LIKE @Usuario";// a que tabla apunta
                comandoBD.Parameters.AddWithValue("@Usuario", "%" + txtUsuario + "%");// valor que yo quiero


               

                lectorBD = comandoBD.ExecuteReader();

                if (lectorBD.HasRows)
                {
                    while (lectorBD.Read())
                    {
                        //int Rol = Convert.ToInt32(lectorBD["Rol"]);
                        string Rol = ObtenerRol(Convert.ToInt32(lectorBD["Rol"])); // metodo devuelve string
                       
                    }
                }
            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }
        }
        public void CargarCmbRol(ComboBox cmbRol) 
        {
           

            try
            {
                comandoBD = new OleDbCommand();
                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = CommandType.Text;
                comandoBD.CommandText = "SELECT Id, Rol FROM Roles";

                OleDbDataAdapter adaptador = new OleDbDataAdapter(comandoBD);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                cmbRol.DataSource = tabla;
                cmbRol.DisplayMember = "Rol";
                cmbRol.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                estadoConexion = "Error al cargar: " + ex.Message;
            }

        }
        public void BuscarporDNI(int DNI, TextBox txtUsuario, TextBox txtContraseña, ComboBox cmbRol)
        {
            try
            {
                bool Encontro = false;
                OleDbCommand comandoBDus;
                OleDbDataReader lectorBDus;
                comandoBDus = new OleDbCommand();

                comandoBDus.Connection = conexionBD;
                comandoBDus.CommandType = System.Data.CommandType.TableDirect;
                comandoBDus.CommandText = "Usuarios";

                lectorBDus = comandoBDus.ExecuteReader();

                if (lectorBDus.HasRows)
                {
                    while (lectorBDus.Read())
                    {

                        if (Convert.ToInt32(lectorBDus["DNI"]) == DNI)
                        {
                            string Usuario = lectorBDus["Usuario"].ToString();
                            string Contraseña = lectorBDus["Contraseña"].ToString();
                            int Rol = Convert.ToInt32(lectorBDus["Rol"]);
                            txtUsuario.Text = Usuario;
                            txtContraseña.Text = Contraseña;
                            cmbRol.SelectedValue = Rol;
                            Encontro = true;
                        }
                        
                    }
                    if (Encontro == false ) 
                    {
                        MessageBox.Show("No se encontro Usuario Con ese DNI");
                    
                    }
                }
                
            }
            catch (Exception error)
            {

                MessageBox.Show(error.ToString());
                
            }

        }
        public void CargarUsuario(string Nombre, string pass, string cat)
        {
            try
            {
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Usuario";

                adaptadorBD = new OleDbDataAdapter(comandoBD);

                adaptadorBD.Fill(objDS, "Usuario");

                DataTable objTabla = objDS.Tables["Usuario"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Nombre"] = Nombre;
                nuevoRegistro["Contraseña"] = pass;
                nuevoRegistro["Perfil"] = cat;

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(objDS, "Usuario");


            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }
        }
        public void EliminarUsuarioPorDNI(int DNI)
        {
            

            try
            {
                OleDbCommand comandoBDus;
                string consulta = "DELETE FROM Usuarios WHERE DNI = @DNI";
                comandoBDus = new OleDbCommand(consulta, conexionBD);

                comandoBDus.Parameters.AddWithValue("@DNI", DNI);

                int filasAfectadas = comandoBDus.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Usuario eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show("No se encontró el usuario con ese DNI.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al eliminar el usuario: " + error.Message);
            }
        }
        public void ActualizarUsuario(int DNI, string Usuario, string Contraseña, int Rol)
        {

            try
            {
                OleDbCommand comandoBDus;
                string consulta = "UPDATE Usuarios SET Usuario = @usuario, Contraseña = @contraseña, Rol = @rol WHERE DNI = @DNI";

                comandoBDus = new OleDbCommand(consulta, conexionBD);

                comandoBDus.Parameters.AddWithValue("@usuario", Usuario);
                comandoBDus.Parameters.AddWithValue("@contraseña", Contraseña);
                comandoBDus.Parameters.AddWithValue("@rol", Rol);
                comandoBDus.Parameters.AddWithValue("@DNI", DNI);

                int filasAfectadas = comandoBDus.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Usuario actualizado correctamente.");
                }
                else
                {
                    MessageBox.Show("No se encontró un usuario con ese DNI para actualizar.");
                }

                // Liberar el recurso manualmente aquí dentro del try
                comandoBDus.Dispose();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al actualizar usuario: " + error.Message);
            }
        }



    }
}





    