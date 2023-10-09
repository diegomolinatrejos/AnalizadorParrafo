using DTO.Models;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;
using System.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace AppLogic
{
    public class AnalizadorParrafo
    {
        public async Task<AnalisisResultado> ResAnalizadorParrafo()
        {
            var resultado = new AnalisisResultado();

            var urlBaseParrafos = "https://wiki-reader-lab.azurewebsites.net";
            var urlMetodo = "/api/Text/GetAllText";
            var urlFinal = urlBaseParrafos + urlMetodo;

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(urlFinal);

                // Deserializar el objeto respuesta 
                var texto = JsonConvert.DeserializeObject<Texto>(response);

                // Lista de palabras que comienzan con 'D' o 'd'
                resultado.PalabrasConD = texto.paragraphsList
                    .SelectMany(p => p.paragraphValue.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries))
                    .Where(word => Regex.IsMatch(word, @"^[Dd]"))
                    .ToList();

                // Promedio de palabras en los párrafos
                resultado.PromedioPalabras = texto.paragraphsList
                    .Average(p => p.paragraphValue.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length);

                // Párrafo con más palabras
                resultado.ParrafoMasLargo = texto.paragraphsList
                    .OrderByDescending(p => p.paragraphValue.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length)
                    .FirstOrDefault()?.paragraphValue;

                // Párrafo con menos palabras
                resultado.ParrafoMasCorto = texto.paragraphsList
                    .OrderBy(p => p.paragraphValue.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length)
                    .FirstOrDefault()?.paragraphValue;

                // Lista de párrafos obtenidos a trabajar
                resultado.ListaDeParrafos = texto.paragraphsList.Select(p => p.paragraphValue).ToList();

            }

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