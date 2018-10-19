using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vista.Database;
using Vista.Modelos;

namespace Vista.ControladorDB
{
    public class ControlGrupo
    {
        DatabaseGrupo databaseGrupo = new DatabaseGrupo();
        DataTable TablaAux = null;
        public Boolean Guardar(ModeloGrupo modeloGrupo)
        {
            return databaseGrupo.Guardar(modeloGrupo);
        }
        public Boolean Actualizar(ModeloGrupo modeloGrupo)
        {
            return databaseGrupo.Actualizar(modeloGrupo);
        }
        public Boolean Eliminar(int id)
        {
            return databaseGrupo.Eliminar(id);
        }
        public DataTable RecuperarTablaAux()
        {
            return TablaAux;
        }
        public DataTable Consultar(String buscar)
        {
            DataTable dt = new DataTable();//DataTable que enviaremos a la vista sin mostrar el id de los docentes
            dt.Columns.Add("SEMESTRE"); dt.Columns.Add("GRUPO"); dt.Columns.Add("AREA");
            dt.Columns.Add("ESTADO");
            SQLiteDataAdapter da = databaseGrupo.Consultar(buscar);
            TablaAux = new DataTable();
            da.Fill(TablaAux);
            for (int i = 0; i < TablaAux.Rows.Count; i++)
            {
                DataRow row = TablaAux.Rows[i];
                dt.Rows.Add(row["semestre"], row["nombre_grupos"], row["area"], row["estado"]);
            }
            return dt;
        }
    }
}
