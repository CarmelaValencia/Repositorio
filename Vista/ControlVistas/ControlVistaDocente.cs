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
        public static String opcion = "";
        public static agregardocentes vistaAgregarObj = null;
        public static DataTable tablaAux = new DataTable();
        public static docentes vistaDocenteObj = null;
        public static ModeloDocente mdloDocente = null;
        static ControlDocente controlDocente = new ControlDocente();
        public void iniciarDocentes(docentes docentes)
        {
            vistaDocenteObj = docentes;
            rellenarTabla();
            vistaDocenteObj.btn_eliminar.Click += new EventHandler(btn_Delete);
            vistaDocenteObj.txt_buscar.TextChanged += new EventHandler(buscando);
        }
        
        public static void cargarValores(agregardocentes vistaAgregar)
        {
            vistaAgregarObj = vistaAgregar;
            vistaAgregar.btn_aceptar.Click += new EventHandler(btn_aceptar);
            vistaAgregar.btn_cancelar.Click += new EventHandler(btn_cancelar);
            if (opcion.Equals("Registrar"))
            {
                mdloDocente = new ModeloDocente(0,"","",0,"HABILITADO");
            }
            vistaAgregar.txt_nombre_docentes.Text = mdloDocente.Nombre_docentes;
            vistaAgregar.txt_apellidos.Text = mdloDocente.Apellidos;
            vistaAgregar.txt_numero_horas.Text = mdloDocente.Numero_horas.ToString();
            vistaAgregar.txt_estado.Text = mdloDocente.Estado;
        }
        
        public static void obtenerSeleccion()
        {
            int fila = vistaDocenteObj.lista.CurrentCell.RowIndex;
            DataRow row = ControlVistaDocente.tablaAux.Rows[fila];
            Int32 valor = Convert.ToInt32(row["id_docentes"]);
            mdloDocente = new ModeloDocente(valor, row["nombre_docentes"].ToString(), row["apellidos"].ToString(),
                Convert.ToInt32(row["numero_horas"]), row["estado"].ToString());
        }

        private static void btn_cancelar(object sender, EventArgs e)
        {
            
        }

        public static void btn_aceptar(object sender, EventArgs e)
        {
            String nombre = vistaAgregarObj.txt_nombre_docentes.Text;
            String apellidos = vistaAgregarObj.txt_apellidos.Text;
            int numero_horas = int.Parse(vistaAgregarObj.txt_numero_horas.Text);
            String estado = vistaAgregarObj.txt_estado.Text;
            mdloDocente = new ModeloDocente(mdloDocente.Id_docentes, nombre, apellidos, numero_horas, estado);
            if (ControlCamposVacios.detactarVacios(new String[] { nombre, apellidos, numero_horas + "", estado }) == 0)
            {
                if (opcion.Equals("Registrar"))
                {
                    if (controlDocente.Guardar(mdloDocente))
                    {
                        rellenarTabla();
                        MessageBox.Show("Registro guardado");
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el registro");
                    }
                }
                else if (opcion.Equals("Modificar"))
                {
                    if (controlDocente.Actualizar(mdloDocente))
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
        }

        private void buscando(object sender, EventArgs e)
        {
            rellenarTabla();
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

        private static void rellenarTabla()
        {
            vistaDocenteObj.lista.DataSource = controlDocente.Consultar(vistaDocenteObj.txt_buscar.Text);
            tablaAux = controlDocente.RecuperarTablaAux();
        }
    }
}
