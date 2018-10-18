using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ControlVistas
{
    public class ControlVistaMateria
    {
        public ControlVistaMateria(Form form) {
            
            //.Click += new EventHandler(clickAdd);
        }
        

        private void clickAdd(object sender, EventArgs e)
        {
            MessageBox.Show("Evento agregar nuevo");
        }
    }
}
