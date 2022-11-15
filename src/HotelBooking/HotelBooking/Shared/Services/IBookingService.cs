using HotelBooking.Shared.Models;

namespace HotelBooking.Shared.Services;

public interface IBookingService
{
    Task BookRoom(Booking booking);
}