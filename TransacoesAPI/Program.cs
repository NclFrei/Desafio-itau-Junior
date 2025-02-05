using System.Text.Json.Serialization;
using TransacoesAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndPointsTransacoes();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
