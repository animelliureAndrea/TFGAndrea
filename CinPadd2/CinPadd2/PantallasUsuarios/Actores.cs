using CinPadd.NoComunes;
using CinPadd2.BotonesComunes;
using CinPadd2.BotonesNoComunes.NoComunes;
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

namespace CinPadd2.PantallasUsuarios
{
    public partial class Actores : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        int indiceCastingActual;
        int idUsuario;
        int codPeli;
        int interesados;
        int director;
        public Actores(int idUser)
        {
            InitializeComponent();
            idUsuario = idUser;
            indiceCastingActual = obtenerCastingMin();
        }

        private void Actores_Load(object sender, EventArgs e)
        {
            CargarCastingUno(indiceCastingActual);

        }

        private int obtenerCastingMin()
        {
            int codMin = 0;
            try
            {
                conex = new SqlConnection(cadena);
                conex.Open();
                string query = "select MIN(codCasting) from castings";

                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    codMin = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el codigo minimo de casting: " + ex.Message);
            }
            return codMin;
        }

        private void CargarCastingUno(int indice)
        {
            bool castingCargado = false;
            try 
            {
                using (conex = new SqlConnection(cadena)) {
                    conex.Open();

                    //Consulta para sacar el primer casting
                    string query = "SELECT c.nombre, c.descripcion, c.ubicación, c.fecha, c.codPelicula, c.interesados, c.director, u.nombre AS nombreDirector, u.apellido1 AS apellidoDirector " +
                        " FROM castings c " +
                        " INNER JOIN usuarios u ON c.director = u.codDirector " +
                        " WHERE c.codCasting = @indice ";
                    

                    //imprimirlo en pantalla
                    using (SqlCommand cmd = new SqlCommand(query, conex))
                    {
                        cmd.Parameters.AddWithValue("@indice", indice);
                        SqlDataReader lector = cmd.ExecuteReader();
                        

                        if (lector.Read())
                        {
                            interesados = Convert.ToInt32(lector["interesados"]);
                            director = Convert.ToInt32(lector["director"]);
                            lblNombre.Text = lector["nombre"].ToString();
                            lblDescripcion.Text = lector["descripcion"].ToString();
                            lblUbicacion.Text = "Ubicado en: "+ lector["ubicación"].ToString();
                            
                            // Configurar el DateTimePicker con la fecha del casting
                            dtpFecha.Value = (DateTime)lector["fecha"];

                            // Mostrar el nombre del director
                            lblDirector.Text = "Director: " +lector["nombreDirector"].ToString()+" "+ lector["apellidoDirector"].ToString();

                            //Recogemos el código de película para mostrar o no el nombre de está
                            if (lector["codPelicula"] != DBNull.Value)
                            {
                                codPeli = Convert.ToInt32(lector["codPelicula"]);
                            }
                            else
                            {
                                codPeli = 15;
                            }

                            // Si hay un código de película, obtener el nombre de la película
                            if (codPeli != 15)
                            {
                                lector.Close();
                                string nomPeli = "SELECT p.titulo " +
                                    " FROM peliculas p " +
                                    " WHERE p.codPeli = (SELECT c.codPelicula FROM castings c WHERE c.codCasting = @indice)";

                                using(SqlCommand comandoPeli = new SqlCommand(nomPeli, conex))
                                {
                                    comandoPeli.Parameters.AddWithValue("@indice", indice);
                                    string tituloPelicula = comandoPeli.ExecuteScalar()?.ToString();
                                    lblPeli.Text = "Película relacionada: " + tituloPelicula;
                                }
                            
                            }
                            else
                            {
                                lblPeli.Text = "Sin película relaccionada";
                                codPeli = 15;
                            }
                            castingCargado = true;
                        }
                        else
                        {
                            if (indice > obtenerCatingMax())
                            {
                                MessageBox.Show("Has llegado al último casting", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                indice++;
                                CargarCastingUno(indice);
                            }
                        }

                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el casting: " + ex.Message);
            }
            conex.Close();
        }

        private int obtenerCatingMax()
        {
            int codMax = 0;
            try
            {
                conex = new SqlConnection(cadena);
                conex.Open();
                string query = "select MAX(codCasting) from castings";

                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    codMax = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el codigo maximo de casting: " + ex.Message);
            }
            return codMax;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            indiceCastingActual++;
            CargarCastingUno(indiceCastingActual);
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            indiceCastingActual++;
            CargarCastingUno(indiceCastingActual);

            conex = new SqlConnection(cadena);
            conex.Open();

            // Realizar una consulta para obtener el código de actor correspondiente al idUsuario
            string queryActor = "SELECT codActor FROM usuarios WHERE cod = @idUsuario";
            using (SqlCommand cmdActor = new SqlCommand(queryActor, conex))
            {
                cmdActor.Parameters.AddWithValue("@idUsuario", idUsuario);
                int codActor = (int)cmdActor.ExecuteScalar();

                interesados++;

                // Llamar al método para insertar si no existe
                bool insertado = compruebaExistencia(codActor, interesados);

                if (insertado)
                {
                    MessageBox.Show("Casting añadido a la tabla de seleccionados correctamente.");
                    CambioInteresados(interesados, indiceCastingActual);
                }
                else
                {
                    MessageBox.Show("El casting ya existe en la tabla de seleccionados.");
                }
            }

            conex.Close();
        }

        private bool compruebaExistencia(int codActor, int interesados)
        {
            conex = new SqlConnection(cadena);
            conex.Open();

            //recoger datos
            string nombre = lblNombre.Text.Trim();
            string descripcion = lblDescripcion.Text.Trim();
            string ubicacion = lblUbicacion.Text.Trim();
            DateTime fecha = dtpFecha.Value;

            string comprobarCasting = " SELECT COUNT(*) FROM castingSeleccionado WHERE codActor = @codActor AND nombre = @nombre";
            using (SqlCommand cmdComprobar = new SqlCommand(comprobarCasting, conex))
            {
                cmdComprobar.Parameters.AddWithValue("@codActor", codActor);
                cmdComprobar.Parameters.AddWithValue("@nombre", nombre);

                int count = (int)cmdComprobar.ExecuteScalar();

                // Si el casting no existe, inserta
                if (count == 0)
                {
                    string insertaCasting = "INSERT INTO castingSeleccionado (codActor, nombre, descripcion, director, ubicacion, interesados, fecha, codPelicula) " +
                                            "VALUES (@codActor, @nombre, @descripcion, @director, @ubicacion, @interesados, @fecha, @codPelicula)";
                    using (SqlCommand cmdInserta = new SqlCommand(insertaCasting, conex))
                    {
                        cmdInserta.Parameters.AddWithValue("@codActor", codActor);
                        cmdInserta.Parameters.AddWithValue("@nombre", nombre);
                        cmdInserta.Parameters.AddWithValue("@descripcion", descripcion);
                        cmdInserta.Parameters.AddWithValue("@director", director);
                        cmdInserta.Parameters.AddWithValue("@ubicacion", ubicacion);
                        cmdInserta.Parameters.AddWithValue("@interesados", interesados);
                        cmdInserta.Parameters.AddWithValue("@fecha", fecha);
                        cmdInserta.Parameters.AddWithValue("@codPelicula", codPeli);

                        int rowsAffected = cmdInserta.ExecuteNonQuery();

                        // Comprobar si se insertó correctamente
                        return rowsAffected > 0;
                    }
                }
                else
                {
                    return false;
                }
            }

            conex.Close();
        }

        private void CambioInteresados(int interesados, int indiceCastingActual)
        {
            conex = new SqlConnection(cadena);
            conex.Open();
            string cambio = "UPDATE castings " +
                " SET interesados = @interesados " +
                " WHERE codCasting = @indice ";

            using (SqlCommand cmdCambio = new SqlCommand(cambio, conex))
            {
                cmdCambio.Parameters.AddWithValue("@interesados", interesados);
                cmdCambio.Parameters.AddWithValue("@indice", indiceCastingActual);

                // Ejecutar la consulta de cambio
                int rowsAffected = cmdCambio.ExecuteNonQuery();

                // Comprobar si se cambio correctamente
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Número de interesados cambiado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al cambiar el número de interesados.");
                }
            }
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            Perfil p = new Perfil(idUsuario);
            p.Show();
            this.Close();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            CastingSelec castingSelec = new CastingSelec(idUsuario);
            castingSelec.Show();
            this.Close();
        }

        private void btnPelis_Click(object sender, EventArgs e)
        {
            Peliculas películas = new Peliculas(idUsuario);
            películas.Show();
            this.Close();
        }

        private void btnFestival_Click(object sender, EventArgs e)
        {
            Festivales festivales = new Festivales(idUsuario);
            festivales.Show();
            this.Close();
        }
    }
}
