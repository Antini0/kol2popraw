using kol2.Models;

namespace kol2.Services;

public interface IDbService
{
    Task<Character> GetCharacterData(int characterId);
    Task<bool> ItemsExist(List<int> itemIds);
    Task AddItemsToBackpack(int characterId, List<int> itemIds);
    public Task<int> GetItemsWeight(List<int> itemIds);
}