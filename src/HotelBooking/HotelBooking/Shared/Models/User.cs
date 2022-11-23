namespace HotelBooking.Shared.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Address { get; set; }
    public string? Address1 { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string? Phone { get; set; }
    public string Email { get; set; }
    public PaymentInfo? PaymentInfo { get; set; } = new PaymentInfo();
}