using HotelBooking.Shared.Models;
using HotelBooking.Shared.Services;

namespace BookingService;

public class BookingService : IBookingService
{
    private readonly INotificationsService _notificationsService;
    private readonly IPaymentService _paymentService;
    private readonly IRoomService _roomService;
    private readonly IUserService _userService;

    public BookingService(INotificationsService notificationsService, IPaymentService paymentService, IRoomService roomService, IUserService userService)
    {
        _notificationsService = notificationsService;
        _paymentService = paymentService;
        _roomService = roomService;
        _userService = userService;
    }

    public async Task BookRoom(Booking booking)
    {
        Console.WriteLine("[Booking service]: Creating booking...");

        await _userService.SaveUser(booking.User);

        var isRoomAvailable = await _roomService.IsRoomAvailable(booking.CheckInDate, booking.CheckOutDate);
        if (isRoomAvailable is false) throw new Exception("Room is not available");
        var room = await _roomService.GetRoom(booking.Room.Id);
        if (room.Price != booking.Room.Price) throw new Exception("Room price changed");

        await _paymentService.CheckCreditCard(booking.User.PaymentInfo);
        await _paymentService.MakePayment(booking.User.PaymentInfo, booking.Price);

        SaveBooking(booking);

        await _notificationsService.SendEmail(booking);
    }

    private void SaveBooking(Booking booking)
    {
        Console.WriteLine("[Booking service]: Booking has been created");
    }
}