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
    public partial class Perfil : Form
    {
        int idUser;
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        public Perfil(int IdUsuario)
        {
            InitializeComponent();
            this.idUser = IdUsuario;
            rellenarCampos();

            //esconder los groupbox
            gpbActores.Visible = false;
            gpbApariencia.Visible = false;
            gpbAficionados.Visible = false;
            gpbDirectores.Visible = false;
            gpbGuionistas.Visible = false;

            //método para controlar que groupbox se verá
            cargaDatosDeTipo();

        }

        private void cargaDatosDeTipo()
        {
            conex = new SqlConnection(cadena);
            conex.Open();

            //hay que hacer una consulta para obtener el tipo de usuario
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
                // Determinar el tipo de usuario y abrir el groupbox correspondiente
                switch (usuarioTipo)
                {
                    case "Actor":
                        gpbActores.Visible = true;
                        gpbApariencia.Visible = true;
                        llenarActor();
                        llenarApariencia();
                        break;
                    case "Director":
                        gpbDirectores.Visible = true;
                        llenarDirector();
                        break;
                    case "Guionista":
                        gpbGuionistas.Visible = true;
                        llenarGuionista();
                        break;
                    case "Aficionado":
                        gpbAficionados.Visible = true;
                        llenarAficionado();
                        break;
                    default:
                        MessageBox.Show("Tipo de usuario no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                
            }
            else
            {
                MessageBox.Show("Hubo un problema en la carga de los datos del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            //cerrar la conexión
            conex.Close();
        }

        private void llenarAficionado()
        {
            try
            {
                conex = new SqlConnection(cadena);
                //abrimos la conexión
                conex.Open();

                //recoger el codigo del tipo de usuario
                string codTipo = "select u.codAficionado " +
                    " from usuarios u " +
                    " where u.cod = @cod";
                //ejecutar consulta
                SqlCommand cmd = new SqlCommand(codTipo, conex);
                cmd.Parameters.AddWithValue("@cod", idUser);

                //y obtengo el número de registros afectados
                int codAficionado = -1;
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        codAficionado = reader.IsDBNull(reader.GetOrdinal("codAficionado"))
                            ? -1
                            : reader.GetInt32(reader.GetOrdinal("codAficionado"));
                    }
                }

                if(codAficionado != -1)
                {
                    string recogerDatos = " select a.directorFav, a.generoFav, a.temasInteres " +
                        " from aficionado a " +
                        " where a.codAficionado = @cod ";

                    SqlCommand comando = new SqlCommand(recogerDatos, conex);
                    comando.Parameters.AddWithValue("@cod", codAficionado);

                    //si el lector lee, escribir en la pantalla
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            //controlar nulos
                            txtGeneroAficion.Text = lector.IsDBNull(lector.GetOrdinal("generoFav"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("generoFav"));

                            txtDirectorFav.Text = lector.IsDBNull(lector.GetOrdinal("directorFav"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("directorFav"));

                            //almaceno el típo de interes en una variable
                            string interes = lector.IsDBNull(lector.GetOrdinal("temasInteres"))
                                ? string.Empty
                                : lector.GetString(lector.GetOrdinal("temasInteres"));

                            //determino que checkbox debo marcar
                            chbPelis.Checked = interes.Equals("Películas");
                            chbActores.Checked = interes.Equals("Actores");
                            chbEstrenos.Checked = interes.Equals("Estrenos");
                            chbGuiones.Checked = interes.Equals("Guiones");
                        }
                    }
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del aficionado: " + ex.Message);
            }
            conex.Close();
        }

        private void llenarGuionista()
        {
            try
            {
            conex = new SqlConnection(cadena);
            conex.Open();

            //recoger el codigo del tipo de usuario
            string codTipo = "select u.codGuionista " +
                " from usuarios u " +
                " where u.cod = @cod ";
            //ejecutar consulta
            SqlCommand cmd = new SqlCommand(codTipo, conex);
            cmd.Parameters.AddWithValue("@cod", idUser);

            //y obtengo el número de registros afectados
            int codGuionista = -1;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    codGuionista = reader.IsDBNull(reader.GetOrdinal("codGuionista"))
                        ? -1
                        : reader.GetInt32(reader.GetOrdinal("codGuionista"));
                }
            }

            if (codGuionista != -1)
            {
                string recogerDatos = "select g.tipoEscritor, g.generoPreferido, g.instagram, g.telefono, g.experiencia, g.idiomaNacimiento, g.numIdiomas " +
                    " from guionista g " +
                    " where g.codGuionista = @cod";

                SqlCommand comando = new SqlCommand(recogerDatos, conex);
                comando.Parameters.AddWithValue("@cod", codGuionista);

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    //si el lector lee, escribir en la pantalla
                    if (lector.Read())
                    {
                        //controlar nulos
                        txtGeneroFav.Text = lector.IsDBNull(lector.GetOrdinal("generoPreferido"))
                            ? " "
                            : lector.GetString(lector.GetOrdinal("generoPreferido"));

                        txtRedesGuionista.Text = lector.IsDBNull(lector.GetOrdinal("instagram"))
                            ? " "
                            : lector.GetString(lector.GetOrdinal("instagram"));

                        txtDatosGuionista.Text = lector.IsDBNull(lector.GetOrdinal("telefono"))
                            ? " "
                            : lector.GetString(lector.GetOrdinal("telefono"));

                        //determino la experiencia
                        // Verificar si la experiencia es verdadera o falsa y ajustar los checkboxes correspondientes
                        if (!lector.IsDBNull(lector.GetOrdinal("experiencia")))
                        {
                            bool experiencia = lector.GetBoolean(lector.GetOrdinal("experiencia"));
                            chbGuionistaConExperiencia.Checked = experiencia;
                            chbGuionistaSinExperiencia.Checked = !experiencia;
                        }
                        else
                        {
                            // Si el valor es nulo, desmarcar ambos checkboxes
                            chbGuionistaConExperiencia.Checked = false;
                            chbGuionistaSinExperiencia.Checked = false;
                        }

                        txtIdiomasGuionista.Text = lector.IsDBNull(lector.GetOrdinal("idiomaNacimiento"))
                            ? " "
                            : lector.GetString(lector.GetOrdinal("idiomaNacimiento"));

                        //determino el número de idiomas
                        // Ajustar el control NumericUpDown para el número de idiomas
                        if (!lector.IsDBNull(lector.GetOrdinal("numIdiomas")))
                        {
                            numIdiomasGuionista.Value = lector.GetInt32(lector.GetOrdinal("numIdiomas"));
                        }
                        else
                        {
                            numIdiomasGuionista.Value = 0; // o algún valor predeterminado
                        }

                        //almaceno el tipo de escritor en una variable
                        string tipoEscritor = lector.IsDBNull(lector.GetOrdinal("tipoEscritor"))
                            ? string.Empty
                            : lector.GetString(lector.GetOrdinal("tipoEscritor"));

                        //determino que checkbox debo marcar
                        if (tipoEscritor.Equals("Esquemático"))
                        {
                            chbEsquematico.Checked = true;
                        }
                        else if (tipoEscritor.Equals("Lineal"))
                        {
                            chbLineal.Checked = true;
                        }
                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del guionista: " + ex.Message);
            }
            conex.Close();
        }

        private void llenarDirector()
        {
            try
            {
                conex = new SqlConnection(cadena);
                //abrimos la conexión
                conex.Open();

                string codTipo = "select u.codDirector " +
                    " from usuarios u " +
                    " where u.cod = @cod";
                SqlCommand cmd = new SqlCommand(codTipo, conex);
                cmd.Parameters.AddWithValue("@cod", idUser);

                int codDirector = -1;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        codDirector = reader.IsDBNull(reader.GetOrdinal("codDirector"))
                            ? -1
                            : reader.GetInt32(reader.GetOrdinal("codDirector"));
                    }
                }

                if (codDirector != -1)
                {
                    string recogerDatos = "select d.instagram, d.enlacePortfolio, d.telefono, d.equipoFijo, d.experiencia, d.idiomaNacimiento, d.numIdiomas, d.portfolio " +
                        " from director d " +
                        " where d.codDirector = @cod";

                    SqlCommand comando = new SqlCommand(recogerDatos, conex);
                    comando.Parameters.AddWithValue("@cod", codDirector);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            txtRedes.Text = lector.IsDBNull(lector.GetOrdinal("instagram"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("instagram"));

                            txtEnlaces.Text = lector.IsDBNull(lector.GetOrdinal("enlacePortfolio"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("enlacePortfolio"));

                            txtContacto.Text = lector.IsDBNull(lector.GetOrdinal("telefono"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("telefono"));

                            // Verificar equipoFijo y ajustar los checkboxes correspondientes
                            if (!lector.IsDBNull(lector.GetOrdinal("equipoFijo")))
                            {
                                bool equipoFijo = lector.GetBoolean(lector.GetOrdinal("equipoFijo"));
                                chbConEquipo.Checked = equipoFijo;
                                chbSinEquipo.Checked = !equipoFijo;
                            }
                            else
                            {
                                chbConEquipo.Checked = false;
                                chbSinEquipo.Checked = false;
                            }

                            // Verificar experiencia y ajustar los checkboxes correspondientes
                            if (!lector.IsDBNull(lector.GetOrdinal("experiencia")))
                            {
                                bool experiencia = lector.GetBoolean(lector.GetOrdinal("experiencia"));
                                chbDirectorConExperiencia.Checked = experiencia;
                                chbDirectorSinExperiencia.Checked = !experiencia;
                            }
                            else
                            {
                                chbDirectorConExperiencia.Checked = false;
                                chbDirectorSinExperiencia.Checked = false;
                            }

                            txtIdiomas.Text = lector.IsDBNull(lector.GetOrdinal("idiomaNacimiento"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("idiomaNacimiento"));

                            // Ajustar el control NumericUpDown para el número de idiomas
                            if (!lector.IsDBNull(lector.GetOrdinal("numIdiomas")))
                            {
                                numIdiomas.Value = lector.GetInt32(lector.GetOrdinal("numIdiomas"));
                            }
                            else
                            {
                                numIdiomas.Value = 0; // o algún valor predeterminado
                            }

                            // Verificar portfolio y ajustar los checkboxes correspondientes
                            if (!lector.IsDBNull(lector.GetOrdinal("portfolio")))
                            {
                                bool portfolio = lector.GetBoolean(lector.GetOrdinal("portfolio"));
                                chbConPortfolio.Checked = portfolio;
                                chbSinPortfolio.Checked = !portfolio;
                            }
                            else
                            {
                                chbConPortfolio.Checked = false;
                                chbSinPortfolio.Checked = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del director: " + ex.Message);
            }
            conex.Close();
        }

        private void llenarApariencia()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            try
            {
                string codTipo = "select u.codActor " +
               " from usuarios u " +
               " where u.cod = @cod";
                SqlCommand cmd = new SqlCommand(codTipo, conex);
                cmd.Parameters.AddWithValue("@cod", idUser);

                int codActor = -1;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        codActor = reader.IsDBNull(reader.GetOrdinal("codActor"))
                            ? -1
                            : reader.GetInt32(reader.GetOrdinal("codActor"));
                    }
                }

                if (codActor != -1)
                {
                    string recogerDatos = "select a.ojos, a.etnia, a.colorPelo, a.largoPelo, a.tipoPelo, a.tinte, a.tatoo, a.piercing, a.altura, a.medidas " +
                        " from apariencia a " +
                        " where a.codActor = @cod";

                    SqlCommand comando = new SqlCommand(recogerDatos, conex);
                    comando.Parameters.AddWithValue("@cod", codActor);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            txtOjos.Text = lector.IsDBNull(lector.GetOrdinal("ojos"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("ojos"));

                            txtEtnia.Text = lector.IsDBNull(lector.GetOrdinal("etnia"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("etnia"));

                            txtColorPelo.Text = lector.IsDBNull(lector.GetOrdinal("colorPelo"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("colorPelo"));

                            string largoPelo = lector.IsDBNull(lector.GetOrdinal("largoPelo"))
                                ? string.Empty
                                : lector.GetString(lector.GetOrdinal("largoPelo"));
                            chbLargo.Checked = largoPelo.Equals("Largo");
                            chbMedio.Checked = largoPelo.Equals("Medio");
                            chbCorto.Checked = largoPelo.Equals("Corto");

                            string tipoPelo = lector.IsDBNull(lector.GetOrdinal("tipoPelo"))
                                ? string.Empty
                                : lector.GetString(lector.GetOrdinal("tipoPelo"));
                            chbLiso.Checked = tipoPelo.Equals("Liso");
                            chbOndas.Checked = tipoPelo.Equals("Ondas");
                            chbRizo.Checked = tipoPelo.Equals("Rizo");
                            chbAfro.Checked = tipoPelo.Equals("Afro");

                            // Verificar tinte y ajustar los checkboxes correspondientes
                            if (!lector.IsDBNull(lector.GetOrdinal("tinte")))
                            {
                                bool tinte = lector.GetBoolean(lector.GetOrdinal("tinte"));
                                chbConTinte.Checked = tinte;
                                chbSinTinte.Checked = !tinte;
                            }
                            else
                            {
                                chbConTinte.Checked = false;
                                chbSinTinte.Checked = false;
                            }

                            // Verificar tatoo y ajustar los checkboxes correspondientes
                            if (!lector.IsDBNull(lector.GetOrdinal("tatoo")))
                            {
                                bool tatoo = lector.GetBoolean(lector.GetOrdinal("tatoo"));
                                chbConTatu.Checked = tatoo;
                                chbSinTatu.Checked = !tatoo;
                            }
                            else
                            {
                                chbConTatu.Checked = false;
                                chbSinTatu.Checked = false;
                            }

                            // Verificar piercing y ajustar los checkboxes correspondientes
                            if (!lector.IsDBNull(lector.GetOrdinal("piercing")))
                            {
                                bool piercing = lector.GetBoolean(lector.GetOrdinal("piercing"));
                                chbConPiercing.Checked = piercing;
                                chbSinPiercing.Checked = !piercing;
                            }
                            else
                            {
                                chbConPiercing.Checked = false;
                                chbSinPiercing.Checked = false;
                            }

                            txtAltura.Text = lector.IsDBNull(lector.GetOrdinal("altura"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("altura"));

                            txtMedidas.Text = lector.IsDBNull(lector.GetOrdinal("medidas"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("medidas"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la apariencia: " + ex.Message);
            }

            conex.Close();
        }

        private void llenarActor()
        {
            conex = new SqlConnection(cadena);
            //abrimos la conexión
            conex.Open();

            try
            {
                string codTipo = "select u.codActor " +
                " from usuarios u " +
                " where u.cod = @cod";
                SqlCommand cmd = new SqlCommand(codTipo, conex);
                cmd.Parameters.AddWithValue("@cod", idUser);

                int codActor = -1;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        codActor = reader.IsDBNull(reader.GetOrdinal("codActor"))
                            ? -1
                            : reader.GetInt32(reader.GetOrdinal("codActor"));
                    }
                }

                if (codActor != -1)
                {
                    string recogerDatos = "select a.representante, a.estudios, a.instagram, a.idiomaNacimiento, a.numIdiomas, a.telefono, a.habilidad1, a.habilidad2, a.experiencia, a.book, a.videoBook " +
                        " from actor a " +
                        " where a.codActor = @cod";

                    SqlCommand comando = new SqlCommand(recogerDatos, conex);
                    comando.Parameters.AddWithValue("@cod", codActor);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            // Instagram
                            txtRedesActor.Text = lector.IsDBNull(lector.GetOrdinal("instagram"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("instagram"));

                            // Idioma de Nacimiento
                            txtIdiomasActor.Text = lector.IsDBNull(lector.GetOrdinal("idiomaNacimiento"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("idiomaNacimiento"));

                            // Número de Idiomas
                            numIdiomasActor.Value = lector.IsDBNull(lector.GetOrdinal("numIdiomas"))
                            ? 0
                            : lector.GetInt32(lector.GetOrdinal("numIdiomas"));

                            // Teléfono
                            txtContactoActor.Text = lector.IsDBNull(lector.GetOrdinal("telefono"))
                                ? " "
                                : lector.GetString(lector.GetOrdinal("telefono"));

                            // Habilidades
                            string habilidad1 = lector.IsDBNull(lector.GetOrdinal("habilidad1"))
                                ? string.Empty
                                : lector.GetString(lector.GetOrdinal("habilidad1"));
                            string habilidad2 = lector.IsDBNull(lector.GetOrdinal("habilidad2"))
                                ? string.Empty
                                : lector.GetString(lector.GetOrdinal("habilidad2"));

                            for (int i = 0; i < chbHabilidades.Items.Count; i++)
                            {
                                string item = chbHabilidades.Items[i].ToString();
                                chbHabilidades.SetItemChecked(i, item == habilidad1 || item == habilidad2);
                            }

                            bool representante = lector.GetBoolean(lector.GetOrdinal("representante"));
                            chbConRepre.Checked = representante;
                            chbSinRepre.Checked = !representante;

                            bool estudios = lector.GetBoolean(lector.GetOrdinal("estudios"));
                            chbConEstudios.Checked = estudios;
                            chbSinEstudios.Checked = !estudios;

                            bool experiencia = lector.GetBoolean(lector.GetOrdinal("experiencia"));
                            chbActorConExperiencia.Checked = experiencia;
                            chbActorSinExperiencia.Checked = !experiencia;

                            bool book = lector.GetBoolean(lector.GetOrdinal("book"));
                            chbConBook.Checked = book;
                            chbSinBook.Checked = !book;

                            bool videoBook = lector.GetBoolean(lector.GetOrdinal("videoBook"));
                            chbConVideo.Checked = videoBook;
                            chbSinVideo.Checked = !videoBook;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del actor: " + ex.Message);
            }

            conex.Close();
        }

        private void rellenarCampos()
        {
            try
            {
                conex = new SqlConnection(cadena);
                //abrimos la conexión
                conex.Open();

                string recogerDatos = "select u.nombreUser, u.contraseña, u.correo, u.nombre, u.apellido1, u.apellido2, u.nacionalidad, u.tipo, u.nacimiento " +
                    " from usuarios u " +
                    " where u.cod = @cod ";

                SqlCommand cmd = new SqlCommand(recogerDatos, conex);
                cmd.Parameters.AddWithValue("@cod", idUser);

                SqlDataReader lector = cmd.ExecuteReader();
                //si el lector lee, escribir en la pantalla
                if (lector.Read())
                {
                    txtUser.Text = lector["nombreUser"].ToString();
                    txtContraseña.Text = lector["contraseña"].ToString();
                    txtCorreo.Text = lector["correo"].ToString();
                    txtNom.Text = lector["nombre"].ToString();
                    txtApe1.Text = lector["apellido1"].ToString();
                    txtApe2.Text = lector["apellido2"].ToString();
                    txtNacionalidad.Text = lector["nacionalidad"].ToString();
                    lblTipo.Text = lector["tipo"].ToString();
                    dtpNacimiento.Value = (DateTime)lector["nacimiento"];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message);
            }
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

        private void btnCambioTotal_Click(object sender, EventArgs e)
        {
            try
            {
                // Actualizar cambios en los datos generales del usuario
                cambiosEnUsuario();

                // Verificar el tipo de usuario y aplicar cambios según corresponda
                if (gpbActores.Visible)
                {
                    cambiosEnActor();
                    cambiosEnApariencia();
                }
                else if (gpbAficionados.Visible)
                {
                    cambiosEsAficionado();
                }
                else if (gpbDirectores.Visible)
                {
                    cambiosEnDirector();
                }
                else if (gpbGuionistas.Visible)
                {
                    cambiosEnGuionista();
                }

                MessageBox.Show("Los cambios se han guardado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message);
            }
        }

        private void cambiosEnGuionista()
        {
            if (!camposNoNulosGuionista())
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conex = new SqlConnection(cadena);
            conex.Open();

            // Recoger los datos de la interfaz
            string generoPreferido = txtGeneroFav.Text.Trim();
            string instagram = txtRedesGuionista.Text.Trim();
            string telefono = txtDatosGuionista.Text.Trim();
            bool experiencia = chbGuionistaConExperiencia.Checked;
            string idiomaNacimiento = txtIdiomasGuionista.Text.Trim();
            int numIdiomas = (int)numIdiomasGuionista.Value;

            //recojo el codigo del guionista
            int codG = obtenerCodGuionista();

            string tipoEscritor = "";
            if (chbEsquematico.Checked)
            {
                tipoEscritor = "Esquemático";
            }
            else if (chbLineal.Checked)
            {
                tipoEscritor = "Lineal";
            }

            string cambioGuionista = "UPDATE guionista " +
                "SET tipoEscritor = @tipo, " +
                "generoPreferido = @generoPreferido, instagram = @instagram, " +
                "telefono = @telefono, experiencia = @experiencia, idiomaNacimiento = @idiomaNacimiento, numIdiomas = @numIdiomas " +
                "WHERE codGuionista = @codGuionista";

            SqlCommand cmd = new SqlCommand(cambioGuionista, conex);
            cmd.Parameters.AddWithValue("@codGuionista", codG);
            cmd.Parameters.AddWithValue("@generoPreferido", generoPreferido);
            cmd.Parameters.AddWithValue("@instagram", instagram);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@experiencia", experiencia);
            cmd.Parameters.AddWithValue("@idiomaNacimiento", idiomaNacimiento);
            cmd.Parameters.AddWithValue("@numIdiomas", numIdiomas);
            cmd.Parameters.AddWithValue("@tipo", tipoEscritor);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Los cambios del guionista se han guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se realizaron cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conex.Close();
        }

        private bool camposNoNulosGuionista()
        {
            // Verificar los campos no nulos
            return !string.IsNullOrWhiteSpace(txtGeneroFav.Text) &&
                   !string.IsNullOrWhiteSpace(txtRedesGuionista.Text) &&
                   !string.IsNullOrWhiteSpace(txtDatosGuionista.Text) &&
                   !string.IsNullOrWhiteSpace(txtIdiomasGuionista.Text) &&
                   numIdiomasGuionista.Value > 0;
        }

        private int obtenerCodGuionista()
        {
            conex = new SqlConnection(cadena);
            conex.Open();
            string query = "select u.codGuionista from usuarios u where u.cod = @cod";
            using (SqlCommand cmd = new SqlCommand(query, conex))
            {
                cmd.Parameters.AddWithValue("@cod", idUser);
                object result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : 0;
            }
        }

        private void cambiosEnDirector()
        {
            if (!camposNoNulosDirector())
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            conex = new SqlConnection(cadena);
            conex.Open();

            // Recoger los datos de la interfaz
            string instagram = txtRedes.Text.Trim();
            string enlacePortfolio = txtEnlaces.Text.Trim();
            string telefono = txtContacto.Text.Trim();
            string idiomaNacimiento = txtIdiomas.Text.Trim();
            int idiomas = (int)numIdiomas.Value;

            bool portfolio = false;
            if(chbConPortfolio.Checked)
            {
                portfolio = true;
            }

            bool equipoFijo = false;
            if(chbConEquipo.Checked)
            {
                equipoFijo = true;
            }

            bool experiencia = false;
            if(chbDirectorConExperiencia.Checked)
            {
                experiencia = true;
            }

            // Obtener el código del director
            int codDirector = obtenerCodDirector();

            // Construir y ejecutar la consulta SQL
            string cambioDirector = "UPDATE director " +
                "SET instagram = @instagram, enlacePortfolio = @enlacePortfolio, telefono = @telefono, " +
                "equipoFijo = @equipoFijo, experiencia = @experiencia, idiomaNacimiento = @idiomaNacimiento, " +
                "numIdiomas = @numIdiomas, portfolio = @portfolio " +
                "WHERE codDirector = @codDirector";

            SqlCommand cmd = new SqlCommand(cambioDirector, conex);
            cmd.Parameters.AddWithValue("@codDirector", codDirector);
            cmd.Parameters.AddWithValue("@instagram", instagram);
            cmd.Parameters.AddWithValue("@enlacePortfolio", enlacePortfolio);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@equipoFijo", equipoFijo);
            cmd.Parameters.AddWithValue("@experiencia", experiencia);
            cmd.Parameters.AddWithValue("@idiomaNacimiento", idiomaNacimiento);
            cmd.Parameters.AddWithValue("@numIdiomas", idiomas);
            cmd.Parameters.AddWithValue("@portfolio", portfolio);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Los cambios del director se han guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se realizaron cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            conex.Close();
        }

        private bool camposNoNulosDirector()
        {
            // Verificar los campos no nulos
            return !string.IsNullOrWhiteSpace(txtRedes.Text) &&
                   !string.IsNullOrWhiteSpace(txtContacto.Text) &&
                   !string.IsNullOrWhiteSpace(txtIdiomas.Text) &&
                   !string.IsNullOrWhiteSpace(txtEnlaces.Text) &&
                   numIdiomas.Value > 0; 
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

        private void cambiosEnApariencia()
        {
            if (!camposNoNulosApariencia())
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conex = new SqlConnection(cadena);
            conex.Open();

            try
            {
                // Recoger los datos de la interfaz
                string ojos = txtOjos.Text.Trim();
                string etnia = txtEtnia.Text.Trim();
                string colorPelo = txtColorPelo.Text.Trim();

                string largoPelo = " ";
                if (chbCorto.Checked)
                {
                    largoPelo = "Corto";
                }
                else if (chbMedio.Checked)
                {
                    largoPelo = "Medio";
                }
                else if (chbLargo.Checked)
                {
                    largoPelo = "Largo";
                }

                string tipoPelo = " ";
                if (chbLiso.Checked)
                {
                    tipoPelo = "Liso";
                }
                else if (chbOndas.Checked)
                {
                    tipoPelo = "Ondas";
                }
                else if (chbRizo.Checked)
                {
                    tipoPelo = "Rizo";
                }
                else if (chbAfro.Checked)
                {
                    tipoPelo = "Afro";
                }

                bool tinte = false;
                if (chbConTinte.Checked)
                {
                    tinte = true;
                }

                bool tatoo = false;
                if (chbConTatu.Checked)
                {
                    tatoo = true;
                }

                bool piercing = false;
                if (chbConPiercing.Checked)
                {
                    piercing = true;
                }

                string altura = txtAltura.Text.Trim();
                string medidas = txtMedidas.Text.Trim();

                // Obtener el código del actor
                int codActor = obtenerCodActor();

                // Construir y ejecutar la consulta SQL
                string cambioApariencia = "UPDATE apariencia " +
                    "SET ojos = @ojos, etnia = @etnia, colorPelo = @colorPelo, largoPelo = @largoPelo, " +
                    "tipoPelo = @tipoPelo, tinte = @tinte, tatoo = @tatoo, piercing = @piercing, altura = @altura, " +
                    "medidas = @medidas " +
                    "WHERE codActor = @codActor";

                SqlCommand cmd = new SqlCommand(cambioApariencia, conex);
                cmd.Parameters.AddWithValue("@codActor", codActor);
                cmd.Parameters.AddWithValue("@ojos", ojos);
                cmd.Parameters.AddWithValue("@etnia", etnia);
                cmd.Parameters.AddWithValue("@colorPelo", colorPelo);
                cmd.Parameters.AddWithValue("@largoPelo", largoPelo);
                cmd.Parameters.AddWithValue("@tipoPelo", tipoPelo);
                cmd.Parameters.AddWithValue("@tinte", tinte);
                cmd.Parameters.AddWithValue("@tatoo", tatoo);
                cmd.Parameters.AddWithValue("@piercing", piercing);
                cmd.Parameters.AddWithValue("@altura", altura);
                cmd.Parameters.AddWithValue("@medidas", medidas);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Los cambios de la apariencia se han guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos de la apariencia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conex.Close();
        }

        private bool camposNoNulosApariencia()
        {
            // Verificar los campos no nulos
            return !string.IsNullOrWhiteSpace(txtOjos.Text) &&
                   !string.IsNullOrWhiteSpace(txtEtnia.Text) &&
                   !string.IsNullOrWhiteSpace(txtColorPelo.Text) &&
                   (chbCorto.Checked || chbMedio.Checked || chbLargo.Checked) &&
                   (chbLiso.Checked || chbOndas.Checked || chbRizo.Checked || chbAfro.Checked) &&
                   !string.IsNullOrWhiteSpace(txtAltura.Text) &&
                   !string.IsNullOrWhiteSpace(txtMedidas.Text);
        }

        private void cambiosEsAficionado()
        {
            if (!camposNoNulosAficionado())
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conex = new SqlConnection(cadena);
            conex.Open();

            try
            {
                // Recoger los datos de la interfaz
                string generoFav = txtGeneroAficion.Text.Trim();
                string directorFav = txtDirectorFav.Text.Trim();
                string interes = " ";
                if (chbPelis.Checked)
                {
                    interes = "Películas";
                }
                else if (chbEstrenos.Checked)
                {
                    interes = "Estrenos";
                }
                else if(chbActores.Checked)
                {
                    interes = "Actores";
                }
                else if (chbGuiones.Checked)
                {
                    interes = "Guiones";
                }

                // Obtener el código del aficionado
                int codAficionado = obtenerCodAficionado();

                // Construir y ejecutar la consulta SQL
                string cambioAficionado = "UPDATE aficionado " +
                    "SET generoFav = @generoFav, directorFav = @directorFav, " +
                    "temasInteres = @interes " +
                    "WHERE codAficionado = @codAficionado";

                SqlCommand cmd = new SqlCommand(cambioAficionado, conex);
                cmd.Parameters.AddWithValue("@codAficionado", codAficionado);
                cmd.Parameters.AddWithValue("@generoFav", generoFav);
                cmd.Parameters.AddWithValue("@directorFav", directorFav);
                cmd.Parameters.AddWithValue("@interes", interes);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Los cambios del aficionado se han guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del aficionado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conex.Close();
        }

        private bool camposNoNulosAficionado()
        {
            // Verificar los campos no nulos
            return !string.IsNullOrWhiteSpace(txtGeneroAficion.Text) &&
                   !string.IsNullOrWhiteSpace(txtDirectorFav.Text) &&
                   (chbPelis.Checked || chbEstrenos.Checked || chbActores.Checked || chbGuiones.Checked);
        }

        private int obtenerCodAficionado()
        {
            conex = new SqlConnection(cadena);
            conex.Open();
            string query = "select u.codAficionado from usuarios u where u.cod = @cod";
            using (SqlCommand cmd = new SqlCommand(query, conex))
            {
                cmd.Parameters.AddWithValue("@cod", idUser);
                object result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : 0;
            }
        }

        private void cambiosEnActor()
        {
            if (!camposNoNulosActor())
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conex = new SqlConnection(cadena);
                conex.Open();

                // Recoger los datos de la interfaz
                string instagram = txtRedesActor.Text.Trim();
                string idiomaNacimiento = txtIdiomasActor.Text.Trim();
                int numIdiomas = (int)numIdiomasActor.Value;

                //Habilidadees
                string cadenaHabilidades = obtenerHabilidadSeleccionada(chbHabilidades);
                // Separar la cadena de habilidades en dos variables
                string[] habilidadesSeparadas = cadenaHabilidades.Split(';');
                string habilidad1 = habilidadesSeparadas.Length > 0 ? habilidadesSeparadas[0].Trim() : "";
                string habilidad2 = habilidadesSeparadas.Length > 1 ? habilidadesSeparadas[1].Trim() : "";

                bool representante = false;
                if (chbConRepre.Checked)
                {
                    representante = true;
                }

                bool estudios = false;
                if(chbConEstudios.Checked)
                {
                    estudios = true;
                }

                bool experiencia = false;
                if (chbActorConExperiencia.Checked)
                {
                    experiencia = true;
                }

                bool book = false;
                if (chbConBook.Checked)
                {
                    book = true;
                }

                bool videoBook = chbConVideo.Checked;
                if (chbConVideo.Checked)
                {
                    videoBook = true;
                }

                // Obtener el código del actor
                int codActor = obtenerCodActor();

                // Construir y ejecutar la consulta SQL
                string cambioActor = "UPDATE actor " +
                    "SET instagram = @instagram, idiomaNacimiento = @idiomaNacimiento, numIdiomas = @numIdiomas, " +
                    "habilidad1 = @habilidad1, habilidad2 = @habilidad2, representante = @representante, " +
                    "estudios = @estudios, experiencia = @experiencia, book = @book, videoBook = @videoBook " +
                    "WHERE codActor = @codActor";

                SqlCommand cmd = new SqlCommand(cambioActor, conex);
                cmd.Parameters.AddWithValue("@codActor", codActor);
                cmd.Parameters.AddWithValue("@instagram", instagram);
                cmd.Parameters.AddWithValue("@idiomaNacimiento", idiomaNacimiento);
                cmd.Parameters.AddWithValue("@numIdiomas", numIdiomas);
                cmd.Parameters.AddWithValue("@habilidad1", habilidad1);
                cmd.Parameters.AddWithValue("@habilidad2", habilidad2);
                cmd.Parameters.AddWithValue("@representante", representante);
                cmd.Parameters.AddWithValue("@estudios", estudios);
                cmd.Parameters.AddWithValue("@experiencia", experiencia);
                cmd.Parameters.AddWithValue("@book", book);
                cmd.Parameters.AddWithValue("@videoBook", videoBook);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Los cambios del actor se han guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conex.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del actor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool camposNoNulosActor()
        {
            // Verificar los campos no nulos
            return !string.IsNullOrWhiteSpace(txtIdiomasActor.Text) &&
                   !string.IsNullOrWhiteSpace(txtIdiomasActor.Text) &&
                   !string.IsNullOrWhiteSpace(txtContacto.Text) &&
                   (chbConRepre.Checked || chbSinRepre.Checked) &&
                   (chbConEstudios.Checked || chbSinEstudios.Checked) &&
                   (chbActorConExperiencia.Checked || chbActorSinExperiencia.Checked) &&
                   (chbConBook.Checked || chbSinBook.Checked) &&
                   (chbConVideo.Checked || chbSinVideo.Checked);
        }

        private string obtenerHabilidadSeleccionada(CheckedListBox chbHabilidades)
        {
            string habilidadesSeleccionadas = "";

            foreach (var item in chbHabilidades.CheckedItems)
            {
                habilidadesSeleccionadas += item.ToString() + ";";
            }

            // Eliminar el último punto y coma si hay habilidades seleccionadas
            if (!string.IsNullOrEmpty(habilidadesSeleccionadas))
            {
                habilidadesSeleccionadas = habilidadesSeleccionadas.Remove(habilidadesSeleccionadas.Length - 1);
            }

            return habilidadesSeleccionadas;
        }

        private int obtenerCodActor()
        {
            conex = new SqlConnection(cadena);
            conex.Open();
            string query = "select u.codActor from usuarios u where u.cod = @cod";
            using (SqlCommand cmd = new SqlCommand(query, conex))
            {
                cmd.Parameters.AddWithValue("@cod", idUser);
                object result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : 0;
            }
        }

        private void cambiosEnUsuario()
        {
            if (!camposValidosUsuario())
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //recoger los datos
            string nomUser = txtUser.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string nombre = txtNom.Text.Trim();
            string ape1 = txtApe1.Text.Trim();
            string ape2 = txtApe2.Text.Trim();
            DateTime fecha = dtpNacimiento.Value;
            string nacionalidad = txtNacionalidad.Text.Trim();

            try
            {
                conex = new SqlConnection(cadena);
                //abrimos la conexión
                conex.Open();

                string cambioTotal = "update usuarios " +
                    " set nombreUser = @nombreUser, contraseña = @contraseña, correo = @correo, nombre = @nombre, apellido1 = @ape1, " +
                    " apellido2= @ape2, nacimiento=@nacimiento, nacionalidad =@nacionalidad " +
                    " where cod =@cod ";

                SqlCommand cmd = new SqlCommand(cambioTotal, conex);
                cmd.Parameters.AddWithValue("@cod", idUser);
                cmd.Parameters.AddWithValue("@nombreUser", nomUser);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@ape1", ape1);
                cmd.Parameters.AddWithValue("@ape2", ape2);
                cmd.Parameters.AddWithValue("@nacimiento", fecha);
                cmd.Parameters.AddWithValue("@nacionalidad", nacionalidad);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("El cambio se completó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message);
            }
            conex.Close();
        }

        private bool camposValidosUsuario()
        {
            return !string.IsNullOrWhiteSpace(txtUser.Text) &&
                   !string.IsNullOrWhiteSpace(txtContraseña.Text) &&
                   !string.IsNullOrWhiteSpace(txtCorreo.Text) &&
                   !string.IsNullOrWhiteSpace(txtNom.Text) &&
                   !string.IsNullOrWhiteSpace(txtApe1.Text) &&
                   !string.IsNullOrWhiteSpace(txtNacionalidad.Text);
        }
    }
}
