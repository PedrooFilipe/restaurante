using shop.web.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.web.Entities;

[Table("tableBills")]
public class TableBill 
{

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}

    public DateTime DateOpen {get; set;}

    public DateTime DateClosing {get; set;}

    public int TotalAmount {get; set;}

    public int DiscountAmount {get; set;}

    public int PaiedAmount {get; set;}

    public List<PaymentMethod> PaymentMethods { get; set;}

    public List<Table> Tables {get; set;}

}