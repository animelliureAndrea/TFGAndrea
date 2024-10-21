namespace CinPadd.NoComunes
{
    partial class Planificación
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Planificación));
            this.dtpDia = new System.Windows.Forms.DateTimePicker();
            this.dtgPlanes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbGrabar = new System.Windows.Forms.RadioButton();
            this.rdbEditar = new System.Windows.Forms.RadioButton();
            this.rdbCasting = new System.Windows.Forms.RadioButton();
            this.rdbPresentacion = new System.Windows.Forms.RadioButton();
            this.btnSubir = new System.Windows.Forms.Button();
            this.lblHora = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.lblLlamada = new System.Windows.Forms.Label();
            this.txtLlamadas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProblemas = new System.Windows.Forms.TextBox();
            this.rdbDecorado = new System.Windows.Forms.RadioButton();
            this.rdbPubli = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.chbEnProceso = new System.Windows.Forms.CheckBox();
            this.chbSinEmpezar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDia
            // 
            this.dtpDia.Location = new System.Drawing.Point(61, 42);
            this.dtpDia.Name = "dtpDia";
            this.dtpDia.Size = new System.Drawing.Size(200, 22);
            this.dtpDia.TabIndex = 0;
            // 
            // dtgPlanes
            // 
            this.dtgPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanes.Location = new System.Drawing.Point(400, 31);
            this.dtgPlanes.Name = "dtgPlanes";
            this.dtgPlanes.RowHeadersWidth = 51;
            this.dtgPlanes.RowTemplate.Height = 24;
            this.dtgPlanes.Size = new System.Drawing.Size(518, 461);
            this.dtgPlanes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "¿Que vas a hacer ese día?";
            // 
            // rdbGrabar
            // 
            this.rdbGrabar.AutoSize = true;
            this.rdbGrabar.Location = new System.Drawing.Point(90, 115);
            this.rdbGrabar.Name = "rdbGrabar";
            this.rdbGrabar.Size = new System.Drawing.Size(91, 20);
            this.rdbGrabar.TabIndex = 3;
            this.rdbGrabar.TabStop = true;
            this.rdbGrabar.Text = "Grabación";
            this.rdbGrabar.UseVisualStyleBackColor = true;
            // 
            // rdbEditar
            // 
            this.rdbEditar.AutoSize = true;
            this.rdbEditar.Location = new System.Drawing.Point(90, 154);
            this.rdbEditar.Name = "rdbEditar";
            this.rdbEditar.Size = new System.Drawing.Size(73, 20);
            this.rdbEditar.TabIndex = 4;
            this.rdbEditar.TabStop = true;
            this.rdbEditar.Text = "Edición";
            this.rdbEditar.UseVisualStyleBackColor = true;
            // 
            // rdbCasting
            // 
            this.rdbCasting.AutoSize = true;
            this.rdbCasting.Location = new System.Drawing.Point(200, 115);
            this.rdbCasting.Name = "rdbCasting";
            this.rdbCasting.Size = new System.Drawing.Size(73, 20);
            this.rdbCasting.TabIndex = 5;
            this.rdbCasting.TabStop = true;
            this.rdbCasting.Text = "Casting";
            this.rdbCasting.UseVisualStyleBackColor = true;
            // 
            // rdbPresentacion
            // 
            this.rdbPresentacion.AutoSize = true;
            this.rdbPresentacion.Location = new System.Drawing.Point(200, 154);
            this.rdbPresentacion.Name = "rdbPresentacion";
            this.rdbPresentacion.Size = new System.Drawing.Size(107, 20);
            this.rdbPresentacion.TabIndex = 6;
            this.rdbPresentacion.TabStop = true;
            this.rdbPresentacion.Text = "Presentación";
            this.rdbPresentacion.UseVisualStyleBackColor = true;
            // 
            // btnSubir
            // 
            this.btnSubir.Location = new System.Drawing.Point(29, 415);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(131, 23);
            this.btnSubir.TabIndex = 7;
            this.btnSubir.Text = "Subir plan";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(29, 276);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(62, 16);
            this.lblHora.TabIndex = 8;
            this.lblHora.Text = "Horarios:";
            // 
            // txtHora
            // 
            this.txtHora.Location = new System.Drawing.Point(29, 305);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(134, 22);
            this.txtHora.TabIndex = 9;
            // 
            // lblLlamada
            // 
            this.lblLlamada.AutoSize = true;
            this.lblLlamada.Location = new System.Drawing.Point(32, 347);
            this.lblLlamada.Name = "lblLlamada";
            this.lblLlamada.Size = new System.Drawing.Size(70, 16);
            this.lblLlamada.TabIndex = 10;
            this.lblLlamada.Text = "Llamadas:";
            // 
            // txtLlamadas
            // 
            this.txtLlamadas.Location = new System.Drawing.Point(29, 375);
            this.txtLlamadas.Name = "txtLlamadas";
            this.txtLlamadas.Size = new System.Drawing.Size(134, 22);
            this.txtLlamadas.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Problemas de personal:";
            // 
            // txtProblemas
            // 
            this.txtProblemas.Location = new System.Drawing.Point(185, 305);
            this.txtProblemas.Name = "txtProblemas";
            this.txtProblemas.Size = new System.Drawing.Size(148, 22);
            this.txtProblemas.TabIndex = 13;
            // 
            // rdbDecorado
            // 
            this.rdbDecorado.AutoSize = true;
            this.rdbDecorado.Location = new System.Drawing.Point(200, 191);
            this.rdbDecorado.Name = "rdbDecorado";
            this.rdbDecorado.Size = new System.Drawing.Size(96, 20);
            this.rdbDecorado.TabIndex = 14;
            this.rdbDecorado.TabStop = true;
            this.rdbDecorado.Text = "Decorados";
            this.rdbDecorado.UseVisualStyleBackColor = true;
            // 
            // rdbPubli
            // 
            this.rdbPubli.AutoSize = true;
            this.rdbPubli.Location = new System.Drawing.Point(90, 191);
            this.rdbPubli.Name = "rdbPubli";
            this.rdbPubli.Size = new System.Drawing.Size(92, 20);
            this.rdbPubli.TabIndex = 15;
            this.rdbPubli.TabStop = true;
            this.rdbPubli.Text = "Publicidad";
            this.rdbPubli.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Estado de la actividad:";
            // 
            // btnAtras
            // 
            this.btnAtras.BackgroundImage = global::CinPadd2.Properties.Resources.flecha_pequeña;
            this.btnAtras.Location = new System.Drawing.Point(12, 3);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(67, 23);
            this.btnAtras.TabIndex = 50;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // chbEnProceso
            // 
            this.chbEnProceso.AutoSize = true;
            this.chbEnProceso.Location = new System.Drawing.Point(200, 401);
            this.chbEnProceso.Name = "chbEnProceso";
            this.chbEnProceso.Size = new System.Drawing.Size(99, 20);
            this.chbEnProceso.TabIndex = 64;
            this.chbEnProceso.Text = "En Proceso";
            this.chbEnProceso.UseVisualStyleBackColor = true;
            // 
            // chbSinEmpezar
            // 
            this.chbSinEmpezar.AutoSize = true;
            this.chbSinEmpezar.Location = new System.Drawing.Point(200, 375);
            this.chbSinEmpezar.Name = "chbSinEmpezar";
            this.chbSinEmpezar.Size = new System.Drawing.Size(105, 20);
            this.chbSinEmpezar.TabIndex = 63;
            this.chbSinEmpezar.Text = "Sin Empezar";
            this.chbSinEmpezar.UseVisualStyleBackColor = true;
            // 
            // Planificación
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(948, 516);
            this.Controls.Add(this.chbEnProceso);
            this.Controls.Add(this.chbSinEmpezar);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdbPubli);
            this.Controls.Add(this.rdbDecorado);
            this.Controls.Add(this.txtProblemas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLlamadas);
            this.Controls.Add(this.lblLlamada);
            this.Controls.Add(this.txtHora);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.rdbPresentacion);
            this.Controls.Add(this.rdbCasting);
            this.Controls.Add(this.rdbEditar);
            this.Controls.Add(this.rdbGrabar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgPlanes);
            this.Controls.Add(this.dtpDia);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Planificación";
            this.Text = "Planificación";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDia;
        private System.Windows.Forms.DataGridView dtgPlanes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbGrabar;
        private System.Windows.Forms.RadioButton rdbEditar;
        private System.Windows.Forms.RadioButton rdbCasting;
        private System.Windows.Forms.RadioButton rdbPresentacion;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label lblLlamada;
        private System.Windows.Forms.TextBox txtLlamadas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProblemas;
        private System.Windows.Forms.RadioButton rdbDecorado;
        private System.Windows.Forms.RadioButton rdbPubli;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.CheckBox chbEnProceso;
        private System.Windows.Forms.CheckBox chbSinEmpezar;
    }
}