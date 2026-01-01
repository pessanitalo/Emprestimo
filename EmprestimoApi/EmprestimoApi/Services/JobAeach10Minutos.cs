using Microsoft.EntityFrameworkCore.Metadata;

namespace CredEmprestimoApi.Services
{
    public class JobAeach10Minutos : BackgroundService
    {
        private readonly ILogger<JobAeach10Minutos> _logger;
        private readonly string _destinoBase;
        private readonly IWebHostEnvironment _env;

        public JobAeach10Minutos(ILogger<JobAeach10Minutos> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _destinoBase = Path.Combine(env.ContentRootPath, "uploads");
            _env = env;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
     
                try
                {
                    Console.WriteLine($"Caminho Env. {_env}");

                    var pasta = DateTime.Now.ToString("dd-MM-yyyy");
                    var url = Path.Combine(_destinoBase, pasta);
                    var logs = Path.Combine("C:\\Logs\\", pasta);

                    Directory.CreateDirectory(_destinoBase);
                    Directory.CreateDirectory(url);
                    Directory.CreateDirectory(logs);

                    await Processar(url,logs);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro durante a execução do job");
                }

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }

        private Task Processar(string pastaDestino,string logs)
        {
            Console.WriteLine($"Executando tarefa e salvando em {pastaDestino}");
            Console.WriteLine($"Caminho do log {logs}");
            return Task.CompletedTask;
        }
    }
}
