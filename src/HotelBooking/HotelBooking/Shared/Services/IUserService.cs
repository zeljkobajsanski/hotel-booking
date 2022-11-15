using HotelBooking.Shared.Models;

namespace HotelBooking.Shared.Services;

public interface IUserService
{
    Task<User> GetUser(Guid id);
    Task SaveUser(User user);
}