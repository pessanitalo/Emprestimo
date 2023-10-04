using AutoMapper;
using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;
using CredEmprestimoApi.Extensions;
using CredEmprestimoApi.ViewlModews;
using Microsoft.AspNetCore.Mvc;

namespace CredEmprestimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _ClienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _ClienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("list/{cpf?}")]
        public async Task<IActionResult> filtro(string cpf, [FromQuery] PageParams pageParams)
        {
            try
            {
                if (!string.IsNullOrEmpty(cpf))
                {
                    var cliente = await _ClienteService.Busca(pageParams, cpf);
                    var retorno = _mapper.Map<PageList<ClienteViewModel>>(cliente);

                    pagination(cliente, retorno);
                    return Ok(cliente);
                }

                var clientes = await _ClienteService.ListaClientes(pageParams);

                var filtro = _mapper.Map<PageList<ClienteViewModel>>(clientes);
                pagination(clientes, filtro);

                return Ok(clientes);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Cliente>>("Falha interna no servidor"));
            }

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
        private void pagination<T,U>(PageList<T> clientes, PageList<U> filtro)
        {
            filtro.CurrentPage = clientes.CurrentPage;
            filtro.TotalPages = clientes.TotalPages;
            filtro.PageSize = clientes.PageSize;
            filtro.TotalCount = clientes.TotalCount;

            Response.AddPagination(filtro.CurrentPage, filtro.PageSize, filtro.TotalCount, filtro.TotalPages);
        }
    }
}
