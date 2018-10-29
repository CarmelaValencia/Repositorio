using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vista.Database;

namespace Vista.ControladorDB
{
    public class ControlGenerador
    {
        DatabaseGenerador databaseGenerador = new DatabaseGenerador();
        public String[] BuscarSiguienteGrupo()
        {
            return databaseGenerador.ObtenerSiguienteGrupo();
        }
        public int[] BuscarHoras(string turno) {
            return databaseGenerador.ObtenerHoras(turno);
        }
        public Boolean Guardar(String dia,int hora,int docente,int materia,int grupo) {
            return databaseGenerador.Guardar(dia, hora, docente, materia, grupo);
        }
        public int ObtenerMateria(int grupo,string dia)
        {
            return databaseGenerador.ObtenerMateria(grupo, dia);
        }

        public int ObtenerDocente(int materiaId, int grupo, string dia, int hora)
        {
            return databaseGenerador.ObtenerDocente(materiaId,grupo,dia,hora);
        }
    }
}
