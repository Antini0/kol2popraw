using kol2.Context;
using kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Services;

public class DbService : IDbService
{
    private readonly myContext _myContext;
    public DbService(myContext myContext)
    {
        _myContext = myContext;
    }

    
    public async Task<Character> GetCharacterData(int characterId)
    {
        return await _myContext.Characters.Where(c => c.IdCharacter == characterId).FirstOrDefaultAsync();
    }
    
    public async Task<bool> ItemsExist(List<int> itemIds)
    {
        var itemsCount = await _myContext.Items.CountAsync(i => itemIds.Contains(i.IdItem));
        return itemsCount == itemIds.Count;
    }

    public async Task AddItemsToBackpack(int characterId, List<int> itemIds)
    {
        var character = await GetCharacterData(characterId);
        var items = await _myContext.Items.Where(i => itemIds.Contains(i.IdItem)).ToListAsync();

        foreach (var item in items)
        {
            var backpackItem = character.Backpacks.FirstOrDefault(b => b.IdItem == item.IdItem);
            if (backpackItem != null)
            {
                backpackItem.Ammount += 1;
            }
            else
            {
                character.Backpacks.Add(new Backpack
                {
                    IdCharacter = characterId,
                    IdItem = item.IdItem,
                    Ammount = 1
                });
            }
            character.CurrentWeight += item.Weight;
        }

        _myContext.Characters.Update(character);
        await _myContext.SaveChangesAsync();
    }
    
    public async Task<int> GetItemsWeight(List<int> itemIds)
    {
        return await _myContext.Items.Where(i => itemIds.Contains(i.IdItem))
            .SumAsync(i => i.Weight);
    }

}