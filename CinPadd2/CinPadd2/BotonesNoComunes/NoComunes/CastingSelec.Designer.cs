namespace CinPadd.NoComunes
{
    partial class CastingSelec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CastingSelec));
            this.btnAtras = new System.Windows.Forms.Button();
            this.dtgCastings = new System.Windows.Forms.DataGridView();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnDirector = new System.Windows.Forms.Button();
            this.txtDirector = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCastings)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.BackgroundImage = global::CinPadd2.Properties.Resources.flecha_pequeña;
            this.btnAtras.Location = new System.Drawing.Point(15, 14);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(67, 23);
            this.btnAtras.TabIndex = 50;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // dtgCastings
            // 
            this.dtgCastings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCastings.Location = new System.Drawing.Point(60, 69);
            this.dtgCastings.Margin = new System.Windows.Forms.Padding(4);
            this.dtgCastings.Name = "dtgCastings";
            this.dtgCastings.RowHeadersWidth = 51;
            this.dtgCastings.Size = new System.Drawing.Size(883, 322);
            this.dtgCastings.TabIndex = 51;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(60, 428);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(100, 28);
            this.btnBorrar.TabIndex = 52;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnDirector
            // 
            this.btnDirector.Location = new System.Drawing.Point(60, 480);
            this.btnDirector.Margin = new System.Windows.Forms.Padding(4);
            this.btnDirector.Name = "btnDirector";
            this.btnDirector.Size = new System.Drawing.Size(100, 28);
            this.btnDirector.TabIndex = 53;
            this.btnDirector.Text = "Ver director";
            this.btnDirector.UseVisualStyleBackColor = true;
            this.btnDirector.Click += new System.EventHandler(this.btnDirector_Click);
            // 
            // txtDirector
            // 
            this.txtDirector.Location = new System.Drawing.Point(232, 428);
            this.txtDirector.Margin = new System.Windows.Forms.Padding(4);
            this.txtDirector.Multiline = true;
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(240, 79);
            this.txtDirector.TabIndex = 54;
            // 
            // CastingSelec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.txtDirector);
            this.Controls.Add(this.btnDirector);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.dtgCastings);
            this.Controls.Add(this.btnAtras);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CastingSelec";
            this.Text = "CastingSelec";
            ((System.ComponentModel.ISupportInitialize)(this.dtgCastings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.DataGridView dtgCastings;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnDirector;
        private System.Windows.Forms.TextBox txtDirector;
    }
}