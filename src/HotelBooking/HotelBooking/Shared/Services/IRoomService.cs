using HotelBooking.Shared.Models;

namespace HotelBooking.Shared.Services;

public interface IRoomService
{
    Task<IEnumerable<Room>> GetPopularRooms();
    Task<IEnumerable<Room>> FindRooms(DateTime fromDate, DateTime toDate, int adults, int children);
    Task<Room> GetRoom(Guid roomId);
    Task<bool> IsRoomAvailable(DateTime checkInDate, DateTime checkOutDate);
}