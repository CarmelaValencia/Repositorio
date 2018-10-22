using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using Vista.ControladorDB;
using Vista.Vistas;

namespace Vista.ControlVistas
{
    public class ControlVistaMateriasDocentes
    {
        public int idSeleccionado=0;
        ControlGrupo controlGrupo = new ControlGrupo();
        ControlMateria controlMateria = new ControlMateria();
        public static asignarMateriasDocente asignar = null;
        public static int listaIdMaterias;

        public void llenarCombo(asignarMateriasDocente vista) {
            asignar = vista;
            DataTable dt = controlGrupo.ListarGrupos();
            asignar.combo_grupos.DataSource = dt;
            asignar.combo_grupos.DisplayMember = "nombreGrupos";
            asignar.combo_grupos.ValueMember ="id_grupos";
            asignar.combo_grupos.SelectedIndexChanged += new EventHandler(combo_grupos_SelectedIndexChanged);
            asignar.listaMaterias1.ItemCheck += new ItemCheckEventHandler(lista_materias_selected_index);
        }

        private void lista_materias_selected_index(object sender, EventArgs e)
        {
            Console.WriteLine("seleccionando"+asignar.listaMaterias1.SelectedIndex.ToString());
        }

        private void combo_grupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            asignar.listaMaterias1.Items.Clear();
            idSeleccionado =Int32.Parse(asignar.combo_grupos.SelectedValue.ToString());
            
            DataRowCollection filas = controlMateria.ListarMaterias(idSeleccionado).Rows;
            listaIdMaterias = new int();

            for (int i = 0; i < filas.Count; i++)
            {
                DataRow fila = filas[i];
                
                asignar.listaMaterias1.Items.Add(fila["nombre_materias"]);
            }
           
            

        }
    }
}
