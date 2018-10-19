using Vista.ControlVistas;
using System;
using System.Windows.Forms;

namespace Vista.Vistas
{
    public partial class materias : Form
    {
        public materias()
        {
            InitializeComponent();
            ControlVistaMateria controlVistas = new ControlVistaMateria();
            controlVistas.iniciarMaterias(this);
        }
    }
}
