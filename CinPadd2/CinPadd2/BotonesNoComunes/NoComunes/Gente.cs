using CinPadd2.PantallasUsuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinPadd.NoComunes
{
    public partial class Gente : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        int idUser;
        public Gente(int IdUsuario)
        {
            InitializeComponent();
            this.idUser = IdUsuario;

            //esconder los dataGridView
            dtgActores.Visible = false;
            dtgDirectores.Visible = false;
            dtgGuionistas.Visible = false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            //consulta sql para comprobar el tipo de usuario de ese id de usuario
            string compruebaTipo = "select u.tipo, u.cod " +
                " from usuarios u " +
                " where u.cod = @cod ";
            SqlCommand cmd = new SqlCommand(compruebaTipo, conex);
            cmd.Parameters.AddWithValue("@cod", idUser);

            //ejecutar la consulta y obtengo el número de registros afectados
            SqlDataReader reader = cmd.ExecuteReader();
            int cod = -1;
            string usuarioTipo = "";

            if (reader.Read())
            {
                cod = Convert.ToInt32(reader["cod"]);
                usuarioTipo = Convert.ToString(reader["tipo"]);
            }
            reader.Close();

            if (cod != -1)
            {
                // Determinar el tipo de usuario y abrir la pantalla correspondiente
                switch (usuarioTipo)
                {
                    case "Actor":
                        Actores actorForm = new Actores(cod);
                        actorForm.Show();
                        break;
                    case "Director":
                        Directores directorForm = new Directores(cod);
                        directorForm.Show();
                        break;
                    case "Guionista":
                        FormGuionistas form = new FormGuionistas(cod);
                        form.Show();
                        break;
                    case "Aficionado":
                        Aficionados a = new Aficionados(cod);
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
                MessageBox.Show("Hubo un problema en el retroceso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            //cerrar la conexión
            conex.Close();
        }

        private void btnAlgunCambio_Click(object sender, EventArgs e)
        {
            dtgDirectores.Visible = true;
            dtgGuionistas.Visible = false;
            dtgActores.Visible = false;
            llenarTablaDirectores();
        }

        private void llenarTablaDirectores()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            // Consulta SQL para obtener los libros del usuario
            string consultaDirectores = "select * from director";
            SqlCommand cmd = new SqlCommand(consultaDirectores, conex);

            // Crear un adaptador de datos y un DataSet para llenar los datos en el DataGridView
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adaptador.Fill(datos);

            // Asignar el DataSet al DataGridView
            dtgDirectores.DataSource = datos.Tables[0];

            conex.Close();
        }

        private void btnCambioTotal_Click(object sender, EventArgs e)
        {
            dtgActores.Visible = true;
            dtgGuionistas.Visible =false;
            dtgDirectores.Visible=false;
            llenarTablaActores();
        }

        private void llenarTablaActores()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            // Consulta SQL para obtener los libros del usuario
            string consultaActores = "select * from actor";
            SqlCommand cmd = new SqlCommand(consultaActores, conex);

            // Crear un adaptador de datos y un DataSet para llenar los datos en el DataGridView
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adaptador.Fill(datos);

            // Asignar el DataSet al DataGridView
            dtgActores.DataSource = datos.Tables[0];

            conex.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtgGuionistas.Visible = true;
            dtgDirectores.Visible = false;
            dtgActores.Visible=false;
            llenarTablaGuionistas();
        }

        private void llenarTablaGuionistas()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            // Consulta SQL para obtener los libros del usuario
            string consultaGuionistas = "select * from guionista";
            SqlCommand cmd = new SqlCommand(consultaGuionistas, conex);

            // Crear un adaptador de datos y un DataSet para llenar los datos en el DataGridView
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adaptador.Fill(datos);

            // Asignar el DataSet al DataGridView
            dtgGuionistas.DataSource = datos.Tables[0];

            conex.Close();
        }
    }
}
