using System;
using System.Collections.Generic;
using System.Data;
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
        public DataTable Consultar(String buscar) {
            return databaseMateria.Consultar(buscar);
        }
    }
}
