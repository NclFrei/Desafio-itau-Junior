using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacoesAPI.Shared.Modelos.Entidades;

namespace TransacoesAPI.Shared.Modelos.Services;

public class EstatisticasService
{
    public virtual TransacaoService transacaoService { get; set; }

    public Estatisticas CalcularEstatisticasTransacoes(int intervaloBusca)
    {
        List<Transacao> transacoes = transacaoService.BuscarTransacoes(intervaloBusca);

        if (!transacoes.Any())
        {
            return new Estatisticas { count = 0, sum = 0, avg = 0, min = 0, max = 0 };
        }

        return new Estatisticas
        {
            count = transacoes.Count,
            sum = transacoes.Sum(t => t.valor),
            avg = transacoes.Average(t => t.valor),
            min = transacoes.Any() ? transacoes.Min(t => t.valor) : 0,
            max = transacoes.Any() ? transacoes.Max(t => t.valor) : 0
        };
    }
}
