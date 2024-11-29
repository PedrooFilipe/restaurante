using shop.web.Enums;

namespace shop.web.Entities;

public class Table 
{

    public int Id {get; set;}

    public TableStatus TableStatus {get; set;}

    public string ReservedTo {get; set;}

}