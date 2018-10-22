using System;
using System.Data;
using System.Data.SQLite;
using Vista.Database;
using Vista.Modelos;

namespace Vista.ControladorDB
{
    class ControlHora
    {
        DatabaseHora databaseHora = new DatabaseHora();
        DataTable dataTable = null;
        public Boolean Guardar(ModeloHora modeloHora) {
            return databaseHora.Guardar(modeloHora);
        }
        public Boolean Actualizar(ModeloHora modeloHora) {
            return databaseHora.Actualizar(modeloHora);
        }
        public Boolean Eliminar(Int32 id)
        {
            return databaseHora.Eliminar(id);
        }
        public DataTable Consultar(String buscar) {
            DataTable dt = new DataTable();//DataTable que enviaremos a la vista sin mostrar el id de los docentes
            dt.Columns.Add("HORA DE INICIO"); dt.Columns.Add("HORA DE FIN"); dt.Columns.Add("TURNO");
            SQLiteDataAdapter da = databaseHora.Consultar(buscar);
            dataTable = new DataTable();
            da.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                dt.Rows.Add(row["inicio"], row["fin"], row["tipo"]);
            }
            return dt;
        }

        public DataTable RecuperarTablaAux()
        {
            return dataTable;
        }
    }
}
