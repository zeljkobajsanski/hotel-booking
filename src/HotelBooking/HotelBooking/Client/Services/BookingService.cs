using System.Net.Http.Json;
using HotelBooking.Shared.Models;
using HotelBooking.Shared.Services;

namespace HotelBooking.Client.Services
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task BookRoom(Booking booking)
        {
            await _httpClient.PostAsJsonAsync("api/bookings", booking);
        }
    }
}
