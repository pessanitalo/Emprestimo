using CredEmprestimo.Business.Interface;
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


        [HttpPost("pagarparcela/{id}")]
        public IActionResult PagarParcela(int id, int numeroParcela)
        {
             _boletoRepository.PagarUmaParcela(id, numeroParcela);

            return Ok("Parcela paga com sucesso");
        }

        [HttpPost("boletovencido/{id}")]
        public IActionResult gerarBoletoVencido(int id)
        {
         var boleto =   _boletoRepository.PagarParcelaVencida(id);

            return Ok(boleto);
        }
    }
}
