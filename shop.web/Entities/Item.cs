using shop.web.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.web.Entities;

[Table("items")]
public class Item 
{

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}

    [MaxLength(100)]
    public string Description {get; set;}

    public string Thumb {get; set;}

    public int Price {get; set;}

}