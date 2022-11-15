using HotelBooking.Shared.Models;

namespace HotelBooking.Server.Services
{
    public interface INotificationsService
    {
        void SendEmail(Booking booking);
    }
    public class NotificationsService : INotificationsService
    {
        public void SendEmail(Booking booking)
        {
            Console.WriteLine("[Notification service]: Email has been sent successfully");
        }
    }
}
