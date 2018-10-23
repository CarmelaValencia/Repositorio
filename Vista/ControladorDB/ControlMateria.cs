using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Modelo;

namespace Controlador
{
    class ControlMateria
    {
        DatabaseMateria databaseMateria = new DatabaseMateria();
        DataTable TablaAux = null;
        public Boolean Guardar(ModeloMateria modeloMateria) {
            return databaseMateria.Guardar(modeloMateria);
        }
        public Boolean Actualizar(ModeloMateria modeloMateria)
        {
            return databaseMateria.Actualizar(modeloMateria);
        }
        public Boolean Eliminar(int id)
        {
            return databaseMateria.Eliminar(id);
        }
        public DataTable RecuperarTablaAux()
        {
            return TablaAux;
        }
        public DataTable Consultar(String buscar)
        {
            DataTable dt = new DataTable();//DataTable que enviaremos a la vista sin mostrar el id de los docentes
            dt.Columns.Add("NOMBRE"); dt.Columns.Add("HORAS TOTALES"); dt.Columns.Add("HORAS A LA SEMANA");
            dt.Columns.Add("CICLO ESCOLAR");
            SQLiteDataAdapter da = databaseMateria.Consultar(buscar);
            TablaAux = new DataTable();
            da.Fill(TablaAux);
            for (int i = 0; i < TablaAux.Rows.Count; i++)
            {
                DataRow row = TablaAux.Rows[i];
                dt.Rows.Add(row["nombre_materias"], row["total_horas"], row["horas_semana"], row["ciclo"]);
            }
            return dt;
        }

        public void DesAsignarMaterias(int idSeleccionado, int materia, int docente)
        {
            databaseMateria.DesAsignarMaterias(idSeleccionado, materia, docente);
        }

        public void asignarMaterias(int idSeleccionado, int materia, int docente)
        {
            databaseMateria.AsignarMaterias(idSeleccionado,materia,docente);
        }

        public DataTable ListarMaterias(int idGrupo,int idDocente)
        {
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter da = databaseMateria.ListarMaterias(idGrupo,idDocente);
            da.Fill(dataTable);
            return dataTable;
        }
    }
}
