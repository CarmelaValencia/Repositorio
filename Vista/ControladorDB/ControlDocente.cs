using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Database;
using Vista.Modelos;

namespace Vista.ControladorDB
{
    class ControlDocente
    {
        DatabaseDocente databaseDocente = new DatabaseDocente();
        DataTable TablaAux = null;
        public Boolean Guardar(ModeloDocente modeloDocente)
        {
            return databaseDocente.Guardar(modeloDocente);
        }
        public Boolean Actualizar(ModeloDocente modeloDocente)
        {
            return databaseDocente.Actualizar(modeloDocente);
        }
        public Boolean Eliminar(int id)
        {
            return databaseDocente.Eliminar(id);
        }

        public DataTable RecuperarTablaAux() {
            return TablaAux;
        }
        public DataTable Consultar(String buscar)
        {
            //DataTable dtAux = new DataTable();//DataTable que serviremos para recuperar el id de los docentes
            DataTable dt = new DataTable();//DataTable que enviaremos a la vista sin mostrar el id de los docentes
            dt.Columns.Add("NOMBRE"); dt.Columns.Add("APELLIDOS"); dt.Columns.Add("NÚMERO DE HORAS");
            dt.Columns.Add("ESTADO");
            SQLiteDataAdapter da= databaseDocente.Consultar(buscar);
            TablaAux = new DataTable();
            //da.Fill(TablaAux);
            for (int i = 0; i < TablaAux.Rows.Count; i++)
            {
                DataRow row = TablaAux.Rows[i];
                dt.Rows.Add(row["nombre_docentes"],row["apellidos"],row["numero_horas"],row["estado"]);
            }
            return dt;
        }
    }
}
