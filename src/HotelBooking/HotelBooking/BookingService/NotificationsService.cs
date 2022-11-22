using HotelBooking.Shared.Models;
using HotelBooking.Shared.Services;

namespace BookingService;

public class NotificationsService : INotificationsService
{
    private readonly HttpClient _httpClient;

    public NotificationsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task SendEmail(Booking booking)
    {
        return _httpClient.PostAsJsonAsync("/api/send-email", booking);
    }
}