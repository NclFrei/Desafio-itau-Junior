using System.Text.Json.Serialization;
using TransacoesAPI.Controller;
using TransacoesAPI.Endpoints;
using TransacoesAPI.Shared.Modelos.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TransacaoService>();
builder.Services.AddTransient<EstatisticasService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndPointsTransacoes();
app.AddEndPointsEstatisticas();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
