using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarteiraDigital.Model.Domain;

public class CofreModel
{
    private decimal Dinheiro { get; set; }
    public Guid CarteiraId { get; set; }
    [ForeignKey("CarteiraId")] [JsonIgnore] private CarteiraModel? Carteira { get; set; }
}