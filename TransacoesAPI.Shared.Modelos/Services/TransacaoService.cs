using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacoesAPI.Shared.Modelos.Entidades;

namespace TransacoesAPI.Shared.Modelos.Services;

public class TransacaoService
{
    public virtual List<Transacao> Trancacoes { get; set; } = new List<Transacao>();

    public void AdicionarTransacao(Transacao transacao)
    {

        if (transacao.dataHora > DateTime.UtcNow)
        {
            Console.Write($"Transação rejeitada: Data futura - {transacao.dataHora}");
        }

        else if (transacao.valor < 0)
        {
            Console.Write($"Transação rejeitada: Valor: {transacao.valor} é um valor negativo");
        }

        Console.Write("Transação feita com sucesso");
        Trancacoes.Add(transacao);
    }

    public void LimparTransacoes()
    {
        Console.Write("Transação apagadas com sucesso");
        Trancacoes.Clear();
    }

    public List<Transacao> BuscarTransacoes(int intervaloBusca)
    {
        DateTimeOffset dataHoraIntervalo = DateTimeOffset.Now.AddSeconds(-intervaloBusca);

        return Trancacoes.Where(transacao => transacao.dataHora > dataHoraIntervalo).ToList();
    }
}

