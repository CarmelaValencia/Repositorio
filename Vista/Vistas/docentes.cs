using documentosEstadia1._1.Vistas;
using System;
using System.Drawing;
using System.Windows.Forms;
using Vista.ControlVistas;

namespace documentosEstadia1._1
{
    public partial class docentes : Form
    {
        agregardocentes agd;
        public docentes()
        {
            InitializeComponent();
            this.lista.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.lista.DefaultCellStyle.SelectionForeColor = Color.White;
            this.lista.DefaultCellStyle.SelectionBackColor = Color.Orange;
            //lista.Rows.Add("TextBox1.Text", "TextBox2.Text", "Textbox3.TExt");

            agd = new agregardocentes(flowLayoutPanel1,-1);
            agd.TopLevel = false;
            agd.Visible = true;
            flowLayoutPanel1.Width = this.Width;
            flowLayoutPanel1.Height = this.Height;
            flowLayoutPanel1.Controls.Add(agd);
            flowLayoutPanel1.Visible = false;
            ControlVistaDocente controlVistaDocente = new ControlVistaDocente();
            controlVistaDocente.iniciarDocentes(this);
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            agd.Width = flowLayoutPanel1.Width-10;
            agd.Height = flowLayoutPanel1.Height-10;
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            ControlVistaDocente.opcion = "Modificar";
            Console.WriteLine("evento estable opcion:" + ControlVistaDocente.opcion);
            ControlVistaDocente controlVistaDocente = new ControlVistaDocente();
            controlVistaDocente.iniciarAgregarDocentes(new agregardocentes(flowLayoutPanel1, -1));
            flowLayoutPanel1.Visible = true;
        }
    }
}
