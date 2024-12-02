using shop.web.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.web.Entities;

[Table("tables")]
public class Table 
{

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id {get; set;}

    [MaxLength(100)]
    public string Name { get; set;}

    public TableStatus TableStatus {get; set;}

    public string ReservedTo {get; set;}

}