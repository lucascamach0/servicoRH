using Microsoft.AspNetCore.Mvc;

namespace ServicoRH.Api.Controllers
{
    [ApiController]
    [Route("Calculadora")]
    public class PrimeiroTesteApiController
    {
        [HttpGet]
        [Route("Somar")]
        public double RealizarSoma(double valor1, double valor2)
        {
            return valor1 + valor2;
        }
    }
}
