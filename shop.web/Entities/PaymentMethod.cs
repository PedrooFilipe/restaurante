using shop.web.Enums;

namespace shop.web.Entities;

public class PaymentMethod
{

    public int Id {get; set;}

    public PaymentMethodEnum TypePayment {get; set;}

    public int AmountPaied {get; set;}

    public int TableBillId {get; set;}


    public virtual TableBill TableBill {get; set;}

}