using System.Runtime.CompilerServices;

namespace DTO.Models
{
    public class Texto
    {
        public string parentRow { get; set; }
        public List<Parrafo> paragraphsList { get; set; }

    }

    public class Parrafo
    {
        public string paragraphValue { get; set; }

    }

    public class AnalisisResultado
    {
        public List<string> PalabrasConD { get; set; }
        public double PromedioPalabras { get; set; }
        public string ParrafoMasLargo { get; set; }
        public string ParrafoMasCorto { get; set; }
        public List<string> ListaDeParrafos { get; set; }
    }
}
