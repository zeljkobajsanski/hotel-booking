using HotelBooking.Shared.Models;
using HotelBooking.Shared.Services;

namespace BookingService;

public class RoomService : IRoomService
{
    private readonly HttpClient _httpClient;

    public RoomService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<IEnumerable<Room>> GetPopularRooms()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Room>> FindRooms(DateTime fromDate, DateTime toDate, int adults, int children)
    {
        throw new NotImplementedException();
    }

    public Task<Room> GetRoom(Guid roomId)
    {
        return _httpClient.GetFromJsonAsync<Room>($"/api/rooms/{roomId}");
    }

    public async Task<bool> IsRoomAvailable(DateTime checkInDate, DateTime checkOutDate)
    {
        await _httpClient.PostAsJsonAsync("/api/room-availability", new { checkInDate, checkOutDate });
        return true;
    }
}