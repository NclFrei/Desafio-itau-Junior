using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacoesAPI.Shared.Modelos.Entidades;

public class Estatisticas
{
    public int count { get; set; }
    public double sum { get; set; }
    public double avg { get; set; }
    public double min { get; set; }
    public double max { get; set; }
}
