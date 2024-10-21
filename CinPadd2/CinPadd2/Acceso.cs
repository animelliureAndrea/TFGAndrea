using CinPadd2.PantallasUsuarios;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinPadd2
{
    public partial class Acceso : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        public Acceso()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conex = new SqlConnection(cadena);
            //obtener las credenciales
            string user = txtNombre.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            //comprobar que no estén vacíos los campos, ejemplo:
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Introduce un Usuario para poder continuar", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Introduce una Contraseña para poder continuar", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //abrimos la conexión
            conex.Open();

            //objeto comando
            SqlCommand comando = new SqlCommand();
            //consulta sql para verificar las credenciales
            comando.CommandText = "SELECT cod, tipo FROM usuarios WHERE nombreUser = @username AND contraseña = @password";
            comando.Parameters.AddWithValue("@username", user);
            comando.Parameters.AddWithValue("@password", contraseña);

            //asocio la conexion al comando
            comando.Connection = conex;

            //ejecutar la consulta y obtengo el número de registros afectados
            SqlDataReader reader = comando.ExecuteReader();
            int idUsuario = -1;
            string usuarioTipo = "";

            if (reader.Read())
            {
                idUsuario = Convert.ToInt32(reader["cod"]);
                usuarioTipo = Convert.ToString(reader["tipo"]);
            }
            reader.Close();

            if (idUsuario != -1)
            {
                // Determinar el tipo de usuario y abrir la pantalla correspondiente
                switch (usuarioTipo)
                {
                    case "Actor":
                        Actores actorForm = new Actores(idUsuario);
                        actorForm.Show();
                        break;
                    case "Director":
                        Directores directorForm = new Directores(idUsuario);
                        directorForm.Show();
                        break;
                    case "Guionista":
                        FormGuionistas form = new FormGuionistas(idUsuario);
                        form.Show();
                        break;
                    case "Aficionado":
                        Aficionados a = new Aficionados(idUsuario);
                        a.Show();
                        break;
                    default:
                        MessageBox.Show("Tipo de usuario no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Registro r = new Registro();
                r.Show();
                this.Close();
            }
            //cerrar la conexión
            conex.Close();
        }

        

    }
}
