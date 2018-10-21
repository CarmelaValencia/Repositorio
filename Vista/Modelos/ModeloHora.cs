using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista.Modelos
{
    class ModeloHora
    {
        private String inicio;
        private String fin;
        private String tipo;
        public ModeloHora(string inicio, string fin, string tipo)
        {
            this.Inicio = inicio;
            this.Fin = fin;
            this.Tipo = tipo;
        }

        public string Inicio { get => inicio; set => inicio = value; }
        public string Fin { get => fin; set => fin = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
