namespace PokeNetCore.Interfaces.IService;

public interface IPlayerService
{
    Task<Guid> CreatePlayer();
    Task<bool> StartBattle(Guid playerId);
    Task<bool> DeletePlayer(Guid playerId);
}