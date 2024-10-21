using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CinPadd2
{
    public partial class PantallaCarga : Form
    {
        //Data Source=FCMPORT2-WIN10;Initial Catalog=tfgCinPadd;Integrated Security=True;
        private int cont = 0;
        private Timer tiempo;
        public PantallaCarga()
        {
            InitializeComponent();
            iniciarTiempo();
        }

        private void iniciarTiempo()
        {
            tiempo = new Timer();
            tiempo.Interval = 100; // intervalo en miliSegs
            tiempo.Tick += Tiempo_Tick;
        }

        private void Tiempo_Tick(object sender, EventArgs e)
        {
            if (pgbTiempo.Value < 100)
            {
                pgbTiempo.Value += 5;

                //estó efectua el cambio de fotos
                if (pgbTiempo.Value % 20 == 0)
                {
                    pbFotos.Image = imlFotos.Images[cont];
                    cont = (cont + 1) % imlFotos.Images.Count;
                }

                //reiniciar el contador
                if (cont == imlFotos.Images.Count)
                {
                    cont = 0;
                }
            }
            else
            {
                tiempo.Stop();
                Acceso acceso = new Acceso();
                acceso.Show();
            }
        }

        private void PantallaCarga_Load(object sender, EventArgs e)
        {
            tiempo.Start();
        }
    }
}
