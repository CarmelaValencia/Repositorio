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

namespace Vista.Vistas
{
    public partial class agregarmaterias : Form
    {
        FlowLayoutPanel flpo;
        public agregarmaterias(FlowLayoutPanel flp,int agmd)
        {
            InitializeComponent();
            ControlVistaMateria controlVista = new ControlVistaMateria();
            controlVista.iniciarAgregarMaterias(this);
            flpo = flp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            flpo.Visible = false;
        }
    }
}
