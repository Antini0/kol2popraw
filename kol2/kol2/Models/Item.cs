using System.ComponentModel.DataAnnotations;

namespace kol2.Models;

public class Item
{
    [Key] 
    public int IdItem { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    [Required]
    public int Weight { get; set; }

    public ICollection<Backpack> Backpacks { get; set; }
}