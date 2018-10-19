namespace Vista.Vistas
{
    partial class agregarmaterias
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
            this.txt_nombre_materias = new System.Windows.Forms.TextBox();
            this.txt_total_horas = new System.Windows.Forms.TextBox();
            this.txt_horas_semana = new System.Windows.Forms.TextBox();
            this.txt_ciclo = new System.Windows.Forms.TextBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_nombre_materias
            // 
            this.txt_nombre_materias.Location = new System.Drawing.Point(39, 26);
            this.txt_nombre_materias.Name = "txt_nombre_materias";
            this.txt_nombre_materias.Size = new System.Drawing.Size(266, 20);
            this.txt_nombre_materias.TabIndex = 0;
            // 
            // txt_total_horas
            // 
            this.txt_total_horas.Location = new System.Drawing.Point(39, 77);
            this.txt_total_horas.Name = "txt_total_horas";
            this.txt_total_horas.Size = new System.Drawing.Size(266, 20);
            this.txt_total_horas.TabIndex = 1;
            // 
            // txt_horas_semana
            // 
            this.txt_horas_semana.Location = new System.Drawing.Point(39, 133);
            this.txt_horas_semana.Name = "txt_horas_semana";
            this.txt_horas_semana.Size = new System.Drawing.Size(266, 20);
            this.txt_horas_semana.TabIndex = 2;
            // 
            // txt_ciclo
            // 
            this.txt_ciclo.Location = new System.Drawing.Point(39, 184);
            this.txt_ciclo.Name = "txt_ciclo";
            this.txt_ciclo.Size = new System.Drawing.Size(266, 20);
            this.txt_ciclo.TabIndex = 3;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(39, 225);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_aceptar.TabIndex = 4;
            this.btn_aceptar.Text = "ACEPTAR";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(230, 225);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 5;
            this.btn_cancelar.Text = "CANCELAR";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // agregarmaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.txt_ciclo);
            this.Controls.Add(this.txt_horas_semana);
            this.Controls.Add(this.txt_total_horas);
            this.Controls.Add(this.txt_nombre_materias);
            this.Name = "agregarmaterias";
            this.Text = "agregarmaterias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btn_aceptar;
        public System.Windows.Forms.Button btn_cancelar;
        public System.Windows.Forms.TextBox txt_nombre_materias;
        public System.Windows.Forms.TextBox txt_total_horas;
        public System.Windows.Forms.TextBox txt_horas_semana;
        public System.Windows.Forms.TextBox txt_ciclo;
    }
}