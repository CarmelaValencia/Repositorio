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
            this.combo_grupos = new System.Windows.Forms.ComboBox();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.listaMaterias1 = new System.Windows.Forms.CheckedListBox();
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
            this.listaMaterias1.FormattingEnabled = true;
            this.listaMaterias1.Location = new System.Drawing.Point(21, 100);
            this.listaMaterias1.Name = "listaMaterias1";
            this.listaMaterias1.Size = new System.Drawing.Size(360, 229);
            this.listaMaterias1.TabIndex = 2;
            // 
            // asignarMateriasDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listaMaterias1);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.combo_grupos);
            this.Name = "asignarMateriasDocente";
            this.Text = "asignarMateriasDocente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txt_buscar;
        public System.Windows.Forms.ComboBox combo_grupos;
        public System.Windows.Forms.CheckedListBox listaMaterias1;
    }
}