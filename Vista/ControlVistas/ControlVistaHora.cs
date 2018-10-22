using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.ControladorDB;
using Vista.Modelos;
using Vista.Vistas;

namespace Vista.ControlVistas
{
    public class ControlVistaHora
    {
        public static String opcion = "";
        public static agregarhorario vistaAgregarObj = null;
        public static DataTable tablaAux = new DataTable();
        public static horario vistaHorarioObj = null;
        public static ModeloHora mdloHora = null;
        static ControlHora controlHora = new ControlHora();
        public void iniciarHoras(horario horas) {
            vistaHorarioObj = horas;
            rellenarTabla();
            vistaHorarioObj.btn_eliminar.Click += new EventHandler(btn_Delete);
            vistaHorarioObj.txt_buscar.TextChanged += new EventHandler(buscando);
            ControlCamposVacios.soloLetrasTxtBox(vistaHorarioObj.txt_buscar);
        }
        public static void cargarValores(agregarhorario vistaAgregar)
        {
            vistaAgregarObj = vistaAgregar;
            vistaAgregar.btn_aceptar.Click += new EventHandler(btn_aceptar);
            vistaAgregar.btn_cancelar.Click += new EventHandler(btn_cancelar);
            ControlCamposVacios.soloLetrasTxtBox(vistaAgregarObj.txt_apellidos);
            ControlCamposVacios.soloLetrasTxtBox(vistaAgregarObj.txt_nombre_docentes);
            if (opcion.Equals("Registrar"))
            {
                mdloHora = new ModeloHora(0, "", "","MATUTINO");
            }
            vistaAgregar.txt_nombre_docentes.Text = mdloHora.Inicio;
            vistaAgregar.txt_apellidos.Text = mdloHora.Fin;
            vistaAgregar.txt_turno.Text = mdloHora.Tipo;
        }
        public static void obtenerSeleccion()
        {
            int fila = vistaHorarioObj.lista.CurrentCell.RowIndex;
            DataRow row = ControlVistaHora.tablaAux.Rows[fila];
            Int32 valor = Convert.ToInt32(row["id_horas"]);
            mdloHora = new ModeloHora(valor, row["inicio"].ToString(), row["fin"].ToString(), row["tipo"].ToString());
        }
        private static void btn_cancelar(object sender, EventArgs e)
        {
            
        }

        private static void btn_aceptar(object sender, EventArgs e)
        {
            String inicio = vistaAgregarObj.txt_nombre_docentes.Text;
            String fin = vistaAgregarObj.txt_apellidos.Text;
            String turno = vistaAgregarObj.txt_turno.Text;
            mdloHora = new ModeloHora(mdloHora.IdHoras, inicio, fin,turno);
            Console.Write("opcion:" + opcion);
            if (opcion.Equals("Registrar"))
            {
                Console.Write("opcion:"+opcion);
                if (controlHora.Guardar(mdloHora))
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
                if (controlHora.Actualizar(mdloHora))
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
            int fila = vistaHorarioObj.lista.CurrentCell.RowIndex;
            DataRow row = tablaAux.Rows[fila];
            Int32 valor = Convert.ToInt32(row["id_horas"]);
            if (controlHora.Eliminar(valor))
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
            vistaHorarioObj.lista.DataSource = controlHora.Consultar(vistaHorarioObj.txt_buscar.Text);
            tablaAux = controlHora.RecuperarTablaAux();
        }
    }
}
