using HotelBooking.Shared.Models;
using HotelBooking.Shared.Services;

namespace HotelBooking.Server.Services;

public class UserService : IUserService
{
    public Task<User> GetUser(Guid id)
    {
        return Task.Run(() => new User()
        {
            Id = id,
            FirstName = "John",
            LastName = "Doe",
            Address = "Aliothstrasse 4",
            City = "Münchenstein",
            ZipCode = "4142",
            Email = "jdoe@microtom.net",
            Country = "Switzerland",
            Phone = "+41 61 733 17 17",
        });
    }

    public Task SaveUser(User user) => Task.Run(() => Console.WriteLine("[User service]: Saving user"));
}