using CinPadd2.BotonesComunes;
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
    public partial class EscribirGuiones : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        int idUser;
        public EscribirGuiones(int IdUsuario)
        {
            InitializeComponent();
            this.idUser = IdUsuario;
            llenaTablaGuiones();
        }

        private void llenaTablaGuiones()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            // Consulta SQL para obtener los libros del usuario
            string consultaGuiones = "select * from guiones";
            SqlCommand cmd = new SqlCommand(consultaGuiones, conex);

            // Crear un adaptador de datos y un DataSet para llenar los datos en el DataGridView
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adaptador.Fill(datos);

            // Asignar el DataSet al DataGridView
            dtgGuiones.DataSource = datos.Tables[0];

            conex.Close();
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

        private void btnTodosGuiones_Click(object sender, EventArgs e)
        {
            llenaTablaGuiones();
        }

        private void btnGuionesPropios_Click(object sender, EventArgs e)
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            int codG = obtenerCodGuionista();

            // Consulta SQL para obtener los libros del usuario
            string consultaGuiones = "select * from guiones g where g.guionista = @cod";
            SqlCommand cmd = new SqlCommand(consultaGuiones, conex);
            cmd.Parameters.AddWithValue("@cod", codG);

            // Crear un adaptador de datos y un DataSet para llenar los datos en el DataGridView
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adaptador.Fill(datos);

            // Asignar el DataSet al DataGridView
            dtgGuiones.DataSource = datos.Tables[0];

            conex.Close();
        }

        private int obtenerCodGuionista()
        {
            conex = new SqlConnection(cadena);
            conex.Open();
            string query = "select u.codGuionista from usuarios u where u.cod = @cod";
            using (SqlCommand cmd = new SqlCommand(query, conex))
            {
                cmd.Parameters.AddWithValue("@cod", idUser);
                object result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : 0;
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (!camposNoNulosGuion())
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                conex = new SqlConnection(cadena);
                //abrimos la conexión
                conex.Open();

                //recoger datos
                string nombre = txtNombre.Text.Trim();
                string genero = txtGenero.Text.Trim();
                DateTime año = dtpAño.Value;
                string sinopsis = txtSinopsis.Text.Trim();
                int guionista = obtenerCodGuionista();

                string query = "INSERT INTO guiones (nombre, guionista, genero, año, sinopsis) " +
                           "VALUES (@nombre, @guionista, @genero, @año, @sinopsis)";

                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    // Añadir parámetros
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@guionista", guionista);
                    cmd.Parameters.AddWithValue("@genero", genero);
                    cmd.Parameters.AddWithValue("@año", año);
                    cmd.Parameters.AddWithValue("@sinopsis", sinopsis);

                    // Ejecutar el comando
                    int afectadas = cmd.ExecuteNonQuery();

                    // Mostrar un mensaje de éxito
                    if (afectadas > 0)
                    {
                        MessageBox.Show("Guión publicado con éxito.");
                        llenaTablaGuiones();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema al publicar el guión.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Error en la publicación: " + ex.Message);
            }
            conex.Close();
        }

        private bool camposNoNulosGuion()
        {
            // Verificar los campos no nulos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtGenero.Text) ||
                string.IsNullOrWhiteSpace(txtSinopsis.Text))
            {
                return false;
            }

            return true;
        }
    }
}
