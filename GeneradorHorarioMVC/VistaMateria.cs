using Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GeneradorHorarioMVC
{
    public partial class VistaMateria : Form
    {
        public VistaMateria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.DataSource = Conexion.Instance.Consultar();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           // Conexion.Instance.Guardar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Conexion.Instance.Eliminar();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Conexion.Instance.Actualizar();
        }
    }
}
