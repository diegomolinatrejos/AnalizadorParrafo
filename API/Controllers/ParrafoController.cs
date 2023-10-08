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
        public Texto GetParrafos()
        {
            AnalizadorParrafo analizador = new AnalizadorParrafo();
            return analizador.resAnalizadorParrafo();
        }


        // Siguientes lineas son pruebas en cada fase
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
