using shop.web.Enums;

namespace shop.web.Entities;

public class TableBill 
{

    public int Id {get; set;}

    public DateTime DateOpen {get; set;}

    public DateTime DateClosing {get; set;}

    public int TotalAmount {get; set;}

    public int DiscountAmount {get; set;}

    public int PaiedAmount {get; set;}

    public List<Table> Tables {get; set;}

}