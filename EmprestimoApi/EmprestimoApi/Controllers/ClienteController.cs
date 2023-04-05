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
        [Route("filtro/{nome?}")]
        public async Task<IEnumerable<Cliente>> filtro(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                return await _ClienteRepository.filtroPorNome(nome);
            }

            return await _ClienteRepository.ListaClientes();

        }

        [HttpGet]
        [Route("getId/{id:int}")]
        public IActionResult get(int id)
        {
            try
            {
                var consulta = _ClienteRepository.DetalhesCliente(id);

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

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
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
