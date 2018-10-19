using Vista.ControlVistas;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Vista.Vistas
{
    public partial class materias : Form
    {
        agregarmaterias agm;
        public materias()
        {
            InitializeComponent();
            this.lista.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.lista.DefaultCellStyle.SelectionForeColor = Color.White;
            this.lista.DefaultCellStyle.SelectionBackColor = Color.Orange;
            ControlVistaMateria controlVistas = new ControlVistaMateria();
            controlVistas.iniciarMaterias(this);
            flowLayoutPanel1.Visible = false;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            ControlVistaMateria.opcion = "Registrar";
            flowLayoutPanel1.Controls.Remove(agm);
            agm = new agregarmaterias(flowLayoutPanel1);
            ControlVistaMateria.cargarValores(agm);
            agm.labelOpcion.Text = "AGREGAR MATERIA";
            agm.TopLevel = false;
            agm.Visible = true;
            flowLayoutPanel1.Width = this.Width;
            flowLayoutPanel1.Height = this.Height;
            flowLayoutPanel1.Controls.Add(agm);
            flowLayoutPanel1.Visible = true;
            agm.Width = flowLayoutPanel1.Width - 10;
            agm.Height = flowLayoutPanel1.Height - 10;
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            agm.Width = flowLayoutPanel1.Width - 10;
            agm.Height = flowLayoutPanel1.Height - 10;
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            ControlVistaMateria.opcion = "Modificar";
            flowLayoutPanel1.Controls.Remove(agm);
            flowLayoutPanel1.Visible = true;
            agm = new agregarmaterias(flowLayoutPanel1);
            agm.labelOpcion.Text = "MODIFICAR DATOS DE LA MATERIA";
            ControlVistaMateria.obtenerSeleccion();
            ControlVistaMateria.cargarValores(agm);
            agm.TopLevel = false;
            agm.Visible = true;
            flowLayoutPanel1.Width = this.Width;
            flowLayoutPanel1.Height = this.Height;
            flowLayoutPanel1.Controls.Add(agm);
            agm.Width = flowLayoutPanel1.Width - 10;
            agm.Height = flowLayoutPanel1.Height - 10;
        }
    }
}
