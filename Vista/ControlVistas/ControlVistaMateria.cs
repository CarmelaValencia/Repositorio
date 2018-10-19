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
        public static int id = 0;
        public static String opcion = "";
        agregarmaterias agregarmateriasobj = null;
        materias vistaMateriaObj = null;
        ModeloMateria mdloMateria = new ModeloMateria(0, "", 0, 0, "");
        ControlMateria controlMateria = new ControlMateria();
        public ControlVistaMateria(){

        }

        public void iniciarMaterias(materias vistaMateria) {
            vistaMateriaObj = vistaMateria;
            rellenarTabla();
            //vistaMateriaObj.btn_agregar.Click += new EventHandler(btn_Add);
            vistaMateriaObj.btn_eliminar.Click += new EventHandler(btn_Delete);
            vistaMateriaObj.btn_modificar.Click += new EventHandler(btn_Update_Click);
            vistaMateriaObj.txt_buscar.TextChanged += new EventHandler(buscando);
        }
        public void rellenarTabla() {
            DataTable dataTable= controlMateria.Consultar("");
            vistaMateriaObj.lista.Columns.Add("NOMBRE","NOMBRE");
            vistaMateriaObj.lista.Rows.Add(dataTable.Rows.GetEnumerator().MoveNext().ToString());
        }

        private void buscando(object sender, EventArgs e)
        {
            vistaMateriaObj.lista.DataSource = controlMateria.Consultar(vistaMateriaObj.txt_buscar.Text);
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            ControlVistaMateria.id = 5;
            mdloMateria.NombreMateria = "Matematicas";
            mdloMateria.Total_horas = 100;
            mdloMateria.Horas_semana = 5;
            mdloMateria.Ciclo = "2018B";
            agregarmaterias agregarmateriasobj = new agregarmaterias(new FlowLayoutPanel());
            ControlVistaMateria.opcion= "Modificar";
            agregarmateriasobj.txt_nombre_materias.Text = mdloMateria.NombreMateria;
            agregarmateriasobj.txt_total_horas.Text =mdloMateria.Total_horas.ToString();
            agregarmateriasobj.txt_horas_semana.Text = mdloMateria.Horas_semana.ToString();
            agregarmateriasobj.txt_ciclo.Text = mdloMateria.Ciclo;
            agregarmateriasobj.Show();
        }

        /*private void btn_Add(object sender, EventArgs e)
        {
            agregarmaterias agregarmateriasobj = new agregarmaterias(new FlowLayoutPanel());
            ControlVistaMateria.opcion = "Registrar";
            agregarmateriasobj.Show();
        }*/

        private void btn_Delete(object sender, EventArgs e)
        {
            int fila = vistaMateriaObj.lista.CurrentCell.RowIndex;
            MessageBox.Show("fila:"+fila+"::valor:"+vistaMateriaObj.lista.CurrentCell.Value,"Mensaje de Confirmación");
        }

        public void iniciarAgregarMaterias(agregarmaterias addMaterias) {
            agregarmateriasobj = addMaterias;
            agregarmateriasobj.btn_aceptar.Click += new EventHandler(btn_aceptar_click);
            agregarmateriasobj.btn_cancelar.Click += new EventHandler(btn_cancelar_click);
        }

        private void btn_cancelar_click(object sender, EventArgs e)
        {
            agregarmateriasobj.Close();
        }

        private void btn_aceptar_click(object sender, EventArgs e)
        {
            String nombre = agregarmateriasobj.txt_nombre_materias.Text;
            int total =int.Parse(agregarmateriasobj.txt_total_horas.Text);
            int semana = int.Parse(agregarmateriasobj.txt_horas_semana.Text);
            String ciclo = agregarmateriasobj.txt_ciclo.Text;
            mdloMateria = new ModeloMateria(id, nombre, total, semana, ciclo);
            ControlMateria controlMateria = new ControlMateria();
            if (opcion.Equals("Registrar")) {
                if (controlMateria.Guardar(mdloMateria)){MessageBox.Show("Registro guardado");}
                else{MessageBox.Show("Error al guardar el registro"); }
            }else if(opcion.Equals("Modificar")){
                if (controlMateria.Actualizar(mdloMateria))
                {
                    MessageBox.Show("Registro actualizado");
                }
                else
                {
                    MessageBox.Show("Error al actualizar el registro");
                }
            }
        }
    }
}
