using shop.web.Enums;

namespace shop.web.Entities;

public class ItemOrder 
{

    public int Id {get; set;}

    public int ItemId {get; set;}

    public int Quantity {get; set;}

    public int TotalPrice { get; set;}

    public string Observations {get; set;}

    public virtual Item Item {get; set;}

    public virtual Order Order { get; set;}

}