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
    public partial class asignarMateriasDocente : Form
    {
        FlowLayoutPanel flpo;
        public asignarMateriasDocente(FlowLayoutPanel flp)
        {
            InitializeComponent();
            ControlVistaMateriasDocentes control = new ControlVistaMateriasDocentes();
            control.llenarCombo(this);
            flpo = flp;
        }
    }
}
