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
    public partial class materias_grupo : Form
    {
        FlowLayoutPanel flpo;
        public materias_grupo(FlowLayoutPanel flp)
        {
            InitializeComponent();

            object obj = new object[12];

            this.checkedListBox1.Items.AddRange(new object[] {
            "UNO",
            "DOS",
            "TRES",
            "CUATRO",
            "CINCO",
            "SEIS",
            "CIETE"});
        }

        private void pictureBox1_cerrar_Click(object sender, EventArgs e)
        {
            flpo.Visible = false;
        }
    }
}
