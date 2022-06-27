using System.ComponentModel.DataAnnotations;

namespace CarteiraDigital.Model.Domain;

public class InformacaoCartaoModel
{
    public string NumeroCartao { get; set; }
    public string CodigoSeguranca { get; set; }
    public DateTime DataValidade { get ; set; }
    public string Nome { get; set; }
    
}