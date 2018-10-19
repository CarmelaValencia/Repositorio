using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Vistas;
namespace Vista.ControlVistas
{
    /*Clase que controla todos los eventos de la vista materias y agregar materias:
    Control de eventos de los botones y caja de busqueda(6 eventos)
    */
    public class ControlVistaMateria
    {
        public static String opcion = "";
        public static agregarmaterias agregarmateriasobj = null;
        public static DataTable tablaAux = new DataTable();
        public static materias vistaMateriaObj = null;
        public static ModeloMateria mdloMateria = null;
        static ControlMateria controlMateria = new ControlMateria();
        public static int id = 0;
        
        public void iniciarMaterias(materias vistaMateria) {
            vistaMateriaObj = vistaMateria;
            rellenarTabla();
            vistaMateriaObj.btn_eliminar.Click += new EventHandler(btn_Delete);
            vistaMateriaObj.txt_buscar.TextChanged += new EventHandler(buscando);
        }
        public static void cargarValores(agregarmaterias agregarmaterias) {
            agregarmateriasobj = agregarmaterias;
            agregarmaterias.btn_aceptar.Click += new EventHandler(btn_aceptar_click);
            agregarmaterias.btn_cancelar.Click += new EventHandler(btn_cancelar_click);
            if (opcion.Equals("Registrar"))
            {
                mdloMateria = new ModeloMateria(0, "", 0, 0, "");
            }
            agregarmaterias.txt_nombre_materias.Text = mdloMateria.NombreMateria;
            agregarmaterias.txt_total_horas.Text = mdloMateria.Total_horas.ToString();
            agregarmaterias.txt_horas_semana.Text = mdloMateria.Horas_semana.ToString();
            agregarmaterias.txt_ciclo.Text = mdloMateria.Ciclo;
        }
        public static void obtenerSeleccion()
        {
            int fila = vistaMateriaObj.lista.CurrentCell.RowIndex;
            DataRow row = ControlVistaMateria.tablaAux.Rows[fila];
            Int32 valor = Convert.ToInt32(row["id_materias"]);
            mdloMateria = new ModeloMateria(valor, row["nombre_materias"].ToString(), Convert.ToInt32(row["total_horas"]),
                Convert.ToInt32(row["horas_semana"]), row["ciclo"].ToString());
        }
        private static void btn_cancelar_click(object sender, EventArgs e)
        {
            //agregarmateriasobj.Close();
        }
        private static void btn_aceptar_click(object sender, EventArgs e)
        {
            String nombre = agregarmateriasobj.txt_nombre_materias.Text;
            int total = int.Parse(agregarmateriasobj.txt_total_horas.Text);
            int semana = int.Parse(agregarmateriasobj.txt_horas_semana.Text);
            String ciclo = agregarmateriasobj.txt_ciclo.Text;
            mdloMateria = new ModeloMateria(mdloMateria.IdMateria, nombre, total, semana, ciclo);
            if (opcion.Equals("Registrar"))
            {
                if (controlMateria.Guardar(mdloMateria))
                {
                    rellenarTabla();
                    MessageBox.Show("Registro guardado");
                }
                else { MessageBox.Show("Error al guardar el registro"); }
            }
            else if (opcion.Equals("Modificar"))
            {
                if (controlMateria.Actualizar(mdloMateria))
                {
                    rellenarTabla();
                    MessageBox.Show("Registro actualizado");
                }
                else
                {
                    MessageBox.Show("Error al actualizar el registro");
                }
            }
        }
        private void buscando(object sender, EventArgs e)
        {
            rellenarTabla();
        }
        private void btn_Delete(object sender, EventArgs e)
        {
            int fila = vistaMateriaObj.lista.CurrentCell.RowIndex;
            DataRow row = tablaAux.Rows[fila];
            Int32 valor = Convert.ToInt32(row["id_materias"]);
            if (controlMateria.Eliminar(valor))
            {
                rellenarTabla();
                MessageBox.Show("Registro eliminado");
            }
            else
            {
                MessageBox.Show("Error al eliminar el registro");
            }
        }
        private static void rellenarTabla()
        {
            vistaMateriaObj.lista.DataSource = controlMateria.Consultar(vistaMateriaObj.txt_buscar.Text);
            tablaAux = controlMateria.RecuperarTablaAux();
        }
    }
}
