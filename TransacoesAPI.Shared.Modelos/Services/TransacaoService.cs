using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacoesAPI.Shared.Modelos.Entidades;

namespace TransacoesAPI.Shared.Modelos.Services;

public class TransacaoService
{
    private readonly ILogger<TransacaoService> _logger;
    public virtual List<Transacao> Trancacoes { get; set; } = new List<Transacao>();

    public IActionResult AdicionarTransacao(Transacao transacao)
    {
        _logger.LogInformation("Iniciando uma transação de Valor: {Valor}, Data: {datahora}", transacao.valor, transacao.dataHora);

        if (transacao.dataHora > DateTime.UtcNow)
        {
            _logger.LogWarning("Transação rejeitada: Data futura - {DataHora}", transacao.dataHora);
            return new StatusCodeResult(422);
        }

        else if (transacao.valor < 0)
        {
            _logger.LogWarning("Transação rejeitada: Valor: {Valor} é um valor negativo", transacao.valor);
            return new StatusCodeResult(422);
        }

        _logger.LogInformation("Transação feita com sucesso");
        Trancacoes.Add(transacao);

        return new StatusCodeResult(201);
    }

    public void LimparTransacoes()
    {
        Trancacoes.Clear();
    }

    public List<Transacao> BuscarTransacoes(int intervaloBusca)
    {
        DateTimeOffset dataHoraIntervalo = DateTimeOffset.Now.AddSeconds(-intervaloBusca);

        return Trancacoes.Where(transacao => transacao.dataHora > dataHoraIntervalo).ToList();
    }
}

