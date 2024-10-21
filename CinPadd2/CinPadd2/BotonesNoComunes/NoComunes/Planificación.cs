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
    public partial class Planificación : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        int idUser;
        public Planificación(int IdUsuario)
        {
            InitializeComponent();
            this.idUser = IdUsuario;
            llenarTablaPlanes();
        }

        private void llenarTablaPlanes()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            int codD = obtenerCodDirector();

            // Consulta SQL para obtener los libros del usuario
            string consultaCasting = "select * from planes p where p.idDirector = @cod";
            SqlCommand cmd = new SqlCommand(consultaCasting, conex);
            cmd.Parameters.AddWithValue("@cod", codD);

            // Crear un adaptador de datos y un DataSet para llenar los datos en el DataGridView
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataSet datos = new DataSet();
            adaptador.Fill(datos);

            // Asignar el DataSet al DataGridView
            dtgPlanes.DataSource = datos.Tables[0];

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

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (!camposNoNulosPlanes())
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            //recoger datos
            int idDirector = obtenerCodDirector();
            DateTime fecha = dtpDia.Value;
            
            string actividad = "";
            if (rdbCasting.Checked)
            {
                actividad = "casting";
            }else if(rdbGrabar.Checked)
            {
                actividad = "grabacion";
            }
            else if(rdbEditar.Checked)
            {
                actividad = "edicion";
            }
            else if (rdbPubli.Checked)
            {
                actividad = "publicidad";
            }
            else if (rdbPresentacion.Checked)
            {
                actividad = "presentacion";
            }
            else if (rdbDecorado.Checked)
            {
                actividad = "decorados";
            }

            string horarios = txtHora.Text.Trim();
            string llamadas = txtLlamadas.Text.Trim();
            string problemas = txtProblemas.Text.Trim();
            
            string estado = "";
            if (chbEnProceso.Checked)
            {
                estado = "Progreso";
            }
            else if (chbSinEmpezar.Checked)
            {
                estado = "SinEmpezar";
            }

            string query = "INSERT INTO planes (idDirector, fecha, actividad, horarios, llamadas, problemas, estado) " +
                          "VALUES (@idDirector, @fecha, @actividad, @horarios, @llamadas, @problemas, @estado)";

            using (SqlCommand cmd = new SqlCommand(query, conex))
            {
                // Añadir parámetros
                cmd.Parameters.AddWithValue("@idDirector", idDirector);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@actividad", actividad);
                cmd.Parameters.AddWithValue("@horarios", horarios);
                cmd.Parameters.AddWithValue("@llamadas", llamadas);
                cmd.Parameters.AddWithValue("@problemas", problemas);
                cmd.Parameters.AddWithValue("@estado", estado);

                // Ejecutar el comando
                int afectadas = cmd.ExecuteNonQuery();

                // Mostrar un mensaje de éxito
                if (afectadas > 0)
                {
                    MessageBox.Show("Plan publicado con éxito.");
                    llenarTablaPlanes();
                }
                else
                {
                    MessageBox.Show("Hubo un problema al publicar el plan.");
                }
            }
        }

        private bool camposNoNulosPlanes()
        {
            // Verificar los campos no nulos
            if (dtpDia.Value == null || string.IsNullOrWhiteSpace(txtHora.Text) ||
                string.IsNullOrWhiteSpace(txtLlamadas.Text) || string.IsNullOrWhiteSpace(txtProblemas.Text))
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
    }
}
