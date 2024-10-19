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
        //docker http://localhost:8080/swagger/index.html
        private readonly IClienteService _ClienteService;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper, IClienteRepository clienteRepository)
        {
            _ClienteService = clienteService;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ok")]
        public async Task<IActionResult> ok()
        {
            return Ok("OK");
        }


        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> listagem([FromQuery] int pageSize, [FromQuery] int pageIndex, [FromQuery] string? cpf)
        {
            var list = await _ClienteService.ListaCliente(pageSize, pageIndex, cpf);
            return Ok(list);
        }

        [HttpGet]
        [Route("paginacao")]
        public async Task<IActionResult> Pagicacao([FromQuery] PageParams pageParams, [FromQuery] string? cpf)
        {
            var list = await _ClienteService.Paginacao(pageParams, cpf);
            Response.AddPagination(list.CurrentPage, list.PageSize, list.TotalCount, list.TotalPages);
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
            var response = new
            {
                mensagem = "Cliente cadastrado com sucesso."
            };

            return Ok(response);
        }
    }
}
