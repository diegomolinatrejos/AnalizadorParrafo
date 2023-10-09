using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO.Models;
using AppLogic;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ParrafoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAnalisisParrafos()
        {
            AnalizadorParrafo analizador = new AnalizadorParrafo();
            var resultado = await analizador.ResAnalizadorParrafo();

            return new JsonResult(resultado);
        }


        // Siguientes lineas de codigo fueron para probar la integracion de las capas de la solución 
        [HttpGet]
        public ActionResult<Texto> GetPrueba() //  Metodo de ejemplo para probar la forma de exponer datos.
        {
            AnalizadorParrafo analizador = new AnalizadorParrafo();
            return new JsonResult(analizador.resultado());

        }

        [HttpGet]
        public Texto GetTexto() //  Metodo de ejemplo para probar la forma de exponer datos.
        {
            AnalizadorParrafo analizador = new AnalizadorParrafo();
            return analizador.resultado();
        }

    }// fin de la clase ParrafoController 

}// fin del namespace
