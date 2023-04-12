using AutoMapper;
using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimoApi.ViewlModews;
using Microsoft.AspNetCore.Mvc;

namespace CredEmprestimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepository _ClienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository repository, IMapper mapper)
        {
            _ClienteRepository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> listarClientes()
        {
            try
            {
                var clientes = await _ClienteRepository.ListaClientes();
                return Ok(clientes);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }

        }

        [HttpGet]
        [Route("buscaCpf/{cpf}")]
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
    }
}
