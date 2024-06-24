using kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kol2.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly IDbService _dbService;
    public CharacterController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetCharacterInfo(int characterId)
    {
        var result = await _dbService.GetCharacterData(characterId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}