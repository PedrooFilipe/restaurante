using shop.web.Enums;

namespace shop.web.Entities;

public class Order 
{

    public int Id {get; set;}

    public int ItemId {get; set;}

    public int TableBillId {get; set;}

    public int Amount {get; set;}

    public int Quantity {get; set;}

    public string Observations {get; set;}

    public virtual Item Item {get; set;}

    public TableBill TableBill {get; set;}

}