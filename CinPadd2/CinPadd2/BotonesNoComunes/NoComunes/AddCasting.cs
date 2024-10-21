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

namespace CinPadd2.BotonesNoComunes.NoComunes
{
    public partial class AddCasting : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        int idUser;
        public AddCasting(int IdUsuario)
        {
            InitializeComponent();
            this.idUser = IdUsuario;
            llenarTablaCasting();
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


        private void llenarTablaCasting()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            // Consulta SQL para obtener los libros del usuario
            string consultaCasting = "select * from castings";
            SqlCommand cmd = new SqlCommand(consultaCasting, conex);

            // Crear un adaptador de datos y un DataSet para llenar los datos en el DataGridView
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adaptador.Fill(datos);

            // Asignar el DataSet al DataGridView
            dtgCastings.DataSource = datos.Tables[0];

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
            if (!camposNoNulosPublicar())
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            //recoger datos
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            int director = obtenerCodDirector();
            string ubicacion = txtLugar.Text.Trim();
            int interesados = 0; //el casting recién creado no tiene interesados en el
            DateTime fecha = dtpFecha.Value;

            //si hay película insertamos de una manera y si no de otra
            if (chbSinPeli.Checked)
            {
                string query = "INSERT INTO castings (nombre, descripcion, director, ubicación, interesados, fecha) " +
                           "VALUES (@nombre, @descripcion, @director, @ubicacion, @interesados, @fecha)";

                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    // Añadir parámetros
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@director", director);
                    cmd.Parameters.AddWithValue("@ubicacion", ubicacion);
                    cmd.Parameters.AddWithValue("@interesados", interesados);
                    cmd.Parameters.AddWithValue("@fecha", fecha);

                    // Ejecutar el comando
                    int afectadas = cmd.ExecuteNonQuery();

                    // Mostrar un mensaje de éxito
                    if (afectadas > 0)
                    {
                        MessageBox.Show("Casting publicado con éxito.");
                        llenarTablaCasting();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema al publicar el casting.");
                    }
                }
            }else if (chbConPeli.Checked)
            {
                //recoger la película
                string pelicula = cmbPelis.Text.Trim();
                //sacar el codigo de está
                int codPeli = obtenerCodigoPelicula(pelicula);

                //insertar
                string query = "INSERT INTO castings (nombre, descripcion, director, ubicación, interesados, fecha, codPelicula) " +
                           "VALUES (@nombre, @descripcion, @director, @ubicacion, @interesados, @fecha, @codPelicula)";

                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    // Añadir parámetros
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@director", director);
                    cmd.Parameters.AddWithValue("@ubicacion", ubicacion);
                    cmd.Parameters.AddWithValue("@interesados", interesados);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@codPelicula", codPeli);

                    // Ejecutar el comando
                    int afectadas = cmd.ExecuteNonQuery();

                    // Mostrar un mensaje de éxito
                    if (afectadas > 0)
                    {
                        MessageBox.Show("Casting publicado con éxito.");
                        llenarTablaCasting();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema al publicar el casting.");
                    }
                }
            }

            conex.Close();
        }

        private bool camposNoNulosPublicar()
        {
            // Verificar los campos no nulos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtLugar.Text))
            {
                return false;
            }

            // Verificar si se ha seleccionado una película
            if (chbConPeli.Checked && string.IsNullOrWhiteSpace(cmbPelis.Text))
            {
                return false;
            }

            return true;
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
    }
}
