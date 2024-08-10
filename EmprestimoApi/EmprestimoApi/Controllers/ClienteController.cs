using AutoMapper;
using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;
using CredEmprestimo.Data.Context;
using CredEmprestimoApi.Extensions;
using CredEmprestimoApi.ViewlModews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CredEmprestimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _ClienteService;
        private readonly DataContext _contex;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper, DataContext contex)
        {
            _ClienteService = clienteService;
            _contex = contex;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> filtro()
        {
            var list = await _contex.Clientes.ToListAsync();
            return Ok(list);
        }

        [HttpGet]
        [Route("getId/{id:int}")]
        public IActionResult get(int id)
        {
            try
            {
                var consulta = _ClienteService.DetalhesCliente(id);
                if (consulta == null) return NotFound(new ResultViewModel<Cliente>("Cliente não encontrado"));
                return Ok(consulta);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Cliente>>("Falha interna no servidor"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> create(ClienteViewModel clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            if (await _ClienteService.validar(cliente)) return BadRequest("Já existe um usuário com esse cpf!");
            var retorno = _ClienteService.Create(cliente);
            return Ok(retorno);
        }
        private void pagination<T, U>(PageList<T> clientes, PageList<U> filtro)
        {
            filtro.CurrentPage = clientes.CurrentPage;
            filtro.TotalPages = clientes.TotalPages;
            filtro.PageSize = clientes.PageSize;
            filtro.TotalCount = clientes.TotalCount;

            Response.AddPagination(filtro.CurrentPage, filtro.PageSize, filtro.TotalCount, filtro.TotalPages);
        }
    }
}
