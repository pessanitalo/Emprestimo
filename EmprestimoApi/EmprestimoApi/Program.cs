using AutoMapper;
using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Services;
using CredEmprestimo.Data.Context;
using CredEmprestimo.Data.Repository;
using CredEmprestimoApi.Configurations;
using CredEmprestimoApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<ActiveMqSettingsConfig>(
    builder.Configuration.GetSection("ActiveMq"));


builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
builder.Services.AddScoped<IEmprestimoService, EmprestimoService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IBoletoRepository, BoletoRepository>();
builder.Services.AddScoped<IClienteService, ClienteServices>();
builder.Services.AddScoped<IBoletoService, BoletoService>();
builder.Services.AddScoped<ISaqueRepository, SaqueRepository>();

var mappingConfig = new MapperConfiguration(c =>
{
    c.AddProfile(new AutomapperConfig());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//builder.Services.AddHostedService<JobAeach10Minutos>();

var app = builder.Build();

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
//    db.Database.Migrate();
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.MapControllers();

app.Run();