﻿using System;
using System.Windows.Forms;
using Vista.ControlVistas;

namespace Vista.Vistas
{
    public partial class agregarmaterias : Form
    {
        FlowLayoutPanel flpo;
        public agregarmaterias(FlowLayoutPanel flp)
        {
            InitializeComponent();
            flpo = flp;
        }

        private void pictureBox1_cerrar_Click(object sender, EventArgs e)
        {
            flpo.Visible = false;
        }
    }
}
