namespace CinPadd.NoComunes
{
    partial class Gente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gente));
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnActores = new System.Windows.Forms.Button();
            this.btnDirectores = new System.Windows.Forms.Button();
            this.btnGuionistas = new System.Windows.Forms.Button();
            this.dtgDirectores = new System.Windows.Forms.DataGridView();
            this.dtgGuionistas = new System.Windows.Forms.DataGridView();
            this.dtgActores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDirectores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGuionistas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActores)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.BackgroundImage = global::CinPadd2.Properties.Resources.flecha_pequeña;
            this.btnAtras.Location = new System.Drawing.Point(19, 18);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(67, 23);
            this.btnAtras.TabIndex = 68;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnActores
            // 
            this.btnActores.Location = new System.Drawing.Point(31, 115);
            this.btnActores.Name = "btnActores";
            this.btnActores.Size = new System.Drawing.Size(161, 23);
            this.btnActores.TabIndex = 66;
            this.btnActores.Text = "Actores";
            this.btnActores.UseVisualStyleBackColor = true;
            this.btnActores.Click += new System.EventHandler(this.btnCambioTotal_Click);
            // 
            // btnDirectores
            // 
            this.btnDirectores.Location = new System.Drawing.Point(31, 68);
            this.btnDirectores.Name = "btnDirectores";
            this.btnDirectores.Size = new System.Drawing.Size(161, 25);
            this.btnDirectores.TabIndex = 65;
            this.btnDirectores.Text = "Directores";
            this.btnDirectores.UseVisualStyleBackColor = true;
            this.btnDirectores.Click += new System.EventHandler(this.btnAlgunCambio_Click);
            // 
            // btnGuionistas
            // 
            this.btnGuionistas.Location = new System.Drawing.Point(31, 161);
            this.btnGuionistas.Name = "btnGuionistas";
            this.btnGuionistas.Size = new System.Drawing.Size(161, 23);
            this.btnGuionistas.TabIndex = 69;
            this.btnGuionistas.Text = "Guionistas";
            this.btnGuionistas.UseVisualStyleBackColor = true;
            this.btnGuionistas.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtgDirectores
            // 
            this.dtgDirectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDirectores.Location = new System.Drawing.Point(228, 34);
            this.dtgDirectores.Name = "dtgDirectores";
            this.dtgDirectores.RowHeadersWidth = 51;
            this.dtgDirectores.RowTemplate.Height = 24;
            this.dtgDirectores.Size = new System.Drawing.Size(550, 391);
            this.dtgDirectores.TabIndex = 70;
            // 
            // dtgGuionistas
            // 
            this.dtgGuionistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGuionistas.Location = new System.Drawing.Point(228, 34);
            this.dtgGuionistas.Name = "dtgGuionistas";
            this.dtgGuionistas.RowHeadersWidth = 51;
            this.dtgGuionistas.RowTemplate.Height = 24;
            this.dtgGuionistas.Size = new System.Drawing.Size(550, 391);
            this.dtgGuionistas.TabIndex = 71;
            // 
            // dtgActores
            // 
            this.dtgActores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActores.Location = new System.Drawing.Point(228, 34);
            this.dtgActores.Name = "dtgActores";
            this.dtgActores.RowHeadersWidth = 51;
            this.dtgActores.RowTemplate.Height = 24;
            this.dtgActores.Size = new System.Drawing.Size(550, 391);
            this.dtgActores.TabIndex = 72;
            // 
            // Gente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgActores);
            this.Controls.Add(this.dtgGuionistas);
            this.Controls.Add(this.dtgDirectores);
            this.Controls.Add(this.btnGuionistas);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnActores);
            this.Controls.Add(this.btnDirectores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Gente";
            this.Text = "Gente";
            ((System.ComponentModel.ISupportInitialize)(this.dtgDirectores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGuionistas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnActores;
        private System.Windows.Forms.Button btnDirectores;
        private System.Windows.Forms.Button btnGuionistas;
        private System.Windows.Forms.DataGridView dtgDirectores;
        private System.Windows.Forms.DataGridView dtgGuionistas;
        private System.Windows.Forms.DataGridView dtgActores;
    }
}