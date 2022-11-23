namespace HotelBooking.Shared.Models;

public class Booking
{
    public Guid Id { get; set; }
    public string? Number { get; set; }
    public DateTime CheckInDate { get; set; } = DateTime.Now;
    public DateTime CheckOutDate { get; set; } = DateTime.Now.AddDays(2);
    public Room Room { get; set; } = new();
    public User User { get; set; } = new();
    public int Adults { get; set; }
    public int Children { get; set; }
    public double Price => Math.Round(Room.Price * CheckOutDate.Subtract(CheckInDate).TotalDays, 2);
}