using System;
using documentosEstadia1._1;
using Vista.Modelos;
using documentosEstadia1._1.Vistas;
using Vista.ControladorDB;
using System.Windows.Forms;
using System.Data;

namespace Vista.ControlVistas
{
    class ControlVistaDocente
    {
        public static int id = 0;
        public static String nombre = "";
        public static String apellidos = "";
        public static Int32 numero_horas = 0;
        public static String estado = "";
        public static String opcion = "";
        agregardocentes vistaAgregar = null;
        DataTable tablaAux = new DataTable();
        docentes vistaDocenteObj = null;
        ModeloDocente mdloDocente = new ModeloDocente(0, "", "", 0, "");
        ControlDocente controlDocente = new ControlDocente();
        public void iniciarDocentes(docentes docentes)
        {
            vistaDocenteObj = docentes;
            rellenarTabla();
            vistaDocenteObj.btn_eliminar.Click += new EventHandler(btn_Delete);
            vistaDocenteObj.btn_agregar.Click += new EventHandler(btn_Add);
            vistaDocenteObj.btn_modificar.Click += new EventHandler(btn_Update_Click);
            vistaDocenteObj.txt_buscar.TextChanged += new EventHandler(buscando);
        }

        private void btn_Add(object sender, EventArgs e)
        {
            ControlVistaDocente.opcion = "Registrar";
        }

        public void iniciarAgregarDocentes(agregardocentes agregardocentesObj) {
            vistaAgregar = agregardocentesObj;
            vistaAgregar.btn_aceptar.Click += new EventHandler(btn_aceptar);
            vistaAgregar.btn_cancelar.Click += new EventHandler(btn_cancelar);
            MessageBox.Show("opcion:"+opcion);
            if (opcion.Equals("Modificar")) {
                cargarValores(vistaAgregar);
            }
        }

        public  void cargarValores(agregardocentes vistaAgregar)
        {
            /*
            */


            vistaAgregar.txt_nombre_docentes.Text = "nombre";
            vistaAgregar.txt_apellidos.Text = ControlVistaDocente.apellidos;
            vistaAgregar.txt_numero_horas.Text = ControlVistaDocente.numero_horas.ToString();
            vistaAgregar.txt_estado.Text =ControlVistaDocente.estado;
        }

        private void btn_cancelar(object sender, EventArgs e)
        {
            
        }

        private void btn_aceptar(object sender, EventArgs e)
        {
            String nombre = vistaAgregar.txt_nombre_docentes.Text;
            String apellidos = vistaAgregar.txt_apellidos.Text;
            int numero_horas = int.Parse(vistaAgregar.txt_numero_horas.Text);
            String estado = vistaAgregar.txt_estado.Text;
            mdloDocente = new ModeloDocente(id, nombre, apellidos, numero_horas, estado);
            if (opcion.Equals("Registrar"))
            {
                if (controlDocente.Guardar(mdloDocente))
                {
                    MessageBox.Show("Registro guardado");
                }
                else {
                    MessageBox.Show("Error al guardar el registro");
                }
            }
            else if (opcion.Equals("Modificar"))
            {
                if (controlDocente.Actualizar(mdloDocente))
                {
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

        private void btn_Update_Click(object sender, EventArgs e)
        {

            int fila = vistaDocenteObj.lista.CurrentCell.RowIndex;
            Console.WriteLine("fila:" + fila);
            DataRow row = tablaAux.Rows[fila];
            Int32 valor = Convert.ToInt32(row["id_docentes"]);
            ControlVistaDocente.id = valor;
            ControlVistaDocente.nombre = row["nombre_docentes"].ToString();
            ControlVistaDocente.apellidos = row["apellidos"].ToString();
            ControlVistaDocente.numero_horas = Convert.ToInt32(row["numero_horas"]);
            ControlVistaDocente.estado = row["estado"].ToString();
            Console.WriteLine("evento creado opcion:" + ControlVistaDocente.opcion);
            ControlVistaDocente.opcion = "Modificar";
            //cargarValores(new agregardocentes(new FlowLayoutPanel(),0));
        }

        private void btn_Delete(object sender, EventArgs e)
        {
            int fila = vistaDocenteObj.lista.CurrentCell.RowIndex;
            DataRow row = tablaAux.Rows[fila];
            Int32 valor = Convert.ToInt32(row["id_docentes"]);
            if (controlDocente.Eliminar(valor))
            {
                rellenarTabla();
                MessageBox.Show("Registro eliminado");
            }
            else {
                MessageBox.Show("Error al eliminar el registro");
            }
        }

        private void rellenarTabla()
        {
            vistaDocenteObj.lista.DataSource = controlDocente.Consultar(vistaDocenteObj.txt_buscar.Text);
            tablaAux = controlDocente.RecuperarTablaAux();
        }
    }
}
