using System;

namespace Vista.Modelos
{
    public class ModeloHora
    {
        private int idHoras;
        private String inicio;
        private String fin;
        private String tipo;
        public ModeloHora(int idHoras,string inicio, string fin, string tipo)
        {
            this.idHoras = idHoras;
            this.Inicio = inicio;
            this.Fin = fin;
            this.Tipo = tipo;
        }

        public string Inicio { get => inicio; set => inicio = value; }
        public string Fin { get => fin; set => fin = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int IdHoras { get => idHoras; set => idHoras = value; }
    }
}
