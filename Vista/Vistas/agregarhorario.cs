using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Vistas
{
    public partial class agregarhorario : Form
    {
        FlowLayoutPanel flpo;
        public agregarhorario(FlowLayoutPanel flp)
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
