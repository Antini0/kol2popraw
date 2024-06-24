using System.ComponentModel.DataAnnotations;

namespace kol2.Models;

public class Title
{
    [Key] 
    public int IdTitle { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    public ICollection<Character_title> CharacterTitles { get; set; }
}