using System.Drawing;
using System.Windows.Forms;

namespace Vista.Vistas
{
    public partial class grupos : Form
    {
        public grupos()
        {
            InitializeComponent();
            this.lista.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.lista.DefaultCellStyle.SelectionForeColor = Color.White;
            this.lista.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }

        private void btn_agregar_Click(object sender, System.EventArgs e)
        {

        }
    }
}
