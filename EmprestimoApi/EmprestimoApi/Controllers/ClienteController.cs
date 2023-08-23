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

        private readonly IClienteRepository _ClienteRepository;
        private readonly IClienteService _ClienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IClienteService clienteService, IMapper mapper)
        {
            _ClienteRepository = clienteRepository;
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
                    var cliente = await _ClienteRepository.Busca(pageParams, cpf);

                    var retorno = _mapper.Map<PageList<ClienteViewModel>>(cliente);

                    pagination(cliente, retorno);
                    return Ok(cliente);
                }

                var clientes = await _ClienteService.ListaClientes(pageParams);

                var filtro = _mapper.Map<PageList<ClienteViewModel>>(clientes);

                pagination(clientes, filtro);

                return Ok(clientes);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }

        }

        [HttpGet]
        [Route("filtrar/{cpf}")]
        public async Task<IActionResult> pesquisarPorCpf(string cpf)
        {
            try
            {
                var cliente = await _ClienteRepository.BuscaCpf(cpf);

                if (cliente == null) return NotFound(new ResultViewModel<Cliente>("Cliente não encontrado"));

                return Ok(cliente);

            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }

        [HttpGet]
        [Route("getId/{id:int}")]
        public IActionResult get(int id)
        {
            try
            {
                var consulta = _ClienteRepository.DetalhesCliente(id);

                if (consulta == null) return NotFound(new ResultViewModel<Cliente>("Cliente não encontrado"));

                return Ok(consulta);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }

        [HttpPost]
        public IActionResult create(ClienteViewModel clienteDto)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDto);
                var result = _ClienteRepository.Create(cliente);

                return Ok(result);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }
        private void pagination(PageList<Cliente> clientes, PageList<ClienteViewModel> filtro)
        {
            filtro.CurrentPage = clientes.CurrentPage;
            filtro.TotalPages = clientes.TotalPages;
            filtro.PageSize = clientes.PageSize;
            filtro.TotalCount = clientes.TotalCount;

            Response.AddPagination(filtro.CurrentPage, filtro.PageSize, filtro.TotalCount, filtro.TotalPages);
        }
    }
}
