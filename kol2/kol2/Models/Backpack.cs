using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kol2.Models;

[PrimaryKey(nameof(IdCharacter), nameof(IdItem))]
public class Backpack
{
    [Key] 
    public int IdCharacter { get; set; }
    public int IdItem { get; set; }
    
    [ForeignKey(nameof(IdCharacter))] 
    public Character Character { get; set; }
    
    [ForeignKey(nameof(IdItem))] 
    public Item Item { get; set; }
    
    [Required]
    public int Ammount { get; set; }
}