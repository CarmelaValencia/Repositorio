using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista.Modelos
{
    class ModeloDocente
    {
        private int id_docentes;
        private String nombre_docentes;
        private String apellidos;
        private int numero_horas;
        private String estado;

        public ModeloDocente(int id_docentes, string nombre_docentes, string apellidos, int numero_horas, string estado)
        {
            this.id_docentes = id_docentes;
            this.nombre_docentes = nombre_docentes;
            this.apellidos = apellidos;
            this.numero_horas = numero_horas;
            this.estado = estado;
        }

        public int Id_docentes { get => id_docentes; set => id_docentes = value; }
        public string Nombre_docentes { get => nombre_docentes; set => nombre_docentes = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Numero_horas { get => numero_horas; set => numero_horas = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
