using System.ComponentModel.DataAnnotations;
using CarteiraDigital.Core.Interfaces.IService;
using CarteiraDigital.Model.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigital.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class CartaoController : ControllerBase
{
    private readonly IAuthService _authService;

    public CartaoController(IAuthService authService, ICartaoService cartaoService)
    {
        _authService = authService;
        _cartaoService = cartaoService;
    }
    
    [HttpPost("create-cartao")]
    public async Task<ActionResult> CreateCartao([FromBody][Required()] string cpf )
    {
        try
        {
            ApplicationUser user = await _authService.GetUserByCpf(cpf);

            ret = await _cartaoService.CreateCartao(user);

            return Ok(ret);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}