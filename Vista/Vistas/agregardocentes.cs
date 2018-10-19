using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.ControlVistas;

namespace documentosEstadia1._1.Vistas
{
    public partial class agregardocentes : Form
    {
        FlowLayoutPanel flp;

        public agregardocentes(FlowLayoutPanel flpClos,int modAgre)
        {
            InitializeComponent();
            flp=flpClos;
        }

        private void pictureBox1_cerrar_Click(object sender, EventArgs e)
        {
            flp.Visible = false;
        }
    }
}
