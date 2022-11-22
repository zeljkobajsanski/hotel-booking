using System.Net.Http.Json;
using HotelBooking.Shared.Models;
using HotelBooking.Shared.Services;

namespace HotelBooking.Client.Services;

public class RoomService : IRoomService
{
    private readonly HttpClient _client;

    public RoomService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Room>> GetPopularRooms()
    {
        return await _client.GetFromJsonAsync<IEnumerable<Room>>("api/rooms") ?? Array.Empty<Room>();
    }

    public async Task<IEnumerable<Room>> FindRooms(DateTime fromDate, DateTime toDate, int adults, int children)
    {
        var response = await _client.PostAsJsonAsync("api/rooms", new{fromDate, toDate, adults, children});
        return await response.Content.ReadFromJsonAsync<IEnumerable<Room>>() ?? Array.Empty<Room>();
    }

    public Task<Room> GetRoom(Guid roomId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsRoomAvailable(DateTime checkInDate, DateTime checkOutDate)
    {
        throw new NotImplementedException();
    }
}