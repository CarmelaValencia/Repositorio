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
    public partial class horario : Form
    {
        agregarhorario agh;
        public horario()
        {
            InitializeComponent();
            this.lista.DefaultCellStyle.SelectionForeColor = Color.White;
            this.lista.DefaultCellStyle.SelectionBackColor = Color.Orange;
            this.lista.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            agh = new agregarhorario(flowLayoutPanel1);
            agh.TopLevel = false;
            agh.Visible = true;
            flowLayoutPanel1.Width = this.Width;
            flowLayoutPanel1.Height = this.Height;
            flowLayoutPanel1.Controls.Add(agh);
            flowLayoutPanel1.Visible = false;
           
            asignarTamanioVentanaResponsivo(agh);
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Remove(agh);
            agh = new agregarhorario(flowLayoutPanel1);
            agh.labelOpcion.Text = "AGREGAR HORARIO";
            agh.TopLevel = false;
            agh.Visible = true;
            flowLayoutPanel1.Width = this.Width;
            flowLayoutPanel1.Height = this.Height;
            flowLayoutPanel1.Controls.Add(agh);
            asignarTamanioVentanaResponsivo(agh);
            flowLayoutPanel1.Visible = true;
        }

        public void asignarTamanioVentanaResponsivo(Form frm)
        {
            frm.Width = flowLayoutPanel1.Width - 10;
            frm.Height = flowLayoutPanel1.Height - 10;
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            asignarTamanioVentanaResponsivo(agh);
        }
    }
}
