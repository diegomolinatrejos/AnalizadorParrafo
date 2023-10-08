using DTO.Models;
using System.Text.Json.Serialization;

namespace AppLogic
{
    public class AnalizadorParrafo
    {
        public Texto resAnalizadorParrafo() 
        {
            var resultado = new Texto();

            var urlBaseParrafos = "https://wiki-reader-lab.azurewebsites.net";
            var urlMetodo = "/api/Text/GetAllText";
            var urlFinal = urlBaseParrafos + urlMetodo;

            var client = new HttpClient();
            client.BaseAddress = new Uri(urlFinal);

            //llamada a la API externa que retornara 
            var textoResultado = client.GetAsync(urlFinal).Result;

            var objetoJson = textoResultado.Content.ReadAsStringAsync().Result;            

            return resultado;
        }

        public Texto resultado() // solo para probar 
        {
            // Instancia de Texto con los datos deseados
            var texto = new Texto
            {
                parentRow = "Linea Base",
                paragraphsList = new List<Parrafo>
                {
                    new Parrafo { paragraphValue = "parrafo 1" },
                    new Parrafo { paragraphValue = "parrafo 2" }
                }
            };
            return texto;
        }

    }// fin de la clase
}// fin del namespace