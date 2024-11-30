namespace shop.web.Entities;

public class Order 
{

    public int Id {get; set;}

    public int TableBillId {get; set;}

    public int Price {get; set;}

    public DateTime CreatedAt { get; set;}

    public virtual Item Item {get; set;}

    public TableBill TableBill {get; set;}

}