using System.Net.Http.Json;
using HotelBooking.Shared.Models;
using HotelBooking.Shared.Services;

namespace HotelBooking.Client.Services;

public class UserService : IUserService
{
    private readonly HttpClient _client;

    public UserService(HttpClient client)
    {
        _client = client;
    }

    public Task<User> GetUser(Guid id)
    {
        return _client.GetFromJsonAsync<User>($"api/users/{id}")!;
    }

    public Task SaveUser(User user)
    {
        throw new NotImplementedException();
    }
}