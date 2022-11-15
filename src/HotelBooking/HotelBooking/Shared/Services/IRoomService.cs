using HotelBooking.Shared.Models;

namespace HotelBooking.Shared.Services;

public interface IRoomService
{
    Task<IEnumerable<Room>> GetPopularRooms();
    Task<IEnumerable<Room>> FindRooms(DateTime fromDate, DateTime toDate, int adults, int children);
    Room GetRoom(Guid roomId);
    bool IsRoomAvailable(DateTime checkInDate, DateTime checkOutDate);
}