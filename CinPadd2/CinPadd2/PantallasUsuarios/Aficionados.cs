using CinPadd.NoComunes;
using CinPadd2.BotonesComunes;
using CinPadd2.BotonesNoComunes.NoComunes;
using System;
using System.Collections;
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

namespace CinPadd2.PantallasUsuarios
{
    public partial class Aficionados : Form
    {
        private int idUser;
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;

        //indices
        int indiceP;
        int indiceG;
        int indiceE;
        int indiceA;
        int codActor = 1;

        public Aficionados(int idUsuario)
        {
            InitializeComponent();
            conex = new SqlConnection(cadena);
            
            this.idUser = idUsuario;

            //llenar los indices;
            indiceA = obtenerMinActor();
            indiceE = obtenerMinEstreno();
            indiceG = obtenerMinGuion();
            indiceP = obtenerMinPeli();

            // Ocultar todos los GroupBox al inicio
            gpbPelis.Visible = false;
            gpbActores.Visible = false;
            gpbEstrenos.Visible = false;
            gpbGuiones.Visible = false;

            //ocultar labels de apariencia
            lblOjos.Visible = false;
            lblEtnia.Visible = false;
            lblPelo.Visible=false;
            lblAccesorios.Visible = false;
            lblMedidas.Visible = false;
        }

        private int obtenerMinPeli()
        {
            int codMin = 0;
            try
            {
                conex = new SqlConnection(cadena);
                conex.Open();
                string query = "select MIN(codPeli) from peliculas";

                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    codMin = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el codigo minimo" + ex.Message);
            }
            conex.Close();
            return codMin;
        }

        private int obtenerMinActor()
        {
            int codMin = 0;
            try
            {
                conex = new SqlConnection(cadena);
                conex.Open();
                string query = "select MIN(codActor) from actor";

                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    codMin = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el codigo minimo" + ex.Message);
            }
            conex.Close();
            return codMin;
        }

        private int obtenerMinEstreno()
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
                MessageBox.Show("Error al cargar el codigo minimo" + ex.Message);
            }
            conex.Close();
            return codMin;
        }

        private int obtenerMinGuion()
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
            conex.Close();
            return codMin;
        }



        private void CargaDatosAficionado()
        {
            try
            {
                conex.Open();
                string consultaTema = "SELECT a.temasInteres " +
                    " FROM aficionado a " +
                    " WHERE a.codAficionado = (SELECT u.codAficionado FROM usuarios u WHERE u.cod = @idUser) ";
                SqlCommand comando = new SqlCommand(consultaTema, conex);
                comando.Parameters.AddWithValue("@idUser", idUser);

                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    string temaInteres = lector["temasInteres"].ToString();
                    MostrarGroupBox(temaInteres);
                }
                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }
        }

        private void MostrarGroupBox(string temaInteres)
        {
            

            // Mostrar el GroupBox correspondiente
            switch (temaInteres)
            {
                case "Películas":
                    gpbPelis.Visible = true;
                    cargaPelis(indiceP);
                    break;
                case "Actores":
                    gpbActores.Visible = true;
                    cargaActores(indiceA);
                    break;
                case "Estrenos":
                    gpbEstrenos.Visible = true;
                    cargaEstrenos(indiceE);
                    break;
                case "Guiones":
                    gpbGuiones.Visible = true;
                    CargaGuion(indiceG);
                    break;
                default:
                    MessageBox.Show("Tema de interés no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void cargaActores(int indiceA)
        {
            bool cargado = false;
            try
            {
                using (conex = new SqlConnection(cadena))
                {
                    conex.Open();

                    string cargaActor = "select a.instagram, a.habilidad1, a.habilidad2, a.codActor, u.nombre, u.apellido1 " +
                        " from actor a " +
                        " inner join usuarios u on a.codActor = u.codActor " +
                        " where a.codActor = @indice ";
                    //imprimirlo en pantalla
                    using (SqlCommand cmd = new SqlCommand(cargaActor, conex))
                    {
                        cmd.Parameters.AddWithValue("@indice", indiceA);
                        SqlDataReader lector = cmd.ExecuteReader();


                        if (lector.Read())
                        {
                            codActor = Convert.ToInt32(lector["codActor"]);
                            lblNombreActor.Text = lector["nombre"].ToString() + " "+ lector["apellido1"].ToString();
                            lblRedes.Text = "El instagram del actor: "+lector["instagram"].ToString();
                            lblHabilidades.Text = "Sus habilidades: " + lector["habilidad1"].ToString() + " y " + lector["habilidad2"].ToString();
                            cargado = true;
                        }
                        else
                        {
                            if (indiceA > obtenerMaxActor())
                            {
                                MessageBox.Show("No hay más actores disponibles");
                            }
                            else
                            {
                                indiceA++;
                                cargaActores(indiceA);
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el actor: " + ex.Message);
            }
            conex.Close();
        }

        private int obtenerMaxActor()
        {
            int codMax = 0;
            try
            {
                conex = new SqlConnection(cadena);
                conex.Open();
                string query = "select MAX(codActor) from actor";

                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    codMax = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el codigo maximo" + ex.Message);
            }
            conex.Close();
            return codMax;
        }


        private void cargaEstrenos(int indiceE)
        {
            bool cargado = false;
            try
            {
                using (conex = new SqlConnection(cadena))
                {
                    conex.Open();

                    //Consulta para sacar el primer casting
                    string query = "SELECT c.nombre, c.descripcion, u.nombre AS nombreDirector, u.apellido1 AS apellidoDirector " +
                        " FROM castings c " +
                        " INNER JOIN usuarios u ON c.director = u.codDirector " +
                        " WHERE c.codCasting = @indice ";


                    //imprimirlo en pantalla
                    using (SqlCommand cmd = new SqlCommand(query, conex))
                    {
                        cmd.Parameters.AddWithValue("@indice", indiceE);
                        SqlDataReader lector = cmd.ExecuteReader();


                        if (lector.Read())
                        {
                            lblTituloEstreno.Text = lector["nombre"].ToString();
                            lblDescripcionEstreno.Text = lector["descripcion"].ToString();


                            // Mostrar el nombre del director
                            lblDirectorEstreno.Text = "Director: " + lector["nombreDirector"].ToString() + " " + lector["apellidoDirector"].ToString();
                            cargado = true;
                        }
                        else
                        {
                            if (indiceE > obtenerMaxEstrenos())
                            {
                                // Si no hay más castings, mostrar un mensaje
                                MessageBox.Show("No hay más castings.");
                            }
                            else
                            {
                                indiceE++;
                                cargaEstrenos(indiceE);
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

        private int obtenerMaxEstrenos()
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
                MessageBox.Show("Error al cargar el codigo maximo" + ex.Message);
            }
            conex.Close();
            return codMax;
        }

        private void Aficionados_Load(object sender, EventArgs e)
        {
            CargaDatosAficionado();
        }

        

        private void cargaPelis(int indice)
        {
            bool cargado = false;
            try
            {
                using (conex = new SqlConnection(cadena))
                {
                    conex.Open();

                    //consulta
                    string consultPeli = "select p.titulo, p.descripcion, p.genero, u.nombre As director, u.apellido1 As directorApe, us.nombre As Guionista, us.apellido1 As GuionApe " +
                        " from peliculas p " +
                        " inner join usuarios u on p.director = u.codDirector " +
                        " inner join usuarios us on p.guionista = us.codGuionista " +
                        " where p.codPeli = @indice ";

                    //imprimirlo en pantalla
                    using (SqlCommand cmd = new SqlCommand(consultPeli, conex))
                    {
                        cmd.Parameters.AddWithValue("@indice", indice);
                        SqlDataReader lector = cmd.ExecuteReader();

                        if (lector.Read())
                        {
                            lblTituloPeli.Text = lector["titulo"].ToString();
                            lblDescripcion.Text = lector["descripcion"].ToString();
                            lblGenero.Text = lector["genero"].ToString();
                            lblGuionista.Text = "Escrito por: " + lector["Guionista"].ToString() + " " + lector["GuionApe"].ToString();
                            lblDirector.Text = "Dirigido por: " + lector["director"].ToString() + " " + lector["directorApe"].ToString();
                            cargado = true;
                        }
                        else
                        {
                            if (indice > obtenerMaxPeli())
                            {
                                MessageBox.Show("No hay más películas disponibles");
                            }
                            else
                            {
                                indice++;
                                cargaPelis(indice);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la Película: " + ex.Message);
            }
            conex.Close();
        }

        private int obtenerMaxPeli()
        {
            int codMax = 0;
            try
            {
                conex = new SqlConnection(cadena);
                conex.Open();
                string query = "select MAX(codPeli) from peliculas";

                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    codMax = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el codigo maximo" + ex.Message);
            }
            conex.Close();
            return codMax;
        }


        private void btnAnteriorPeli_Click(object sender, EventArgs e)
        {
            indiceP--;
            if (indiceP == 15) {
                indiceP--;
            }
            cargaPelis(indiceP);
        }

        private void btnSiguientePeli_Click(object sender, EventArgs e)
        {
            indiceP++;
            if (indiceP == 15)
            {
                indiceP++;
            }
            cargaPelis(indiceP);
        }

        private void CargaGuion(int indice)
        {
            bool cargado = false;
            try
            {
                using (conex = new SqlConnection(cadena))
                {
                    conex.Open();

                    //consulta
                    string consultGuion = "select g.nombre, g.sinopsis, u.nombre As escritor, u.apellido1 " +
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
                            lblTituloGuion.Text = lector["nombre"].ToString();
                            lblSinopsis.Text = lector["sinopsis"].ToString();
                            lblGuionistaGuion.Text = "Escrito por: " + lector["escritor"].ToString() + " " + lector["apellido1"].ToString();
                            cargado = true;
                        }
                        else
                        {
                            if (indice > obtenerMaxGuion())
                            {
                                MessageBox.Show("No hay más guiones disponibles");
                            }
                            else
                            {
                                indice++;
                                CargaGuion(indice);
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

        private int obtenerMaxGuion()
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
            conex.Close();
            return codMax;
        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            indiceG--;
            CargaGuion(indiceG);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            indiceG++;
            CargaGuion(indiceG);
        }

        private void btnEstrenoAnterior_Click(object sender, EventArgs e)
        {
            indiceE--;
            cargaEstrenos(indiceE);
        }

        private void btnSiguienteEstreno_Click(object sender, EventArgs e)
        {
            indiceE++;
            cargaEstrenos(indiceE);
        }

        private void btnApariencia_Click(object sender, EventArgs e)
        {
            lblOjos.Visible = true;
            lblEtnia.Visible = true;
            lblPelo.Visible = true;
            lblAccesorios.Visible = true;
            lblMedidas.Visible = true;
            CargaApariencia(codActor);
        }

        private void CargaApariencia(object codActor)
        {
            try
            {
                using (conex = new SqlConnection(cadena))
                {
                    conex.Open();

                    //consulta
                    string consultApariencia = "select a.etnia, a.ojos, a.colorPelo, a.largoPelo, a.tinte, a.tipoPelo, a.tatoo, a.piercing, a.altura, a.medidas " +
                        " from apariencia a " +
                        " where a.codActor = @cod ";

                    //imprimirlo en pantalla
                    using (SqlCommand cmd = new SqlCommand(consultApariencia, conex))
                    {
                        cmd.Parameters.AddWithValue("@cod", codActor);
                        SqlDataReader lector = cmd.ExecuteReader();

                        if (lector.Read())
                        {
                            lblOjos.Text = "Tiene los ojos de color: "+lector["ojos"].ToString();
                            lblEtnia.Text = "Etnia: " + lector["etnia"].ToString();

                            int tinte = Convert.ToInt32(lector["tinte"]);
                            if(tinte == 0)
                            {
                                lblPelo.Text = "Tiene el pelo de color: " + lector["colorPelo"].ToString() + " Largura: " + lector["largoPelo"].ToString() + " Tipo: " + lector["tipoPelo"].ToString() + " Sin tinte.";
                            }
                            else if(tinte == 1)
                            {
                                lblPelo.Text = "Tiene el pelo de color: " + lector["colorPelo"].ToString() + " Largura: " + lector["largoPelo"].ToString() + " Tipo: " + lector["tipoPelo"].ToString() + " Con tinte.";
                            }

                            int tatu = Convert.ToInt32(lector["tatoo"]);
                            int piercing = Convert.ToInt32(lector["piercing"]);
                            if (tatu == 0 && piercing == 0) 
                            {
                                lblAccesorios.Text = "Sin tatuajes y piercings";
                            }
                            else if(tatu == 1 && piercing == 1)
                            {
                                lblAccesorios.Text = "Con tatuajes y piercings";
                            }
                            else if(tatu == 1 && piercing == 0)
                            {
                                lblAccesorios.Text = "Con tatuajes y sin piercings";
                            }
                            else if(tatu == 0 && piercing == 1)
                            {
                                lblAccesorios.Text = "Sin tatuajes y con piercings";
                            }

                            lblMedidas.Text = "Alto: " + lector["altura"].ToString() + " Medidas: " + lector["medidas"].ToString();
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la apariencia: " + ex.Message);
            }
            conex.Close();
        }

        private void btnActorAnterior_Click(object sender, EventArgs e)
        {
            //ocultar labels de apariencia
            lblOjos.Visible = false;
            lblEtnia.Visible = false;
            lblPelo.Visible = false;
            lblAccesorios.Visible = false;
            lblMedidas.Visible = false;

            indiceA--;
            cargaActores(indiceA);
        }

        private void btnSigActor_Click(object sender, EventArgs e)
        {
            //ocultar labels de apariencia
            lblOjos.Visible = false;
            lblEtnia.Visible = false;
            lblPelo.Visible = false;
            lblAccesorios.Visible = false;
            lblMedidas.Visible = false;

            indiceA++;
            cargaActores(indiceA);
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            Perfil p = new Perfil(idUser);
            p.Show();
            this.Close();
        }

        private void btnCriticas_Click(object sender, EventArgs e)
        {
            Criticas criticas = new Criticas(idUser);
            criticas.Show();
            this.Close();
        }

        private void btnGuiones_Click(object sender, EventArgs e)
        {
            VerGuiones guiones = new VerGuiones(idUser);    
            guiones.Show();
            this.Close();
        }

        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            Gente gente = new Gente(idUser);
            gente.Show();
            this.Close();
        }

        private void btnPelis_Click(object sender, EventArgs e)
        {
            Peliculas películas = new Peliculas(idUser);
            películas.Show();
            this.Close();
        }
    }
}
