﻿using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace CredEmprestimoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {

        private readonly IBoletoService _boletoService;

        public BoletoController(IBoletoService boletoService)
        {
            _boletoService = boletoService;
        }

        [HttpPost("pagarparcela")]
        public IActionResult PagarParcela([FromBody] PagarParcela pagarParcela)
        {
            try
            {
                if (_boletoService.ValidarSaldo(pagarParcela.ClienteId)) return BadRequest("Saldo Insuficiente");
                
                var parcela = _boletoService.PagarUmaParcela(pagarParcela.Id, pagarParcela.numeroParcela);
                return Ok(parcela);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<PagarParcela>>("Falha interna no servidor"));
            }
        }

        [HttpGet("detalhesparcela/{id:int}")]
        public async Task<IActionResult> VisualizarParcela(int id)
        {
            try
            {
                var parcelas = await _boletoService.VisualizarParcela(id);
                return Ok(parcelas);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }

        }
    }
}
