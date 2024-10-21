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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CinPadd.NoComunes
{
    public partial class CastingSelec : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        int idUser;
        public CastingSelec(int IdUsuario)
        {
            InitializeComponent();
            this.idUser = IdUsuario;
            llenarTablaCasting();
        }

        private void llenarTablaCasting()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            //recoger el codigo del tipo de usuario
            string codTipo = "select u.codActor " +
                " from usuarios u " +
                " where u.cod = @cod";
            //ejecutar consulta
            SqlCommand cmd = new SqlCommand(codTipo, conex);
            cmd.Parameters.AddWithValue("@cod", idUser);

            //y obtengo el número de registros afectados
            SqlDataReader reader = cmd.ExecuteReader();
            int codActor = -1;

            if (reader.Read())
            {//almaceno el codigo
                codActor = Convert.ToInt32(reader["codActor"]);
            }
            reader.Close();

            // Consulta SQL para obtener los libros del usuario
            string consultaCasting = "select * from castingSeleccionado where codActor = @codActor";
            SqlCommand comando = new SqlCommand(consultaCasting, conex);
            comando.Parameters.AddWithValue("@codActor", codActor);

            // Crear un adaptador de datos y un DataSet para llenar los datos en el DataGridView
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Verifica que hay una fila seleccionada
            if(dtgCastings.SelectedRows.Count > 0)
            {
                //almacenar la fila
                int indiceSelecionado = dtgCastings.SelectedRows[0].Index;
                //eliminar
                dtgCastings.Rows.RemoveAt(indiceSelecionado);
                //actualizar
                dtgCastings.Refresh();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }
        }

        private void btnDirector_Click(object sender, EventArgs e)
        {
            // Verifica que hay una fila seleccionada
            if (dtgCastings.SelectedRows.Count > 0)
            {
                //almacenar la fila
                DataGridViewRow indiceSelecionado = dtgCastings.SelectedRows[0];

                //almacenar el director del campo
                string director = indiceSelecionado.Cells["director"].Value.ToString();

                //abro la conexión
                conex = new SqlConnection(cadena);
                conex.Open();

                //realixo la consulta para obtener los datos del director
                string datosDirector = "select u.nombre, u.apellido1 " +
                    " from usuarios u " +
                    " where u.codDirector = @cod";

                using (SqlCommand cmd = new SqlCommand(datosDirector, conex))
                {
                    cmd.Parameters.AddWithValue("@cod", director);
                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.Read())
                    {
                        txtDirector.Text = lector["nombre"].ToString() + " " + lector["apellido1"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No hay datos disponibles");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para mostrar.");
            }
            conex.Close();
        }
    }
}
