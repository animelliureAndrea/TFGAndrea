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
    public partial class Festivales : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        int idUser;
        int indice;
        int inciceFoto = 0;
        // Lista de rutas de imágenes
        private List<string> imagePaths;
        public Festivales(int IdUsuario)
        {
            InitializeComponent();
            this.idUser = IdUsuario;
            indice = obtenerMin();
            cargarFestival(indice);
            llenarListaFotos();

            // Mostrar la primera imagen
            if (imagePaths.Count > 0)
            {
                pbFeztival.ImageLocation = imagePaths[inciceFoto];
            }
        }

        private int obtenerMin()
        {
            int codMin = 0;
            try
            {
                conex = new SqlConnection(cadena);
                conex.Open();
                string query = "select MIN(codFestival) from festivales";

                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    codMin = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el codigo minimo" + ex.Message);
            }
            return codMin;
        }


        private void llenarListaFotos()
        {
            imagePaths = new List<string>
            {
                "D:\\23-24\\tfg\\imágenes\\festi.jpg",
                "D:\\23-24\\tfg\\imágenes\\festi2.jpg",
                "D:\\23-24\\tfg\\imágenes\\festi3.jpg",
                "D:\\23-24\\tfg\\imágenes\\festi4.jpg",
                "D:\\23-24\\tfg\\imágenes\\festi5.jpg"
            };
        }

        private void cargarFestival(int indice)
        {
            bool cargado = false;
            try
            {
                using (conex = new SqlConnection(cadena))
                {
                    conex.Open();

                    //consulta
                    string consultFesti = " select f.nombre, f.fecha, f.ubicacion, f.NºPeliculasPresentadas " +
                        " from festivales f " +
                        " where f.codFestival = @indice ";

                    //imprimirlo en pantalla
                    using (SqlCommand cmd = new SqlCommand(consultFesti, conex))
                    {
                        cmd.Parameters.AddWithValue("@indice", indice);
                        SqlDataReader lector = cmd.ExecuteReader();

                        if (lector.Read())
                        {
                            lblNombre.Text = lector["nombre"].ToString();
                            dtpFecha.Value = (DateTime)lector["fecha"];
                            lblUbicacin.Text = "Ubicación del evento: "+lector["ubicacion"].ToString();
                            lblPelis.Text = "Número de películas presentadas: " + lector["NºPeliculasPresentadas"].ToString();
                            cargado = true;
                        }
                        else
                        {
                            if (indice > obtenerMax())
                            {
                                MessageBox.Show("No hay más festivales disponibles");
                            }
                            else
                            {
                                indice++;
                                cargarFestival(indice);
                            }
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el festival: " + ex.Message);
            }
            conex.Close();
        }

        private int obtenerMax()
        {
            int codMax = 0;
            try
            {
                conex = new SqlConnection(cadena);
                conex.Open();
                string query = "select MAX(codFestival) from festivales";

                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    codMax = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el codigo maximo" + ex.Message);
            }
            return codMax;
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

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            indice--;
            cargarFestival(indice);

            // Decrementar el índice y asegurarse de que no sea menor que 0
            inciceFoto = (inciceFoto - 1 + imagePaths.Count) % imagePaths.Count;
            // Actualizar el PictureBox con la nueva imagen
            pbFeztival.ImageLocation = imagePaths[inciceFoto];
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            indice++;
            cargarFestival(indice);

            // Incrementar el índice y asegurarse de que no exceda el número de imágenes
            inciceFoto = (inciceFoto + 1) % imagePaths.Count;
            // Actualizar el PictureBox con la nueva imagen
            pbFeztival.ImageLocation = imagePaths[inciceFoto];
        }
    }
}
