using CinPadd2.PantallasUsuarios;
using CrystalDecisions.CrystalReports.Engine;
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
    public partial class Criticas : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        int idUser;
        public Criticas(int IdUsuario)
        {
            InitializeComponent();
            this.idUser = IdUsuario;
            llenarTablaCriticas();
            llenarTituloPelis();
        }

        private void llenarTituloPelis()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            // Limpiamos los elementos previos
            cmbPelis.Items.Clear();

            // Consulta 
            string titulos = "select p.titulo from peliculas p";

            SqlCommand cmd = new SqlCommand(titulos, conex);
            SqlDataReader lector = cmd.ExecuteReader();

            // Iteramos sobre los resultados de la consulta
            while (lector.Read())
            {
                // Agregamos cada título al ComboBox
                string titulo = lector["titulo"].ToString();
                cmbPelis.Items.Add(titulo);
            }

            lector.Close();
            conex.Close();
        }

            private void llenarTablaCriticas()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            // Consulta SQL para obtener los libros del usuario
            string consultaCriticas = "select * from criticas";
            SqlCommand cmd = new SqlCommand(consultaCriticas, conex);

            // Crear un adaptador de datos y un DataSet para llenar los datos en el DataGridView
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            // Asignar el DataSet al DataGridView
            dtgCriticas.DataSource = dataSet.Tables[0];

            //cerrar la conexión
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
            if (!camposNoNulosCritica())
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
                int puntuacion = (int)numPuntuacion.Value;
                string pelicula = cmbPelis.SelectedItem.ToString();
                string cmentario = txtCritica.Text.Trim();
                int codPelicula = obtenerCodigoPelicula(pelicula);

                string query = "INSERT INTO criticas (codPelicula, codUsuario, puntuacion, comentario) " +
                           "VALUES (@codPelicula, @codUsuario, @puntuacion, @comentario)";

                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    // Añadir parámetros
                    cmd.Parameters.AddWithValue("@codPelicula", codPelicula);
                    cmd.Parameters.AddWithValue("@codUsuario", idUser);
                    cmd.Parameters.AddWithValue("@puntuacion", puntuacion);
                    cmd.Parameters.AddWithValue("@comentario", cmentario);

                    // Ejecutar el comando
                    int afectadas = cmd.ExecuteNonQuery();

                    // Mostrar un mensaje de éxito
                    if (afectadas > 0)
                    {
                        MessageBox.Show("Crítica publicada con éxito.");
                        llenarTablaCriticas();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema al publicar la crítica.");
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

        private bool camposNoNulosCritica()
        {
            // Verificar los campos no nulos
            if (cmbPelis.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtCritica.Text))
            {
                return false;
            }

            return true;
        }

        private int obtenerCodigoPelicula(string pelicula)
        {
            conex = new SqlConnection(cadena);
            conex.Open();
            string query = "SELECT p.codPeli FROM peliculas p WHERE p.titulo = @nombrePelicula";
            using (SqlCommand cmd = new SqlCommand(query, conex))
            {
                cmd.Parameters.AddWithValue("@nombrePelicula", pelicula);
                object result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : 0;
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                string pelicula = cmbPelis.SelectedItem.ToString();
                // Obtener el código de la película basado en su nombre
                int codPelicula = obtenerCodigoPelicula(pelicula);

                // Buscar y seleccionar la fila correspondiente
                foreach (DataGridViewRow row in dtgCriticas.Rows)
                {
                    if (row.Cells["codPelicula"].Value != null && (int)row.Cells["codPelicula"].Value == codPelicula)
                    {
                        row.Selected = true;
                        dtgCriticas.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Error en la busqueda: " + ex.Message);
            }
        }

        private void btnCriticasPropias_Click(object sender, EventArgs e)
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            // Consulta SQL para obtener los libros del usuario
            string consultaCriticas = "select * from criticas where codUsuario = @cod";
            SqlCommand cmd = new SqlCommand(consultaCriticas, conex);
            cmd.Parameters.AddWithValue("@cod", idUser);

            // Crear un adaptador de datos y un DataSet para llenar los datos en el DataGridView
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            // Asignar el DataSet al DataGridView
            dtgCriticas.DataSource = dataSet.Tables[0];

            //cerrar la conexión
            conex.Close();
        }

        private void btnTodas_Click(object sender, EventArgs e)
        {
            llenarTablaCriticas();
        }
    }
}
