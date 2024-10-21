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
    public partial class Directores : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        private int idUser;
        int indiceG;

        public Directores(int idUsuario)
        {
            InitializeComponent();
            idUser = idUsuario;
            indiceG = obtenerMin();
            cargaGuion(indiceG);
            cargaCasting(idUser);
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


        private void cargaCasting(int idUser)
        {
            int codDirector = ObtenerCodDirector(idUser);
            try { 
                using (conex = new SqlConnection(cadena))
                {
                    conex.Open();

                    string consultaCasting = "select cs.nombre, cs.interesados, u.nombre AS actor, u.apellido1 " +
                        " from castingSeleccionado cs " +
                        " inner join usuarios u on cs.codActor = u.codActor " +
                        " where cs.director = @cod";

                    StringBuilder sb = new StringBuilder();
                    using (SqlCommand cmd = new SqlCommand(consultaCasting, conex))
                    {
                        cmd.Parameters.AddWithValue("@cod", codDirector);
                        SqlDataReader lector = cmd.ExecuteReader();

                        if (lector.HasRows)
                        {
                            while (lector.Read())
                            {
                                sb.AppendLine($"Nombre del casting: {lector["nombre"]}");
                                sb.AppendLine($"Número de interesados: {lector["interesados"]}");
                                sb.AppendLine($"Nombre de los interesados: {lector["actor"]} {lector["apellido1"]}");
                                sb.AppendLine();
                            }
                            lblInfo.Text = sb.ToString();
                        }
                        else
                        {
                            lblInfo.Text = "No hay más castings disponibles";
                        }
                    }
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el Casting: " + ex.Message);
            }
            conex.Close();
        }

        private int ObtenerCodDirector(int idUsuario)
        {
            int codDirector = -1;
            try
            {
                using (conex = new SqlConnection(cadena))
                {
                    conex.Open();
                    string consulta = "SELECT codDirector FROM usuarios WHERE cod = @idUsuario";

                    using (SqlCommand cmd = new SqlCommand(consulta, conex))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        SqlDataReader lector = cmd.ExecuteReader();

                        if (lector.Read())
                        {
                            codDirector = Convert.ToInt32(lector["codDirector"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el código del director: " + ex.Message);
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
            return codDirector;
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
                    string consultGuion = "select g.nombre, g.sinopsis, u.nombre AS nomGuionista, u.apellido1 " +
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
                            lblGuionista.Text = lector["nomGuionista"].ToString() + " " + lector["apellido1"].ToString();
                            cargado = true;
                        }
                        else {
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


        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            indiceG++;
            cargaGuion(indiceG);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            indiceG--;
            cargaGuion(indiceG);
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            Perfil p = new Perfil(idUser);
            p.Show();
            this.Close();
        }

        private void btnAddCasting_Click(object sender, EventArgs e)
        {
            AddCasting addCasting = new AddCasting(idUser);
            addCasting.Show();
            this.Close();
        }

        private void btnGuiones_Click(object sender, EventArgs e)
        {
            EscribirGuiones guiones = new EscribirGuiones(idUser);
            guiones.Show();
            this.Close();
        }

        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            Gente gente = new Gente(idUser);
            gente.Show();
            this.Close();
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            Planificación plan = new Planificación(idUser);
            plan.Show();
            this.Close();
        }

        private void btnFestival_Click(object sender, EventArgs e)
        {
            Festivales f = new Festivales(idUser);
            f.Show();
            this.Close();
        }

        private void btnProductora_Click(object sender, EventArgs e)
        {
            Productoras productoras = new Productoras(idUser);
            productoras.Show();
            this.Close();
        }

        private void btnEscenarios_Click(object sender, EventArgs e)
        {
            Escenarios escenarios = new Escenarios(idUser);
            escenarios.Show();
            this.Close();
        }

        private void btnCriticas_Click(object sender, EventArgs e)
        {
            Criticas criticas = new Criticas(idUser);
            criticas.Show();
            this.Close(); 
        }

        private void btnPelis_Click(object sender, EventArgs e)
        {
            AddPelicula películas = new AddPelicula(idUser);
            películas.Show();
            this.Close();
        }
    }
}
