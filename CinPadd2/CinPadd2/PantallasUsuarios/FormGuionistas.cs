using CinPadd.NoComunes;
using CinPadd2.BotonesComunes;
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
    public partial class FormGuionistas : Form
    {
        private int idUser;
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        int indiceG;
        public FormGuionistas(int idUsuario)
        {
            InitializeComponent();
            indiceG = obtenerMin();
            cargaGuion(indiceG);
            this.idUser = idUsuario;
        }

        private int obtenerMin()
        {
            int codMin = 0;
            try
            {
                conex = new SqlConnection(cadena);
                conex.Open();
                string query = "select MIN(codGuion) from guiones";

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

        private void cargaGuion(int indice)
        {
            bool cargado = false;
            try
            {
                using (conex = new SqlConnection(cadena))
                {
                    conex.Open();

                    //consulta
                    string consultGuion = "select g.nombre, g.sinopsis, u.nombre As usuario, u.apellido1 " +
                        " from guiones g " +
                        " INNER JOIN usuarios u ON g.guionista = u.codGuionista " +
                        " where g.codGuion = @indice";

                    //imprimirlo en pantalla
                    using (SqlCommand cmd = new SqlCommand(consultGuion, conex))
                    {
                        cmd.Parameters.AddWithValue("@indice", indice);
                        SqlDataReader lector = cmd.ExecuteReader();

                        if (lector.Read())
                        {
                            lblTitulo.Text = lector["nombre"].ToString();
                            lblSinopsis.Text = lector["sinopsis"].ToString();
                            lblGuionista.Text = "Escrito por: "+lector["usuario"].ToString() + " " + lector["apellido1"].ToString();
                            cargado = true;
                        }
                        else
                        {
                            if (indice > obtenerMax())
                            {
                                MessageBox.Show("No hay más guiones disponibles");
                            }
                            else
                            {
                                indice++;
                                cargaGuion(indice);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el Guión: " + ex.Message);
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
                string query = "select MAX(codGuion) from guiones";

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

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            indiceG--;
            cargaGuion(indiceG);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            indiceG++;
            cargaGuion(indiceG);
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            Perfil p = new Perfil(idUser);
            p.Show();
            this.Close();
        }

        private void btnPelis_Click(object sender, EventArgs e)
        {
            Peliculas películas = new Peliculas(idUser);
            películas.Show(); 
            this.Close();
        }

        private void btnFestival_Click(object sender, EventArgs e)
        {
            Festivales festivales = new Festivales(idUser);
            festivales.Show();
            this.Close();
        }

        private void btnGuion_Click(object sender, EventArgs e)
        {
            EscribirGuiones guiones = new EscribirGuiones(idUser);
            guiones.Show();
            this.Close();
        }
    }
}
