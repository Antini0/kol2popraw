using kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kol2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly IDbService _dbService;

    public ItemsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpPost("characters/{characterId}/backpacks")]
    public async Task<IActionResult> AddItemsToBackpack(int characterId, [FromBody] List<int> itemIds)
    {
        if (!await _dbService.ItemsExist(itemIds))
        {
            return NotFound("One or more items do not exist.");
        }

        var character = await _dbService.GetCharacterData(characterId);
        if (character == null)
        {
            return NotFound("Character not found.");
        }

        var totalWeight = (await _dbService.ItemsExist(itemIds)) ? (await _dbService.GetItemsWeight(itemIds)) : 0;
        if (character.CurrentWeight + totalWeight > character.MaxWeight)
        {
            return BadRequest("Character cannot carry that much weight.");
        }

        await _dbService.AddItemsToBackpack(characterId, itemIds);
        var updatedCharacter = await _dbService.GetCharacterData(characterId);

        var result = new List<object>();
        foreach (var item in updatedCharacter.Backpacks)
        {
            if (itemIds.Contains(item.IdItem))
            {
                result.Add(new
                {
                    amount = item.Ammount,
                    itemId = item.IdItem,
                    characterId = item.IdCharacter
                });
            }
        }

        return Ok(result);
    }
}
    
