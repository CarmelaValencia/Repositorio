using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vista.Database;
using Vista.Modelos;

namespace Vista.ControladorDB
{
    class ControlDocente
    {
        DatabaseDocente databaseDocente = new DatabaseDocente();
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
        public DataTable Consultar(String buscar)
        {
            return databaseDocente.Consultar(buscar);
        }
    }
}
