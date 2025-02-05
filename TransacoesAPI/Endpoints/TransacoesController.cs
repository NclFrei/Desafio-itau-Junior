﻿using TransacoesAPI.Shared.Modelos.Entidades;
using TransacoesAPI.Shared.Modelos.Services;

namespace TransacoesAPI.Endpoints;

public static class TransacoesController
{
    public static void AddEndPointsTransacoes(this WebApplication app)
    {
        app.MapPost("/transacoes", async (Transacao transacao, TransacaoService service) =>
        {
            service.AdicionarTransacao(transacao);
            return Results.Ok("Transação processada com sucesso!");
        });
    }
}


