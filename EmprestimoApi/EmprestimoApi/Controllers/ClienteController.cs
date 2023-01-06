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

        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ClienteController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("filtro/{nome?}")]
        public async Task<IEnumerable<Cliente>> filtro(string? nome)
        {

            if (!string.IsNullOrEmpty(nome))
            {
                return await _repository.filtroPorNome(nome);
            }

            return await _repository.ListaClientes();

        }

        [HttpGet]
        [Route("getId/{id}")]
        public Cliente get(int id)
        {
            var consulta = _repository.BuscarPorId(id);

            return consulta;
        }

        [HttpPost]
        public IActionResult create(ClienteViewModel clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            var result = _repository.Create(cliente);

            return Ok(result);
        }
    }
}
