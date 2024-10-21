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
    public partial class Registro : Form
    {
        string cadena = "Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;";
        SqlConnection conex;
        public Registro()
        {
            InitializeComponent();
            conex = new SqlConnection(cadena);
            gpbDirectores.Visible = false;
            gpbActores.Visible = false;
            gpbGuionistas.Visible = false;
            gpbAficionados.Visible = false;
            gpbApariencia.Visible = false;
        }

        private void rdbDirector_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDirector.Checked)
            {
                gpbDirectores.Visible = true;
                gpbActores.Visible = false;
                gpbGuionistas.Visible = false;
                gpbAficionados.Visible = false;
                gpbApariencia.Visible = false;
            }
        }

        private void rdbActor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbActor.Checked)
            {
                gpbActores.Visible = true;
                gpbDirectores.Visible = false;
                gpbGuionistas.Visible = false;
                gpbAficionados.Visible = false;
                gpbApariencia.Visible = false;
            }
        }

        private void rdbGuionista_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGuionista.Checked)
            {
                gpbGuionistas.Visible = true;
                gpbActores.Visible = false;
                gpbAficionados.Visible = false;
                gpbDirectores.Visible = false;
                gpbApariencia.Visible = false;
            }
        }

        private void rdbAficionado_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAficionado.Checked)
            {
                gpbAficionados.Visible = true;
                gpbDirectores.Visible = false;
                gpbActores.Visible = false;
                gpbGuionistas.Visible = false;
                gpbApariencia.Visible = false;
            }
        }

        private void btnApariencia_Click(object sender, EventArgs e)
        {
            gpbApariencia.Visible = true;
            gpbActores.Visible = true;
            gpbAficionados.Visible = false;
            gpbDirectores.Visible = false;
            gpbGuionistas.Visible = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!camposValidos())
            {
                MessageBox.Show("Existe algún campo vacío, llenalo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            conex.Close();
            //abro la conexión
            conex.Open();

            //recojo los datos
            int codTipo = 0;
            string usuario = txtUser.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string nombre = txtNom.Text.Trim();
            string ape1 = txtApe1.Text.Trim();
            string ape2 = txtApe2.Text.Trim();
            string nacionalidad = txtNacionalidad.Text.Trim();

            //identifico el típo
            //relleno la tabla del tipo de usuario correspondiente
            //los subo a la tabla de usuarios
            string consulta = "";
            string tipo = "";
            if (rdbActor.Checked)
            {
                tipo = rdbActor.Text.Trim();
                llenaActor();
                llenaApariencia();
                codTipo = codActor();
                consulta = "INSERT INTO usuarios (nombreUser, contraseña, correo, nombre, apellido1, apellido2, nacimiento, nacionalidad, codActor, tipo) " +
                "VALUES (@Usuario, @Contraseña, @Correo, @Nombre, @Apellido1, @Apellido2,  @FechaNacimiento, @Nacionalidad, @codTipo, @Tipo)";
            }
            else if (rdbDirector.Checked)
            {
                tipo = rdbDirector.Text.Trim();
                llenaDirector();
                codTipo = codDirector();
                consulta = "INSERT INTO usuarios (nombreUser, contraseña, correo, nombre, apellido1, apellido2, nacimiento, nacionalidad, codDirector, tipo) " +
                "VALUES (@Usuario, @Contraseña, @Correo, @Nombre, @Apellido1, @Apellido2,  @FechaNacimiento, @Nacionalidad, @codTipo, @Tipo)";
            }
            else if (rdbAficionado.Checked)
            {
                tipo = rdbAficionado.Text.Trim();
                llenaAficionado();
                codTipo = codAficionado();
                consulta = "INSERT INTO usuarios (nombreUser, contraseña, correo, nombre, apellido1, apellido2, nacimiento, nacionalidad, codAficionado, tipo) " +
                "VALUES (@Usuario, @Contraseña, @Correo, @Nombre, @Apellido1, @Apellido2,  @FechaNacimiento, @Nacionalidad, @codTipo, @Tipo)";
            }
            else if (rdbGuionista.Checked)
            {
                tipo = rdbGuionista.Text.Trim();
                llenaGuionista();
                codTipo = codGuionista();
                consulta = "INSERT INTO usuarios (nombreUser, contraseña, correo, nombre, apellido1, apellido2, nacimiento, nacionalidad, codGuionista, tipo) " +
                "VALUES (@Usuario, @Contraseña, @Correo, @Nombre, @Apellido1, @Apellido2,  @FechaNacimiento, @Nacionalidad, @codTipo, @Tipo)";
            }

            DateTime fecha = dtpNacimiento.Value;

            
            //objeto comando
            SqlCommand comando = new SqlCommand(consulta, conex);

            // Asigno los parámetros
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Contraseña", contraseña);
            comando.Parameters.AddWithValue("@Correo", correo);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Apellido1", ape1);
            comando.Parameters.AddWithValue("@Apellido2", ape2);
            comando.Parameters.AddWithValue("@Nacionalidad", nacionalidad);
            comando.Parameters.AddWithValue("@codTipo", codTipo);
            comando.Parameters.AddWithValue("@Tipo", tipo);
            comando.Parameters.AddWithValue("@FechaNacimiento", fecha);

            // Ejecuto la consulta
            int filasAfectadas = comando.ExecuteNonQuery();

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Acceso acceso = new Acceso();
                acceso.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private int codActor()
        {
            conex.Close();
            //abro la conexión
            conex.Open();

            // Consulto el código del actor recién insertado
            string consultaCodigoActor = "SELECT MAX(codActor) FROM actor";
            SqlCommand comandoConsulta = new SqlCommand(consultaCodigoActor, conex);
            int codigoActor = (int)comandoConsulta.ExecuteScalar();

            return codigoActor;
        }

        private int codGuionista()
        {
            conex.Close();
            //abro la conexión
            conex.Open();

            // Consulto el código del guionista recién insertado
            string consultaCodigo = "SELECT MAX(codGuionista) FROM guionista";
            SqlCommand comandoConsulta = new SqlCommand(consultaCodigo, conex);
            int codigoGuionista = (int)comandoConsulta.ExecuteScalar();

            return codigoGuionista;
        }

        private int codAficionado()
        {
            conex.Close();
            // Abrir conexión
            conex.Open();

            // Consultar el código del aficionado recién insertado
            string consultaCodigoAficionado = "SELECT MAX(codAficionado) FROM aficionado";
            SqlCommand comandoConsulta = new SqlCommand(consultaCodigoAficionado, conex);
            int codigoAficionado = (int)comandoConsulta.ExecuteScalar();

            return codigoAficionado;
        }

        private int codDirector()
        {
            conex.Close();
            //abro la conexión
            conex.Open();

            // Consulto el código del actor recién insertado
            string consultaCodigo = "SELECT MAX(codDirector) FROM director";
            SqlCommand comandoConsulta = new SqlCommand(consultaCodigo, conex);
            int codigoDirector = (int)comandoConsulta.ExecuteScalar();

            return codigoDirector;
        }

        private void llenaApariencia()
        {
            conex.Close();
            //abro la conexión
            conex.Open();

            //recojo los datos
            int cod = codActor();
            string ojos = txtOjos.Text.Trim();
            string etnia = txtEtnia.Text.Trim();
            string colorPelo = txtColorPelo.Text.Trim();

            string largo = "";
            if (chbCorto.Checked)
            {
                largo = chbCorto.Text.Trim();
            }
            else if (chbMedio.Checked)
            {
                largo = chbMedio.Text.Trim();
            }
            else if (chbLargo.Checked)
            {
                largo = chbLargo.Text.Trim();
            }

            string tipo = "";
            if (chbLiso.Checked)
            {
                tipo = chbLiso.Text.Trim();
            }
            else if (chbOndas.Checked)
            {
                tipo = chbOndas.Text.Trim();
            }
            else if (chbRizo.Checked)
            {
                tipo = chbRizo.Text.Trim();
            }
            else if (chbAfro.Checked)
            {
                tipo = chbAfro.Text.Trim();
            }

            bool tinte = false;
            if (chbConTinte.Checked)
            {
                tinte = true;
            }
            else if (chbSinTinte.Checked)
            {
                tinte = false;
            }

            bool tatoo = false;
            if (chbConTatu.Checked)
            {
                tatoo = true;
            }
            else if (chbSinTatu.Checked)
            {
                tatoo = false;
            }

            bool piercing = false;
            if (chbConPiercing.Checked)
            {
                piercing = true;
            }
            else if (chbSinPiercing.Checked)
            {
                piercing = false;
            }

            string altura = txtAltura.Text.Trim();
            string medidas = txtMedidas.Text.Trim();

            string consulta = "INSERT INTO apariencia(codActor, ojos, etnia, colorPelo, largoPelo, tipoPelo, tinte, tatoo, piercing, altura, medidas)" +
                "VALUES(@codActor, @ojos, @etnia, @colorPelo, @largoPelo, @tipoPelo, @tinte, @tatoo, @piercing, @altura, @medidas)";

            //objeto comando
            SqlCommand comando = new SqlCommand(consulta, conex);

            // Asigno los parámetros
            comando.Parameters.AddWithValue("@codActor", cod);
            comando.Parameters.AddWithValue("@ojos", ojos);
            comando.Parameters.AddWithValue("@etnia", etnia);
            comando.Parameters.AddWithValue("@colorPelo", colorPelo);
            comando.Parameters.AddWithValue("@largoPelo", largo);
            comando.Parameters.AddWithValue("@tipoPelo", tipo);
            comando.Parameters.AddWithValue("@tinte", tinte);
            comando.Parameters.AddWithValue("@tatoo", tatoo);
            comando.Parameters.AddWithValue("@piercing", piercing);
            comando.Parameters.AddWithValue("@altura", altura);
            comando.Parameters.AddWithValue("@medidas", medidas);

            // Ejecuto la consulta
            int filasAfectadas = comando.ExecuteNonQuery();

            //borrar tras acabar las pruebas
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Apariencia registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al registrar la apariencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenaGuionista()
        {
            conex.Close();
            //abrir conexion
            conex.Open();

            //recoger datos
            string tipo = "";
            if (chbLineal.Checked)
            {
                tipo = chbLineal.Text.Trim();
            }
            else if (chbEsquematico.Checked)
            {
                tipo = chbEsquematico.Text.Trim();
            }

            string genero = txtGeneroFav.Text.Trim();
            string insta = txtRedesGuionista.Text.Trim();
            string telefono = txtDatosGuionista.Text.Trim();

            bool experiencia = false;
            if (chbGuionistaConExperiencia.Checked)
            {
                experiencia = true;
            }
            else if (chbGuionistaSinExperiencia.Checked)
            {
                experiencia = false;
            }

            string idioma = txtIdiomasGuionista.Text.Trim();
            int numIdioma = (int)numIdiomasGuionista.Value;

            //cadena de la consulta
            string consulta = "INSERT INTO guionista (tipoEscritor, generoPreferido, instagram, telefono, experiencia, idiomaNacimiento, numIdiomas)" +
                "VALUES (@tipoEscritor, @generoPreferido, @instagram, @telefono, @experiencia, @idiomaNacimiento, @numIdiomas)";

            //objeto comando
            SqlCommand comando = new SqlCommand(consulta, conex);

            //parámetros
            comando.Parameters.AddWithValue("@tipoEscritor", tipo);
            comando.Parameters.AddWithValue("@generoPreferido", genero);
            comando.Parameters.AddWithValue("@instagram", insta);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@experiencia", experiencia);
            comando.Parameters.AddWithValue("@idiomaNacimiento", idioma);
            comando.Parameters.AddWithValue("@numIdiomas", numIdioma);

            //ejecutar la consulta
            int filasAfectadas = comando.ExecuteNonQuery();

            //borrar tras las pruebas
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Guionista registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al registrar el guionista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenaAficionado()
        {
            conex.Close();
            // Abrir conexión
            conex.Open();

            // Recoger datos
            string generoFav = txtGeneroFav.Text.Trim();
            string directorFav = txtDirectorFav.Text.Trim();

            string temasInteres = "";
            if (chbPelis.Checked)
            {
                temasInteres = chbPelis.Text.Trim();
            }
            else if (chbActores.Checked)
            {
                temasInteres = chbActores.Text.Trim();
            }
            else if (chbEstrenos.Checked)
            {
                temasInteres = chbEstrenos.Text.Trim();
            }
            else if (chbGuiones.Checked)
            {
                temasInteres = chbGuiones.Text.Trim();
            }

            // Cadena de la consulta
            string consulta = "INSERT INTO aficionado (generoFav, directorFav, temasInteres) VALUES (@generoFav, @directorFav, @temasInteres)";

            // Objeto comando
            SqlCommand comando = new SqlCommand(consulta, conex);

            // Parámetros
            comando.Parameters.AddWithValue("@generoFav", generoFav);
            comando.Parameters.AddWithValue("@directorFav", directorFav);
            comando.Parameters.AddWithValue("@temasInteres", temasInteres);

            // Ejecutar la consulta
            int filasAfectadas = comando.ExecuteNonQuery();


            if (filasAfectadas > 0)
            {
                MessageBox.Show("Aficionado registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al registrar el aficionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenaDirector()
        {
            conex.Close();
            // Abrir conexión
            conex.Open();

            // Recoger datos
            string instagram = txtRedes.Text.Trim();
            string enlacePortfolio = txtEnlaces.Text.Trim();
            string telefono = txtContacto.Text.Trim();

            bool equipoFijo = false;
            if (chbConEquipo.Checked)
            {
                equipoFijo = true;
            }
            else if (chbSinEquipo.Checked)
            {
                equipoFijo = false;
            }

            bool experiencia = false;
            if (chbDirectorConExperiencia.Checked)
            {
                experiencia = true;
            }
            else if (chbDirectorSinExperiencia.Checked)
            {
                experiencia = false;
            }

            string idiomaNacimiento = txtIdiomas.Text.Trim();
            int numIdioma = (int)numIdiomas.Value;

            bool portfolio = false;
            if (chbConPortfolio.Checked)
            {
                portfolio = true;
            }
            else if (chbSinPortfolio.Checked)
            {
                portfolio = false;
            }

            // Cadena de la consulta
            string consulta = "INSERT INTO director (instagram, enlacePortfolio, telefono, equipoFijo, experiencia, idiomaNacimiento, numIdiomas, portfolio) " +
                              "VALUES (@instagram, @enlacePortfolio, @telefono, @equipoFijo, @experiencia, @idiomaNacimiento, @numIdiomas, @portfolio)";

            // Objeto comando
            SqlCommand comando = new SqlCommand(consulta, conex);

            // Parámetros
            comando.Parameters.AddWithValue("@instagram", instagram);
            comando.Parameters.AddWithValue("@enlacePortfolio", enlacePortfolio);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@equipoFijo", equipoFijo);
            comando.Parameters.AddWithValue("@experiencia", experiencia);
            comando.Parameters.AddWithValue("@idiomaNacimiento", idiomaNacimiento);
            comando.Parameters.AddWithValue("@numIdiomas", numIdioma);
            comando.Parameters.AddWithValue("@portfolio", portfolio);

            // Ejecutar la consulta
            int filasAfectadas = comando.ExecuteNonQuery();

            //borrar tras acabar las pruebas
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Director registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al registrar director.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenaActor()
        {
            //cierro la conexión por seguridad
            conex.Close();
            //abro la conexión
            conex.Open();

            bool repre = false;
            if (chbConRepre.Checked)
            {
                repre = true;
            }
            else if (chbSinRepre.Checked)
            {
                repre = false;
            }

            bool estudios = false;
            if (chbConEstudios.Checked)
            {
                estudios = true;
            }
            else if (chbSinEstudios.Checked)
            {
                estudios = false;
            }

            string instagram = txtRedesActor.Text.Trim();
            string idioma = txtIdiomasActor.Text.Trim();
            int numIdiomas = (int)numIdiomasActor.Value;
            string telefono = txtContactoActor.Text.Trim();
            string habilidad1 = "";
            string habilidad2 = "";

            if (checkedListBox1.CheckedItems.Count == 2)
            {
                habilidad1 = checkedListBox1.CheckedItems[0].ToString();
                habilidad2 = checkedListBox1.CheckedItems[1].ToString();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione exactamente dos elementos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bool experiencia = false;
            if (chbActorConExperiencia.Checked)
            {
                experiencia = true;
            }
            else if (chbActorSinExperiencia.Checked)
            {
                experiencia = false;
            }

            bool book = false;
            if (chbConBook.Checked)
            {
                book = true;
            }
            else if (chbSinBook.Checked)
            {
                book = false;
            }

            bool videoBook = false;
            if (chbConVideo.Checked)
            {
                videoBook = true;
            }
            else if (chbSinVideo.Checked)
            {
                videoBook = false;
            }

            string insertaActor = "INSERT INTO actor (representante, estudios, instagram, idiomaNacimiento, numIdiomas, telefono, habilidad1, habilidad2, experiencia, book, videoBook)" +
                "VALUES (@repre, @estudios, @insta, @idioma, @numIdiomas, @telefono, @habilidad1, @habilidad2, @experiencia, @book, @video)";

            //objeto comando
            SqlCommand comando = new SqlCommand(insertaActor, conex);

            // Asigno los parámetros
            comando.Parameters.AddWithValue("@repre", repre);
            comando.Parameters.AddWithValue("@estudios", estudios);
            comando.Parameters.AddWithValue("@insta", instagram);
            comando.Parameters.AddWithValue("@idioma", idioma);
            comando.Parameters.AddWithValue("@numIdiomas", numIdiomas);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@habilidad1", habilidad1);
            comando.Parameters.AddWithValue("@habilidad2", habilidad2);
            comando.Parameters.AddWithValue("@experiencia", experiencia);
            comando.Parameters.AddWithValue("@book", book);
            comando.Parameters.AddWithValue("@video", videoBook);

            // Ejecuto la consulta
            int filasAfectadas = comando.ExecuteNonQuery();

            //borrar tras acabar las pruebas
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Actor registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al registrar actor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool camposValidos()
        {
            // Verificar los campos obligatorios según el tipo de usuario seleccionado
            if (rdbDirector.Checked)
            {
                return !string.IsNullOrWhiteSpace(txtUser.Text) &&
                       !string.IsNullOrWhiteSpace(txtContraseña.Text) &&
                       !string.IsNullOrWhiteSpace(txtCorreo.Text) &&
                       !string.IsNullOrWhiteSpace(txtNom.Text) &&
                       !string.IsNullOrWhiteSpace(txtApe1.Text) &&
                       !string.IsNullOrWhiteSpace(txtNacionalidad.Text) &&
                       !string.IsNullOrWhiteSpace(txtContacto.Text) &&
                       !string.IsNullOrWhiteSpace(txtIdiomas.Text);
            }
            else if (rdbActor.Checked)
            {
                return !string.IsNullOrWhiteSpace(txtUser.Text) &&
                       !string.IsNullOrWhiteSpace(txtContraseña.Text) &&
                       !string.IsNullOrWhiteSpace(txtCorreo.Text) &&
                       !string.IsNullOrWhiteSpace(txtNom.Text) &&
                       !string.IsNullOrWhiteSpace(txtApe1.Text) &&
                       !string.IsNullOrWhiteSpace(txtNacionalidad.Text) &&
                       !string.IsNullOrWhiteSpace(txtIdiomasActor.Text) &&
                       !string.IsNullOrWhiteSpace(txtContactoActor.Text) &&
                       !string.IsNullOrWhiteSpace(txtRedesActor.Text);
            }
            else if (rdbGuionista.Checked)
            {
                return !string.IsNullOrWhiteSpace(txtUser.Text) &&
                       !string.IsNullOrWhiteSpace(txtContraseña.Text) &&
                       !string.IsNullOrWhiteSpace(txtCorreo.Text) &&
                       !string.IsNullOrWhiteSpace(txtNom.Text) &&
                       !string.IsNullOrWhiteSpace(txtApe1.Text) &&
                       !string.IsNullOrWhiteSpace(txtNacionalidad.Text) &&
                       !string.IsNullOrWhiteSpace(txtIdiomasGuionista.Text) &&
                       !string.IsNullOrWhiteSpace(txtDatosGuionista.Text) &&
                       !string.IsNullOrWhiteSpace(txtRedesGuionista.Text);
            }
            else if (rdbAficionado.Checked)
            {
                return !string.IsNullOrWhiteSpace(txtUser.Text) &&
                       !string.IsNullOrWhiteSpace(txtContraseña.Text) &&
                       !string.IsNullOrWhiteSpace(txtCorreo.Text) &&
                       !string.IsNullOrWhiteSpace(txtNom.Text) &&
                       !string.IsNullOrWhiteSpace(txtApe1.Text) &&
                       !string.IsNullOrWhiteSpace(txtNacionalidad.Text) &&
                       (chbPelis.Checked || chbActores.Checked || chbEstrenos.Checked || chbGuiones.Checked);
            }

            return false; 
        }
    }
}
