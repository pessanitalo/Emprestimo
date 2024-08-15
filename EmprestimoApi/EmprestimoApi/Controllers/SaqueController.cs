using CredEmprestimo.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CredEmprestimoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaqueController : ControllerBase
    {
        private readonly ISaqueRepository _saqueRepository;

        public SaqueController(ISaqueRepository saqueRepository)
        {
            _saqueRepository = saqueRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var saques = await _saqueRepository.GetAllSaque();
            return Ok(saques);
        }
    }
}
