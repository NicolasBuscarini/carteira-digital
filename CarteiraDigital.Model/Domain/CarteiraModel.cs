using System.ComponentModel.DataAnnotations.Schema;

namespace CarteiraDigital.Model.Domain;

public class CarteiraModel
{
    private Guid Id { get; set; }
    private decimal Dinheiro { get; set; }
    private Guid UserId { get; set; }
    [ForeignKey("UserId")] private ApplicationUser User { get; set; }  
    private Guid? CofreId { get; set; }
    [ForeignKey("CofreId")] private CofreModel? Cofre { get; set; }
    private Guid? CartaoId { get; set; }
    [ForeignKey("CartaoId")] private CarteiraModel? Cartao { get; set; }

    public CarteiraModel(Guid userId)
    {
        UserId = userId;
        Dinheiro = 0;
    }
}