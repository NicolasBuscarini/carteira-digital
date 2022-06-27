using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarteiraDigital.Model.Domain;

public class CartaoModel
{
    private Guid Id { get; set; }
    public int Limite { get; set; }
    public decimal Fatura { get; set; }
    public bool Virtual { get; }
    public InformacaoCartaoModel InformacaoCartaoModel { get; set; }
    public DateTime DataFatura { get; set; }
    public Guid CarteiraId { get; set; }
    [ForeignKey("CarteiraId")] [JsonIgnore] private CarteiraModel? Carteira { get; set; }
    
}