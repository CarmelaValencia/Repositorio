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
    public class ControlVistaGrupo
    {
        public static String opcion = "";
        public static agregargrupos vistaAgregarObj = null;
        public static DataTable tablaAux = new DataTable();
        public static grupos vistaGrupoObj = null;
        public static ModeloGrupo mdloGrupo = null;
        static ControlGrupo controlGrupo = new ControlGrupo();
        public void iniciarGrupos(grupos grupos)
        {
            vistaGrupoObj = grupos;
            rellenarTabla();
            vistaGrupoObj.btn_eliminar.Click += new EventHandler(btn_Delete);
            vistaGrupoObj.txt_buscar.TextChanged += new EventHandler(buscando);
            ControlCamposVacios.soloLetrasTxtBox(vistaGrupoObj.txt_buscar);
        }

        public static void cargarValores(agregargrupos vistaAgregar)
        {
            vistaAgregarObj = vistaAgregar;
            vistaAgregar.btn_aceptar.Click += new EventHandler(btn_aceptar);
            vistaAgregar.btn_cancelar.Click += new EventHandler(btn_cancelar);
            ControlCamposVacios.soloLetrasTxtBox(vistaAgregarObj.txt_area);
            ControlCamposVacios.soloLetrasTxtBox(vistaAgregarObj.txt_nombre_grupos);
            if (opcion.Equals("Registrar"))
            {
                mdloGrupo = new ModeloGrupo(0, 0, "", "", "HABILITADO");
            }
            vistaAgregar.txt_nombre_grupos.Text = mdloGrupo.Nombre_grupos;
            vistaAgregar.txt_semestre.Text = mdloGrupo.Semestre.ToString();
            vistaAgregar.txt_area.Text = mdloGrupo.Area;
            vistaAgregar.txt_estado.Text = mdloGrupo.Estado;
        }

        public static void obtenerSeleccion()
        {
            int fila = vistaGrupoObj.lista.CurrentCell.RowIndex;
            DataRow row = ControlVistaGrupo.tablaAux.Rows[fila];
            Int32 valor = Convert.ToInt32(row["id_grupos"]);
            Console.WriteLine("id recuperado:" + valor);
            mdloGrupo = new ModeloGrupo(valor, Convert.ToInt32(row["semestre"]), row["nombre_grupos"].ToString(),
                row["area"].ToString(), row["estado"].ToString());
        }

        private static void btn_cancelar(object sender, EventArgs e)
        {

        }

        public static void btn_aceptar(object sender, EventArgs e)
        {
            String nombre = vistaAgregarObj.txt_nombre_grupos.Text;
            Int32 semestre = int.Parse(vistaAgregarObj.txt_semestre.Text);
            String area = vistaAgregarObj.txt_area.Text;
            String estado = vistaAgregarObj.txt_estado.Text;
            Console.WriteLine("id rgupo:"+mdloGrupo.Id_grupos);
            mdloGrupo = new ModeloGrupo(mdloGrupo.Id_grupos, semestre, nombre, area, estado);
            if (ControlCamposVacios.detactarVacios(new String[] { nombre, semestre+"",
                area, estado }) == 0)
            {
                if (opcion.Equals("Registrar"))
                {
                    if (controlGrupo.Guardar(mdloGrupo))
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
                    if (controlGrupo.Actualizar(mdloGrupo))
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
            int fila = vistaGrupoObj.lista.CurrentCell.RowIndex;
            DataRow row = tablaAux.Rows[fila];
            Int32 valor = Convert.ToInt32(row["id_grupos"]);
            if (controlGrupo.Eliminar(valor))
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
            vistaGrupoObj.lista.DataSource = controlGrupo.Consultar(vistaGrupoObj.txt_buscar.Text);
            tablaAux = controlGrupo.RecuperarTablaAux();
        }
    }
}
