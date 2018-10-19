using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista.Modelos
{
    public class ModeloGrupo
    {
        private int id_grupos;
        private int semestre;
        private String nombre_grupos;
        private String area;
        private String estado;

        public ModeloGrupo(int id_grupos,int semestre, string nombre_grupos, string area, string estado)
        {
            this.Id_grupos = id_grupos;
            this.Area = area;
            this.Semestre = semestre;
            this.Nombre_grupos = nombre_grupos;
            this.Estado = estado;
        }

        public int Id_grupos { get => id_grupos; set => id_grupos = value; }
        public string Area { get => area; set => area = value; }
        public int Semestre { get => semestre; set => semestre = value; }
        public string Nombre_grupos { get => nombre_grupos; set => nombre_grupos = value; }
        public string Estado { get => estado; set => estado = value; }

    }
}
