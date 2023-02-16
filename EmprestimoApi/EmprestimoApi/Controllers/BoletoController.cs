using CredEmprestimo.Business.Interface;
using CredEmprestimo.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CredEmprestimoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly IBoletoRepository _boletoRepository;

        public BoletoController(IBoletoRepository boletoRepository)
        {
            _boletoRepository = boletoRepository;
        }

        [HttpPost("gerarboleto/{id}")]
        public IActionResult GerarBoleto(int id)
        {
            var boleto = _boletoRepository.GerarBoleto(id);

            return Ok(boleto);
        }
    }
}
