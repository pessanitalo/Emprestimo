using Apache.NMS;
using Apache.NMS.ActiveMQ;
using AutoMapper;
using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;
using CredEmprestimoApi.Configurations;
using CredEmprestimoApi.Extensions;
using CredEmprestimoApi.ViewlModews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text.Json;

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
        private readonly ActiveMqSettingsConfig _settings;

        private readonly string _destinoBase;

        public ClienteController(IClienteService clienteService, IMapper mapper, IClienteRepository clienteRepository, IWebHostEnvironment env, IOptions<ActiveMqSettingsConfig> options)
        {
            _ClienteService = clienteService;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _settings = options.Value;
            _destinoBase = Path.Combine(env.ContentRootPath);
        }


        [HttpGet("fila")]
        public IActionResult Fila()
        {
            var factory = new ConnectionFactory(_settings.BrokerUri);
            using var connection = factory.CreateConnection();
            connection.Start();


            using var session = connection.CreateSession();
            IDestination destination = session.GetQueue("minha.fila");

            var pessoa = new Cliente
            {
                ClienteId = 1,
                Nome = "Ítalo",
                Idade = 30,
                Cpf = "23024189807",
                Score = 10,
                SaldoAtual = 1000
            };

            var json = JsonSerializer.Serialize(pessoa);


            using var producer = session.CreateProducer(destination);
            var message = session.CreateTextMessage(json);
            producer.Send(message);
            
            return Ok(json);

        }

        [HttpGet("consumer")]
        public IActionResult Consumer()
        {
            var factory = new ConnectionFactory(_settings.BrokerUri);
            using var connection = factory.CreateConnection();
            connection.Start();

            using var session = connection.CreateSession();
            IDestination destination = session.GetQueue("minha.fila");

            // Cria o consumidor
            using var consumer = session.CreateConsumer(destination);

            // Aguarda a mensagem (com timeout opcional)
            var receivedMessage = consumer.Receive(TimeSpan.FromSeconds(10)) as ITextMessage;
            var json = "";

            if (receivedMessage != null)
            {
                 json = receivedMessage.Text;
                 var pessoa = JsonSerializer.Deserialize<Cliente>(json);

            }
            else
            {
                Console.WriteLine("Nenhuma mensagem recebida.");
            }


            return Ok(json);

        }


        [HttpGet]
        [Route("ok")]
        public async Task<IActionResult> ok()
        {

            //var destino = Directory.GetCurrentDirectory() + "\\Uploads\\Images\\";
            //var date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //var log = "C:\\Logs\\";
            //var file = "log.txt";
            //var path = Path.Combine(log, file);

            //var texto = $"arquivo atualizado {date}\n";

            //// cria o diretorio
            //if (!Directory.Exists(log))
            //{
            //    Directory.CreateDirectory(log);

            //}
            //// cria o arquivo se não existir.
            //if (!System.IO.File.Exists(path))
            //{
            //    System.IO.File.WriteAllText(path, "");

            //}

            //System.IO.File.AppendAllText(path, texto);

            //var path = "C:\\Logs\\";
            //var folder = "\\Uploads";

            //var pasta = DateTime.Now.ToString("dd-MM-yyyy");
            //var logs = Path.Combine(path, folder, pasta);

            //if (!Directory.Exists(logs))
            //{
            //    Directory.CreateDirectory(logs);
            //}


            return Ok(_destinoBase);
        }


        [HttpGet]
        [Route("list")]
        private async Task<IActionResult> listagem([FromQuery] int pageSize, [FromQuery] int pageIndex, [FromQuery] string? cpf)
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
