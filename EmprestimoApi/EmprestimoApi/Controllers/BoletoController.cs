using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
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

        [HttpPost("gerarboleto/{id:int}")]
        public IActionResult GerarBoleto(int id)
        {

            try
            {
                var boleto = _boletoRepository.GerarBoleto(id);
                if (boleto == null) return NotFound(new ResultViewModel<BoletoEmprestimo>("Emprestimo não encontrado"));

                return Ok(boleto);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }


        [HttpPost("pagarparcela/{id:int}")]
        public IActionResult PagarParcela(int id, int numeroParcela)
        {
            try
            {
                var parcela = _boletoRepository.PagarUmaParcela(id, numeroParcela);
                if (parcela == null) return NotFound(new ResultViewModel<BoletoEmprestimo>("Parcela não encontrada"));

                return Ok(parcela);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }

        [HttpPost("boletovencido/{id:int}")]
        public IActionResult gerarBoletoVencido(int id)
        {
            try
            {
                var boleto = _boletoRepository.geralBoletoVencido(id);
                if (boleto == false) return NotFound(new ResultViewModel<BoletoEmprestimo>("Parcela não encontrada"));

                return Ok("Parcela gerada com sucesso.");
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }

        }
    }
}
