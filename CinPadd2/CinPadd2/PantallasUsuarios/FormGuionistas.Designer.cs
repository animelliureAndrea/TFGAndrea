namespace CinPadd2.PantallasUsuarios
{
    partial class FormGuionistas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGuionistas));
            this.gpbGuiones = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblSinopsis = new System.Windows.Forms.Label();
            this.lblGuionista = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnFestival = new System.Windows.Forms.Button();
            this.btnGuion = new System.Windows.Forms.Button();
            this.btnPerfil = new System.Windows.Forms.Button();
            this.btnPelis = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gpbGuiones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbGuiones
            // 
            this.gpbGuiones.BackColor = System.Drawing.Color.SeaGreen;
            this.gpbGuiones.Controls.Add(this.lblTitulo);
            this.gpbGuiones.Controls.Add(this.btnSiguiente);
            this.gpbGuiones.Controls.Add(this.lblSinopsis);
            this.gpbGuiones.Controls.Add(this.lblGuionista);
            this.gpbGuiones.Controls.Add(this.btnAnterior);
            this.gpbGuiones.Location = new System.Drawing.Point(96, 37);
            this.gpbGuiones.Name = "gpbGuiones";
            this.gpbGuiones.Size = new System.Drawing.Size(1011, 320);
            this.gpbGuiones.TabIndex = 13;
            this.gpbGuiones.TabStop = false;
            this.gpbGuiones.Text = "Guiones";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.SandyBrown;
            this.lblTitulo.Location = new System.Drawing.Point(67, 39);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitulo.Size = new System.Drawing.Size(86, 32);
            this.lblTitulo.TabIndex = 22;
            this.lblTitulo.Text = "label1";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(779, 266);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(132, 23);
            this.btnSiguiente.TabIndex = 21;
            this.btnSiguiente.Text = "Siguiente Guión";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblSinopsis
            // 
            this.lblSinopsis.AutoSize = true;
            this.lblSinopsis.Location = new System.Drawing.Point(75, 91);
            this.lblSinopsis.Name = "lblSinopsis";
            this.lblSinopsis.Size = new System.Drawing.Size(44, 16);
            this.lblSinopsis.TabIndex = 23;
            this.lblSinopsis.Text = "label2";
            // 
            // lblGuionista
            // 
            this.lblGuionista.AutoSize = true;
            this.lblGuionista.Location = new System.Drawing.Point(78, 147);
            this.lblGuionista.Name = "lblGuionista";
            this.lblGuionista.Size = new System.Drawing.Size(44, 16);
            this.lblGuionista.TabIndex = 25;
            this.lblGuionista.Text = "label1";
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(126, 266);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(122, 23);
            this.btnAnterior.TabIndex = 24;
            this.btnAnterior.Text = "Guión Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnFestival
            // 
            this.btnFestival.Image = global::CinPadd2.Properties.Resources.botón_festival;
            this.btnFestival.Location = new System.Drawing.Point(421, 410);
            this.btnFestival.Name = "btnFestival";
            this.btnFestival.Size = new System.Drawing.Size(78, 74);
            this.btnFestival.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnFestival, "Festivales");
            this.btnFestival.UseVisualStyleBackColor = true;
            this.btnFestival.Click += new System.EventHandler(this.btnFestival_Click);
            // 
            // btnGuion
            // 
            this.btnGuion.Image = global::CinPadd2.Properties.Resources.botón_guión;
            this.btnGuion.Location = new System.Drawing.Point(748, 410);
            this.btnGuion.Name = "btnGuion";
            this.btnGuion.Size = new System.Drawing.Size(78, 74);
            this.btnGuion.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnGuion, "Guiones");
            this.btnGuion.UseVisualStyleBackColor = true;
            this.btnGuion.Click += new System.EventHandler(this.btnGuion_Click);
            // 
            // btnPerfil
            // 
            this.btnPerfil.Image = global::CinPadd2.Properties.Resources.botón_perfil;
            this.btnPerfil.Location = new System.Drawing.Point(1029, 410);
            this.btnPerfil.Name = "btnPerfil";
            this.btnPerfil.Size = new System.Drawing.Size(78, 74);
            this.btnPerfil.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnPerfil, "Perfil");
            this.btnPerfil.UseVisualStyleBackColor = true;
            this.btnPerfil.Click += new System.EventHandler(this.btnPerfil_Click);
            // 
            // btnPelis
            // 
            this.btnPelis.Image = global::CinPadd2.Properties.Resources.claqueta_cine_22527;
            this.btnPelis.Location = new System.Drawing.Point(96, 410);
            this.btnPelis.Name = "btnPelis";
            this.btnPelis.Size = new System.Drawing.Size(78, 74);
            this.btnPelis.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnPelis, "Películas");
            this.btnPelis.UseVisualStyleBackColor = true;
            this.btnPelis.Click += new System.EventHandler(this.btnPelis_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Botón";
            // 
            // FormGuionistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(1203, 521);
            this.Controls.Add(this.btnFestival);
            this.Controls.Add(this.btnGuion);
            this.Controls.Add(this.btnPerfil);
            this.Controls.Add(this.btnPelis);
            this.Controls.Add(this.gpbGuiones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGuionistas";
            this.Text = "FormGuionistas";
            this.gpbGuiones.ResumeLayout(false);
            this.gpbGuiones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbGuiones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblSinopsis;
        private System.Windows.Forms.Label lblGuionista;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnFestival;
        private System.Windows.Forms.Button btnGuion;
        private System.Windows.Forms.Button btnPerfil;
        private System.Windows.Forms.Button btnPelis;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}