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

namespace CinPadd2.BotonesComunes
{
    public partial class Peliculas : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        int idUser;
        int indice;
        public Peliculas(int IdUsuario)
        {
            InitializeComponent();
            this.idUser = IdUsuario;
            indice = obtenerMin();
            cargaPelis(indice);
        }

        private int obtenerMin()
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
            return codMin;
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
                Registro r = new Registro();
                r.Show();
                this.Close();
            }
            //cerrar la conexión
            conex.Close();
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
                    string consultPeli = " select p.titulo, p.descripcion, p.genero, u.nombre As director, " +
                        " u.apellido1 As directorApe, us.nombre As Guionista, us.apellido1 As GuionApe, " +
                        " p.nºActores, p.año " +
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
                            lblTitulo.Text = lector["titulo"].ToString();
                            lblDescripción.Text = lector["descripcion"].ToString();
                            lblGenero.Text = "Genero: " + lector["genero"].ToString();
                            lblActores.Text = "Número de actores: "+lector["nºActores"].ToString();
                            lblDirector.Text = "Director: "+lector["director"].ToString() + " " + lector["directorApe"].ToString();
                            lblGuion.Text = "Guionista: "+lector["Guionista"].ToString() + " " + lector["GuionApe"].ToString();
                            dtpAño.Value = (DateTime)lector["año"];
                            cargado = true;
                        }
                        else
                        {
                            if (indice > obtenerMax())
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

        private int obtenerMax()
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
            return codMax;
        }

        private void btnAnteriorPeli_Click(object sender, EventArgs e)
        {
            indice--;
            if (indice == 15)
            {
                indice--;
            }
            cargaPelis(indice);
        }

        private void btnSiguientePeli_Click(object sender, EventArgs e)
        {
            indice++;
            if (indice == 15)
            {
                indice++;
            }
            cargaPelis(indice);
        }
    }
}
