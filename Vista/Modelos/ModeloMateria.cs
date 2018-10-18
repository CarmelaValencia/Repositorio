using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloMateria
    {
        private int idMateria;
        private string nombreMateria;
        private int total_horas;
        private int horas_semana;
        private string ciclo;

        public ModeloMateria(int idMateria, string nombreMateria, int total_horas, int horas_semana, string ciclo)
        {
            this.idMateria = idMateria;
            this.nombreMateria = nombreMateria;
            this.total_horas = total_horas;
            this.horas_semana = horas_semana;
            this.ciclo = ciclo;
        }

        public string NombreMateria { get => nombreMateria; set => nombreMateria = value; }
        public int IdMateria { get => idMateria; set => idMateria = value; }
        public int Total_horas { get => total_horas; set => total_horas = value; }
        public int Horas_semana { get => horas_semana; set => horas_semana = value; }
        public string Ciclo { get => ciclo; set => ciclo = value; }
        
    }
}
