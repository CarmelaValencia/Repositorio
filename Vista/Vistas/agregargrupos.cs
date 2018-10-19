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
    public partial class agregargrupos : Form
    {
        FlowLayoutPanel flpo;
        public agregargrupos(FlowLayoutPanel flp)
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
