using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using documentosEstadia1._1;
using Vista.ControladorDB;
using Vista.Vistas;

namespace Vista.ControlVistas
{
    public class ControlVistaMateriasDocentes
    {

        public static int idSeleccionado=0;
        public static int idDocente = 0;
        ControlGrupo controlGrupo = new ControlGrupo();
        ControlMateria controlMateria = new ControlMateria();
        public static asignarMateriasDocente asignar = null;
        public static int [] listaIdMaterias;
        public static docentes vistaDocenteObj = null;

        public static void iniciarDocentes(docentes docentes,asignarMateriasDocente amd)
        {
            vistaDocenteObj = docentes;
            ControlVistaMateriasDocentes.ObtenerSeleccion();
            asignar = amd;
            
        }

        public static void ObtenerSeleccion() {
            int fila = vistaDocenteObj.lista.CurrentCell.RowIndex;
            DataRow row = ControlVistaDocente.tablaAux.Rows[fila];
            ControlVistaMateriasDocentes.idDocente = Convert.ToInt32(row["id_docentes"]);
            Console.WriteLine("Clic en asignar" + ControlVistaMateriasDocentes.idDocente);
        }
        

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
            int index = asignar.listaMaterias1.SelectedIndex;
            int materia=listaIdMaterias[asignar.listaMaterias1.SelectedIndex];
            if (asignar.listaMaterias1.GetItemChecked(index) == true)
            {
                //Desasignar materia al docente (grupo,materia,accion)
                Console.WriteLine("iddocente:"+ ControlVistaMateriasDocentes.idDocente);
                controlMateria.DesAsignarMaterias(idSeleccionado, materia, ControlVistaMateriasDocentes.idDocente);
            }
            else {
                //Asignar materia al docente (grupo,materia,accion)
                Console.WriteLine("iddocente:" + ControlVistaMateriasDocentes.idDocente);
                controlMateria.asignarMaterias(idSeleccionado, materia, ControlVistaMateriasDocentes.idDocente);
            }
        }

        private void combo_grupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            asignar.listaMaterias1.Items.Clear();
            idSeleccionado =Int32.Parse(asignar.combo_grupos.SelectedValue.ToString());
            
            DataRowCollection filas = controlMateria.ListarMaterias(idSeleccionado, ControlVistaMateriasDocentes.idDocente).Rows;
            listaIdMaterias = new int[filas.Count];

            for (int i = 0; i < filas.Count; i++)
            {
                DataRow fila = filas[i];
                listaIdMaterias[i] = Int32.Parse(fila["id_materias"].ToString());
                asignar.listaMaterias1.Items.Add(fila["nombre_materias"]);
            }
        }
        
    }
}
