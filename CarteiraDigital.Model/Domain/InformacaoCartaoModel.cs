using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarteiraDigital.Model.Domain;

public class InformacaoCartaoModel
{
    public Guid Id { get; set; }
    public string NumeroCartao { get; set; }
    public string CodigoSeguranca { get; set; }
    public DateTime DataValidade { get ; set; }
    public string Nome { get; set; }
    public Guid CartaoId { get; set; }
    [ForeignKey("CartaoId")] public CartaoModel Cartao { get; set; }
}