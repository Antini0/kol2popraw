using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kol2.Models;

[PrimaryKey(nameof(IdCharacter), nameof(IdTitle))]
public class Character_title
{
    [Key] 
    public int IdCharacter { get; set; }
    public int IdTitle { get; set; }
    
    [ForeignKey(nameof(IdCharacter))] 
    public Character Character { get; set; }
    
    [ForeignKey(nameof(IdTitle))] 
    public Title Title { get; set; }
    
    [Required]
    public DateTime AquiredAt { get; set; }
}