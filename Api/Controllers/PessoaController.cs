using Microsoft.AspNetCore.Mvc;

namespace ServicoRH.Api.Controllers
{
    [ApiController]
    [Route("Pessoa")]
    public class PessoaController
    {
        [HttpGet]
        [Route("VerificarIdade")]
        public string VerificarIdade(int idade)
        {
            if (idade >= 18)
            {
                return "Você é maior de idade";
            }
            else
            {
                return "Você é menor de idade";
            }

        }

    }
}
