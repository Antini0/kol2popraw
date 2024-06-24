using System.ComponentModel.DataAnnotations;

namespace kol2.Models;

public class Character
{
    [Key] 
    public int IdCharacter { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public int CurrentWeight { get; set; }
    
    [Required]
    public int MaxWeight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; }
    public ICollection<Character_title> CharacterTitles { get; set; }
}