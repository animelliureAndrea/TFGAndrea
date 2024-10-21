using CinPadd2.BotonesComunes;
using CinPadd2.PantallasUsuarios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinPadd2.BotonesNoComunes.NoComunes
{
    public partial class AddPelicula : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        int idUser;
        public AddPelicula(int IdUsuario)
        {
            InitializeComponent();
            this.idUser = IdUsuario;
            llenarGuiones();
            llenarPelis();
            llenarGuionista();
        }

        private void llenarGuiones()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            // Limpiamos los elementos previos
            cmbGuion.Items.Clear();

            // Consulta 
            string titulos = "select g.nombre from guiones g ";

            SqlCommand cmd = new SqlCommand(titulos, conex);
            SqlDataReader lector = cmd.ExecuteReader();

            // Iteramos sobre los resultados de la consulta
            while (lector.Read())
            {
                // Agregamos cada título al ComboBox
                string titulo = lector["nombre"].ToString();
                cmbGuion.Items.Add(titulo);
            }

            lector.Close();
            conex.Close();
        }

        private void llenarPelis()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            // Consulta SQL para obtener los libros del usuario
            string consultaPelis = "select * from peliculas";
            SqlCommand cmd = new SqlCommand(consultaPelis, conex);

            // Crear un adaptador de datos y un DataSet para llenar los datos en el DataGridView
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adaptador.Fill(datos);

            // Asignar el DataSet al DataGridView
            dtgPelis.DataSource = datos.Tables[0];

            conex.Close();
        }

        private void llenarGuionista()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            // Limpiamos los elementos previos
            cmbGuionista.Items.Clear();

            // Consulta 
            string titulos = "select u.nombre, u.apellido1 from usuarios u where u.tipo = 'Guionista'";

            SqlCommand cmd = new SqlCommand(titulos, conex);
            SqlDataReader lector = cmd.ExecuteReader();

            // Iteramos sobre los resultados de la consulta
            while (lector.Read())
            {
                // Agregamos cada título al ComboBox
                string titulo = lector["nombre"].ToString() + " " + lector["apellido1"].ToString();
                cmbGuionista.Items.Add(titulo);
            }

            lector.Close();
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

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            if (CamposVacios())
            {
                MessageBox.Show("Por favor, rellena todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            //recoger datos
            string titulo = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            int actores = (int)numActores.Value;
            int director = obtenerCodDirector();
            string guionista = cmbGuionista.Text.Trim();
            int codGuionista = obtenerCodGuinista(guionista);
            string guion = cmbGuion.Text.Trim();
            int codGuion = obtenerCodGuion(guion);
            string genero = txtGenero.Text.Trim();
            DateTime fecha = dtpFecha.Value;

            string inserta = "INSERT INTO peliculas (titulo, descripcion, nºActores, director, guionista, guion, genero, año) " +
                " VALUES (@titulo, @descripcion, @nºActores, @director, @guionista, @guion, @genero, @año)";


            using (SqlCommand cmd = new SqlCommand(inserta, conex))
            {
                // Añadir parámetros
                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@nºActores", director);
                cmd.Parameters.AddWithValue("@director", director);
                cmd.Parameters.AddWithValue("@guionista", codGuionista);
                cmd.Parameters.AddWithValue("@guion", codGuion);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@año", fecha);

                // Ejecutar el comando
                int afectadas = cmd.ExecuteNonQuery();

                // Mostrar un mensaje de éxito
                if (afectadas > 0)
                {
                    MessageBox.Show("Película publicada con éxito.");
                    llenarPelis();
                }
                else
                {
                    MessageBox.Show("Hubo un problema al publicar la película.");
                }
            }
            conex.Close();
        }

        private int obtenerCodGuion(string guion)
        {
            conex = new SqlConnection(cadena);
            conex.Open();
            string query = "select g.codGuion from guiones g where g.nombre = @nombre";
            using (SqlCommand cmd = new SqlCommand(query, conex))
            {
                cmd.Parameters.AddWithValue("@nombre", guion);
                object result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : 0;
            }
        }

        private int obtenerCodGuinista(string guionista)
        {
            // Extraer el nombre de la cadena guionista
            string nombre = guionista.Split(' ')[0];

            using (SqlConnection conex = new SqlConnection(cadena))
            {
                conex.Open();
                // Consulta para obtener el código del guionista por nombre
                string query = "SELECT u.codGuionista FROM usuarios u WHERE u.nombre = @nombre";
                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    object result = cmd.ExecuteScalar();
                    return (result != null) ? Convert.ToInt32(result) : 0;
                }
            }
        }

        private int obtenerCodDirector()
        {
            conex = new SqlConnection(cadena);
            conex.Open();
            string query = "select u.codDirector from usuarios u where u.cod = @cod";
            using (SqlCommand cmd = new SqlCommand(query, conex))
            {
                cmd.Parameters.AddWithValue("@cod", idUser);
                object result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : 0;
            }
        }

        private bool CamposVacios()
        {
            // Verificar si los campos están vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(cmbGuionista.Text) ||
                string.IsNullOrWhiteSpace(cmbGuion.Text) ||
                string.IsNullOrWhiteSpace(txtGenero.Text) ||
                numActores.Value == 0)
            {
                return true;
            }
            return false;
        }
    }
}
