using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using scb_externo.Controllers.cartaoDeCredito;
using scb_externo.Controllers.cobranca;
using scb_externo.Controllers.email;
using scb_externo.Data;
using scb_externo.Data.Dto;
using scb_externo.Extensions;
using scb_externo.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/* database */
var con = builder.Configuration.GetConnectionString("ExternoConnection");
builder.Services.AddDbContext<ExternoContext>(options => options.UseNpgsql(con));

/* automapper */
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
    mc.AddGlobalIgnore("StatusCobranca");
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddMvc();

/* DIs */
builder.Services.AddTransient<MailTrapAPI>();
builder.Services.AddTransient<CieloAPI>();
builder.Services.AddTransient<StripeAPI>();
builder.Services.AddTransient<AluguelAPI>();

builder.Services.AddTransient<Solicitacao>();
builder.Services.AddTransient<SolicitacaoEmail>();
builder.Services.AddTransient<SolicitacaoCobranca>();
builder.Services.AddTransient<SolicitacaoCartaoDeCredito>();

builder.Services.AddTransient<ObjetoSalvavel>();
builder.Services.AddTransient<CobrancaDto>();

builder.Services.AddTransient<Valida>();
builder.Services.AddTransient<Envia>();
builder.Services.AddTransient<Cobra>();


builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SCB Externo APIs" });
    c.DocumentFilter<GroupDocumentFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
