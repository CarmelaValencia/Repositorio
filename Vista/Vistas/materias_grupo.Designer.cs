namespace Vista.Vistas
{
    partial class materias_grupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(materias_grupo));
            this.labelOpcion = new System.Windows.Forms.Label();
            this.pictureBox_icon = new System.Windows.Forms.PictureBox();
            this.pictureBox1_cerrar = new System.Windows.Forms.PictureBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_cerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOpcion
            // 
            this.labelOpcion.AutoSize = true;
            this.labelOpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpcion.Location = new System.Drawing.Point(67, 29);
            this.labelOpcion.Name = "labelOpcion";
            this.labelOpcion.Size = new System.Drawing.Size(302, 20);
            this.labelOpcion.TabIndex = 5;
            this.labelOpcion.Text = "ASIGNAR MATERIAS A UN GRUPO";
            // 
            // pictureBox_icon
            // 
            this.pictureBox_icon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_icon.Image")));
            this.pictureBox_icon.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_icon.Name = "pictureBox_icon";
            this.pictureBox_icon.Size = new System.Drawing.Size(49, 47);
            this.pictureBox_icon.TabIndex = 4;
            this.pictureBox_icon.TabStop = false;
            // 
            // pictureBox1_cerrar
            // 
            this.pictureBox1_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1_cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1_cerrar.Image")));
            this.pictureBox1_cerrar.Location = new System.Drawing.Point(516, 12);
            this.pictureBox1_cerrar.Name = "pictureBox1_cerrar";
            this.pictureBox1_cerrar.Size = new System.Drawing.Size(49, 47);
            this.pictureBox1_cerrar.TabIndex = 3;
            this.pictureBox1_cerrar.TabStop = false;
            this.pictureBox1_cerrar.Click += new System.EventHandler(this.pictureBox1_cerrar_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 65);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(184, 169);
            this.checkedListBox1.TabIndex = 7;
            // 
            // materias_grupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(577, 296);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.labelOpcion);
            this.Controls.Add(this.pictureBox_icon);
            this.Controls.Add(this.pictureBox1_cerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "materias_grupo";
            this.Text = "materias_grupo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_cerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelOpcion;
        private System.Windows.Forms.PictureBox pictureBox_icon;
        private System.Windows.Forms.PictureBox pictureBox1_cerrar;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}