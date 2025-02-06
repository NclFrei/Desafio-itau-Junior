using Microsoft.AspNetCore.Mvc;
using TransacoesAPI.Shared.Modelos.Entidades;
using TransacoesAPI.Shared.Modelos.Services;

namespace TransacoesAPI.Controller;

public static class EstatisticasController
{
    public static void AddEndPointsEstatisticas(this WebApplication app)
    {
        app.MapGet("/estatistica", (int intervaloBusca, [FromServices] EstatisticasService service, [FromServices] TransacaoService transacaoService) =>
        {
            var estatisticas = service.CalcularEstatisticasTransacoes(intervaloBusca, transacaoService);
            return Results.Ok(estatisticas);
        });

    }
}

