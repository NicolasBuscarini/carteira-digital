using PokeNetCore.Domain.Models.Dto;

namespace PokeNetCore.Interfaces.IService;

public interface IBattleService
{
    Task<StartersPokemonBattleDto> CreateBattle(NewBattleDto newBattleDto);
}