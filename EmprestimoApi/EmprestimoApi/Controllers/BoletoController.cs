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

        [HttpPost("pagarparcela")]
        public IActionResult PagarParcela([FromBody] PagarParcela pagarParcela)
        {
            try
            {
                var parcela = _boletoRepository.PagarUmaParcela(pagarParcela.Id, pagarParcela.numeroParcela);
                if (parcela == null) return NotFound(new ResultViewModel<BoletoEmprestimo>("Parcela não encontrada"));

                return Ok(parcela);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<List<PagarParcela>>("Falha interna no servidor"));
            }
        }

        [HttpGet("detalhesparcela/{id:int}")]
        public IActionResult VisualizarParcela(int id)
        {
            try
            {
                var parcelas = _boletoRepository.VisualizarParcela(id);
                return Ok(parcelas);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }

        }
    }
}
