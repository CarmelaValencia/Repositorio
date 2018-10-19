using System.Drawing;
using System.Windows.Forms;

namespace Vista.Vistas
{
    public partial class grupos : Form
    {
        agregargrupos agg;
        public grupos()
        {
            InitializeComponent();
            this.lista.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.lista.DefaultCellStyle.SelectionForeColor = Color.White;
            this.lista.DefaultCellStyle.SelectionBackColor = Color.Orange;
            flowLayoutPanel1.Visible = false;
            //asignarTamanioVentanaResponsivo(agg);
        }

        private void btn_agregar_Click(object sender, System.EventArgs e)
        {
            flowLayoutPanel1.Controls.Remove(agg);
            agg = new agregargrupos(flowLayoutPanel1);
            agg.TopLevel = false;
            agg.Visible = true;
            flowLayoutPanel1.Width = this.Width;
            flowLayoutPanel1.Height = this.Height;
            flowLayoutPanel1.Controls.Add(agg);
            asignarTamanioVentanaResponsivo(agg);
            flowLayoutPanel1.Visible = true;
        }

        private void flowLayoutPanel1_Resize(object sender, System.EventArgs e)
        {
            asignarTamanioVentanaResponsivo(agg);
        }

        public void asignarTamanioVentanaResponsivo(Form frm) {
            frm.Width = flowLayoutPanel1.Width - 10;
            frm.Height = flowLayoutPanel1.Height - 10;
        }
    }
}
