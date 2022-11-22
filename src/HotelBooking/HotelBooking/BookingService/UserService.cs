using HotelBooking.Shared.Models;
using HotelBooking.Shared.Services;

namespace BookingService;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<User> GetUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task SaveUser(User user)
    {
        await _httpClient.PostAsJsonAsync("/api/users", user);
    }
}