namespace HotelBooking.Shared.Models;

public class PaymentInfo
{
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
}