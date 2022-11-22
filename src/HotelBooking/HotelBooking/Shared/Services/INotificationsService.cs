using HotelBooking.Shared.Models;

namespace HotelBooking.Shared.Services;

public interface INotificationsService
{
    Task SendEmail(Booking booking);
}