using documentosEstadia1._1.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace documentosEstadia1._1
{
    public partial class docentes : Form
    {
        agregardocentes agd;
        public docentes()
        {
            InitializeComponent();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Orange;
            dataGridView1.Rows.Add("TextBox1.Text", "TextBox2.Text", "Textbox3.TExt");

            agd = new agregardocentes(flowLayoutPanel1,-1);
            agd.TopLevel = false;
            agd.Visible = true;
            flowLayoutPanel1.Width = this.Width;
            flowLayoutPanel1.Height = this.Height;
            flowLayoutPanel1.Controls.Add(agd);
            flowLayoutPanel1.Visible = false;
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
    }
}
