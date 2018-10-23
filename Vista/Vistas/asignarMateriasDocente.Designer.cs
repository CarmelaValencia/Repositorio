namespace Vista.Vistas
{
    partial class asignarMateriasDocente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(asignarMateriasDocente));
            this.combo_grupos = new System.Windows.Forms.ComboBox();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.listaMaterias1 = new System.Windows.Forms.CheckedListBox();
            this.pictureBox1_cerrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_cerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // combo_grupos
            // 
            this.combo_grupos.FormattingEnabled = true;
            this.combo_grupos.Location = new System.Drawing.Point(21, 49);
            this.combo_grupos.Name = "combo_grupos";
            this.combo_grupos.Size = new System.Drawing.Size(303, 21);
            this.combo_grupos.TabIndex = 0;
            // 
            // txt_buscar
            // 
            this.txt_buscar.Location = new System.Drawing.Point(21, 23);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(303, 20);
            this.txt_buscar.TabIndex = 1;
            // 
            // listaMaterias1
            // 
            this.listaMaterias1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaMaterias1.FormattingEnabled = true;
            this.listaMaterias1.Location = new System.Drawing.Point(21, 100);
            this.listaMaterias1.Name = "listaMaterias1";
            this.listaMaterias1.Size = new System.Drawing.Size(381, 274);
            this.listaMaterias1.TabIndex = 2;
            // 
            // pictureBox1_cerrar
            // 
            this.pictureBox1_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1_cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1_cerrar.Image")));
            this.pictureBox1_cerrar.Location = new System.Drawing.Point(379, 12);
            this.pictureBox1_cerrar.Name = "pictureBox1_cerrar";
            this.pictureBox1_cerrar.Size = new System.Drawing.Size(49, 47);
            this.pictureBox1_cerrar.TabIndex = 32;
            this.pictureBox1_cerrar.TabStop = false;
            this.pictureBox1_cerrar.Click += new System.EventHandler(this.pictureBox1_cerrar_Click);
            // 
            // asignarMateriasDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 450);
            this.Controls.Add(this.pictureBox1_cerrar);
            this.Controls.Add(this.listaMaterias1);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.combo_grupos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "asignarMateriasDocente";
            this.Text = "asignarMateriasDocente";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_cerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txt_buscar;
        public System.Windows.Forms.ComboBox combo_grupos;
        public System.Windows.Forms.CheckedListBox listaMaterias1;
        private System.Windows.Forms.PictureBox pictureBox1_cerrar;
    }
}