using PokeNetCore.Domain.Models;
using PokeNetCore.Domain.Models.Dto;
using PokeNetCore.Domain.Models.Response;

namespace PokeNetCore.Interfaces.IService;

public interface IPokemonService
{
    Task CreateParty(Guid playerId);
    Task<IList<ApplicationPokemon>> GetPokemonByPlayerId(Guid playerId);
    Task<PokemonResponse> ChoosePokemon(ChoosePokemonDto choosePokemonDto);
}